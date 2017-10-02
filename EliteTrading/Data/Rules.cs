using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    public static class Rules
    {
        public static List<Trade> Check(System System, List<System> SystemPool)
        {
            var Trades = new List<Trade>();

            // Order by distance -> first hit will be closest
            SystemPool.OrderBy(s=> (s.Coordinates - UserData.System.Coordinates).Length);

            // Get source economies & export/import commodities of source system
            List<string> Economies = new List<string>();
            List<string> ExportCommodities = new List<string>();
            List<string> ImportCommodities = new List<string>();
            foreach (var sStation in System.Stations)
            {
                if(sStation.Distance_to_Star > UserData.Max_Station_Star_Distance)
                    continue;
                if(UserData.LPad && sStation.Max_landing_pad_size != "L")
                    continue;

                foreach (var Economie in sStation.Economies)
                    if (!Economies.Contains(Economie))
                        Economies.Add(Economie);
                foreach (var Export in sStation.ExportCommodities)
                    if (!ExportCommodities.Contains(Export) && Commodity.GetByName(Export).AveragePrice > UserData.minAveragePrice)
                        ExportCommodities.Add(Export);
                foreach (var Import in sStation.ImportCommodities)
                    if (!ImportCommodities.Contains(Import) && Commodity.GetByName(Import).AveragePrice > UserData.minAveragePrice)
                        ImportCommodities.Add(Import);
            }
            if(ExportCommodities.Count == 0 || ImportCommodities.Count == 0)
                return Trades;

            // Find match in System Pool
            //Trades.AddRange(CheckSystem(SystemPool, 1, System, System, ImportCommodities, ExportCommodities));
            foreach(var tSystem in SystemPool)
            {
                foreach (var tStation in tSystem.Stations)
                {
                    if (tStation.Distance_to_Star > UserData.Max_Station_Star_Distance)
                        continue;
                    if (UserData.LPad && tStation.Max_landing_pad_size != "L")
                        continue;

                    Commodity ExportMatch = null;
                    foreach (var Export in tStation.ExportCommodities)
                        if (ImportCommodities.Contains(Export))
                            ExportMatch = Commodity.GetByName(Export);

                    Commodity ImportMatch = null;
                    foreach (var Import in tStation.ImportCommodities)
                        if (ExportCommodities.Contains(Import))
                            ImportMatch = Commodity.GetByName(Import);

                    if (ExportMatch != null && ImportMatch != null)
                    {
                        var newTrade = new Trade();

                        Station SourceStation = null;
                        System.Stations.OrderBy(s => s.Distance_to_Star);

                        foreach (var sStation in System.Stations)
                            if (sStation.ExportCommodities.Contains(ImportMatch.Name) &&
                                sStation.ImportCommodities.Contains(ExportMatch.Name))
                            {
                                SourceStation = sStation;
                                continue;
                            }

                        if (SourceStation == null)
                            continue;

                        if (newTrade.AddStep(System, SourceStation, ExportMatch, ImportMatch) && // Source Station
                           newTrade.AddStep(tSystem, tStation, ImportMatch, ExportMatch)) // Target Station
                            Trades.Add(newTrade);
                        continue;
                    }
                }
            }


            return Trades;
        }

        private static List<Trade> CheckSystem(List<System> SystemPool, int Run, System System, System SourceSystem, List<string> ImportCommodities, List<string> ExportCommodities)
        {
            var Trades = new List<Trade>();

            if (Run > UserData.Max_Route_Length)
                return Trades;

            foreach (var tSystem in SystemPool)
            {
                if (tSystem == System)
                    continue;

                if ((tSystem.Coordinates - System.Coordinates).Length > UserData.Max_Jump_Distance)
                    continue;

                foreach (var tStation in tSystem.Stations)
                {

                    if (tStation.Distance_to_Star > UserData.Max_Station_Star_Distance)
                        continue;
                    if (UserData.LPad && tStation.Max_landing_pad_size != "L")
                        continue;

                    Commodity ExportMatch = null;
                    foreach (var Export in tStation.ExportCommodities)
                        if (ImportCommodities.Contains(Export))
                            ExportMatch = Commodity.GetByName(Export);

                    Commodity ImportMatch = null;
                    foreach (var Import in tStation.ImportCommodities)
                        if (ExportCommodities.Contains(Import))
                            ImportMatch = Commodity.GetByName(Import);

                    if(ExportMatch != null && ImportMatch != null)
                    {
                        // Found a 1-1 route
                        Station SourceStation = null;
                        System.Stations.OrderBy(s=>s.Distance_to_Star);

                        foreach (var sStation in SourceSystem.Stations)
                            if(sStation.ExportCommodities.Contains(ImportMatch.Name) &&
                                sStation.ImportCommodities.Contains(ExportMatch.Name))
                            {
                                SourceStation = sStation;
                                continue;
                            }

                        if (SourceStation == null)
                            continue;

                        var newTrade = new Trade();

                        if(newTrade.AddStep(SourceSystem, SourceStation, ExportMatch, ImportMatch) && // Source Station
                           newTrade.AddStep(tSystem, tStation, ImportMatch, ExportMatch)) // Target Station
                            Trades.Add(newTrade);
                        continue;
                    }
                }

                var newSubTrades = CheckSystem(SystemPool, Run + 1, tSystem, SourceSystem, ImportCommodities, ExportCommodities);
                if (newSubTrades == null && newSubTrades.Count > 0)
                    Trades.AddRange(newSubTrades);
            }

            return Trades;
        }

        
        public static List<Trade> CheckImpSlave(System System, List<System> SystemPool)
        {
            var Trades = new List<Trade>();

            if (System.power_control_faction != "Zemina Torval" &&
                System.power_control_faction != "Archon Delaine")
                return Trades;

            bool HasValidStation = false;
            foreach (var sStation in System.Stations)
            {
                if (sStation.Distance_to_Star > UserData.Max_Station_Star_Distance)
                    continue;
                if (UserData.LPad && sStation.Max_landing_pad_size != "L")
                    continue;
                HasValidStation = true;
            }
            if (!HasValidStation)
                return Trades;
            
            // Find match in System Pool
            Trades.AddRange(CheckSystemForFaction(
                System.power_control_faction == "Zemina Torval" ? "Archon Delaine" : "Zemina Torval",
                SystemPool, 
                1, 
                System, 
                System));


            return Trades;
        }

        private static List<Trade> CheckSystemForFaction(string Faction, List<System> SystemPool, int Run, System System, System SourceSystem)
        {
            var Trades = new List<Trade>();

            if (Run > UserData.Max_Route_Length)
                return Trades;

            foreach (var tSystem in SystemPool)
            {
                if (tSystem.power_control_faction != Faction)
                    continue;

                if (tSystem == System)
                    continue;

                if ((tSystem.Coordinates - System.Coordinates).Length > UserData.Max_Jump_Distance)
                    continue;

                Station FirstValidStation = null;
                foreach (var tStation in tSystem.Stations)
                {
                    if (tStation.Distance_to_Star > UserData.Max_Station_Star_Distance)
                        continue;
                    if (UserData.LPad && tStation.Max_landing_pad_size != "L")
                        continue;
                    if (FirstValidStation == null)
                        FirstValidStation = tStation;
                }
                if (FirstValidStation == null) continue;

                var newTrade = new Trade();
                if (SourceSystem.power_control_faction == "Zemina Torval")
                {
                    newTrade.AddStep(SourceSystem, Commodity.GetByName("Imperial Slaves"), null);
                    newTrade.AddStep(tSystem, null, Commodity.GetByName("Imperial Slaves"));
                }
                else
                {
                    newTrade.AddStep(SourceSystem, null, Commodity.GetByName("Imperial Slaves"));
                    newTrade.AddStep(tSystem, Commodity.GetByName("Imperial Slaves"), null);
                }
                Trades.Add(newTrade);
            }
            return Trades;
        }
        
    }
}
