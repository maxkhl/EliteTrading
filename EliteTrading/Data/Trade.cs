using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    public class Trade
    {
        public List<TradeStep> Steps { get; private set; }


        public enum SearchFunctions
        {
            Default,
            ImperialSlavePowerplay
        }

        public string Start
        {
            get
            {
                return Steps.Count > 0 ? string.Format("{0} - {1}", Steps[0].System.name, Steps[0].Station.Name) : "";
            }
        }

        public string StartCommodities
        {
            get
            {
                return Steps.Count > 0 ? string.Format("Buy: {0} Sell: {1}", Steps[0].Buy, Steps[0].Sell) : "";
            }
        }

        public string End
        {
            get
            {
                return Steps.Count > 0 ? string.Format("{0} - {1}", Steps[Steps.Count - 1].System.name, Steps[Steps.Count - 1].Station.Name) : "";
            }
        }

        public string EndCommodities
        {
            get
            {
                return Steps.Count > 0 ? string.Format("Buy: {0} Sell: {1}", Steps[Steps.Count - 1].Buy, Steps[Steps.Count - 1].Sell) : "";
            }
        }

        public Route Route { get; private set; }



        /// <summary>
        /// Overall length for the whole route
        /// </summary>
        public double Length
        {
            get
            {
                double retLength = 0;
                for(int i = 0; i < Steps.Count; i++)
                {
                    int NextStep = i + 1;
                    if (NextStep >= Steps.Count)
                        NextStep = 0;

                    retLength += (Steps[i].System.Coordinates - Steps[NextStep].System.Coordinates).Length;
                }
                return retLength;
            }
        }

        public Trade()
        {
            Steps = new List<TradeStep>();
            Route = new Route();
        }
        public bool AddStep(System System, Station Station, Commodity Sell, Commodity Buy)
        {
            this.Steps.Add(new TradeStep(System, Station, Sell, Buy));
            return Route.AddTarget(System, Station, UserData.Max_Route_Length);
        }
        public bool AddStep(System System, Commodity Sell, Commodity Buy)
        {
            this.Steps.Add(new TradeStep(System, Sell, Buy));
            return Route.AddTarget(System, UserData.Max_Route_Length);
        }

        public static List<Trade> FindTrades(TaskStatus status, SearchFunctions SearchFunction)
        {
            var Trades = new List<Trade>();
            
            var SystemsInReach = (from system in GlobalData.Systems
                                  where (system.Coordinates - UserData.System.Coordinates).Length < UserData.Max_Travel_Distance
                                  select system).ToList();

            for (int i = 0; i < SystemsInReach.Count; i++ )
            {
                status.Progress = (int)((double)(i + 1) / (double)SystemsInReach.Count * 100);
                status.ProcessedObjects = Trades.Count;
                var SystemPool = (from system in GlobalData.Systems
                                  where (system.Coordinates - SystemsInReach[i].Coordinates).Length < UserData.Max_Jump_Distance * UserData.Max_Route_Length
                                  select system).ToList();

                List<Trade> newTrades = null;
                switch(SearchFunction)
                {
                    case SearchFunctions.Default:
                        newTrades = Rules.Check(SystemsInReach[i], SystemPool);
                        break;
                    case SearchFunctions.ImperialSlavePowerplay:
                        newTrades = Rules.CheckImpSlave(SystemsInReach[i], SystemPool);
                        break;
                }

                if (newTrades != null)
                {
                    // Condense
                    for(int c = 0; c < newTrades.Count; c++)
                    {
                        foreach(var oldTrade in Trades)
                        {
                            if (newTrades.Count <= 0) continue;

                            if ((newTrades[c].Start == oldTrade.End &&
                                newTrades[c].End == oldTrade.Start) ||
                                (newTrades[c].End == oldTrade.End &&
                                newTrades[c].Start == oldTrade.Start))
                            {
                                newTrades.RemoveAt(c);
                            }
                        }
                    }

                    Trades.AddRange(newTrades);

                    Trade[] aTrades = new Trade[Trades.Count];
                    Trades.CopyTo(aTrades);
                    status.Tag1 = aTrades.ToList();
                }

                if (status.CancelRequest)
                {
                    i = SystemsInReach.Count;
                    status.Progress = 100;
                    status.CancelRequest = false;

                    /*if(Trades.Count > UserData.stopAfterTrades)
                    {
                        var difference = Trades.Count - UserData.stopAfterTrades;
                        Trades.RemoveRange(Trades.Count - 1 - difference, difference);
                    }*/
                }
            }



            return Trades;
        }

        public struct TradeStep
        {
            public System System;
            public Station Station;
            public Commodity Sell;
            public Commodity Buy;
            public TradeStep(System System, Station Station, Commodity Sell, Commodity Buy)
            {
                this.System = System;
                this.Station = Station;
                this.Sell = Sell;
                this.Buy = Buy;
            }
            public TradeStep(System System, Commodity Sell, Commodity Buy)
            {
                this.System = System;
                this.Station = null;
                this.Sell = Sell;
                this.Buy = Buy;
            }
        }
    }
}
