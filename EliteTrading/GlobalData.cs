using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace EliteTrading
{
    public static class GlobalData
    {
        public static List<Data.System> Systems;
        public static List<Data.Commodity> Commodities;

        private static Task LoadingTask;

        public static int Progress = 0;
        public static string ProgressMessage = "";
        public static bool Loading = false;
        public static void Load()
        {
            LoadingTask = new Task(new Action(LoadData));

            LoadingTask.Start();
            Loading = true;
        }
        private static void LoadData()
        {
            Progress = 0;
            LoadSystems();
            ProgressMessage = "Loading Commodities";
            LoadCommodities();
            Progress = 100;

            if (OnLoadingFinished != null)
                OnLoadingFinished();
            Loading = false;
        }

        private static void LoadCommodities()
        {
            var ComFile = new FileInfo("Data/commodities.json");
            DownloadDB(ComFile, AppSettings.Default.CommodityDbUrl);

            Commodities = Data.Commodity.Load(ComFile);
        }

        private static void DownloadDB(FileInfo File, string URL)
        {
            ProgressMessage = String.Format("Loading {0}\nDatabase", File.Name);
            if (File.Exists && (File.CreationTime - DateTime.Now).Days > 1)
                File.Delete();

            if (!File.Directory.Exists) File.Directory.Create();
            if (!File.Exists)
            {
                using (var client = new WebClient())
                {
                    ProgressMessage = String.Format("Loading {0}\nDatabase from Remote", File.Name);
                    client.DownloadFile(URL, File.FullName);
                }
            }
        }

        private static void LoadSystems()
        {
            Systems = new List<Data.System>();

            var FactionsFile = new System.IO.FileInfo("Data/factions.json");
            DownloadDB(FactionsFile, AppSettings.Default.FactionsDbUrl);

            var SystemsFile = new System.IO.FileInfo("Data/systems.json");
            DownloadDB(SystemsFile, AppSettings.Default.SystemsDbUrl);
            
            var StationsFile = new System.IO.FileInfo("Data/stations_lite.json");
            DownloadDB(StationsFile, AppSettings.Default.StationsDbUrl);


            var FactionsArray = new Data.Faction[0];
            using (var reader = new StreamReader(FactionsFile.FullName))
            {
                string json = reader.ReadToEnd();
                json = json.Replace("null", "0");
                ProgressMessage = "Reading Factions";

                var FactionsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Data.Faction>>(json);
                Progress = 10;

                ProgressMessage = "Processing Factions";

                int LargestID = 0;
                foreach (var faction in FactionsList)
                {
                    if (faction.id > LargestID)
                        LargestID = faction.id;
                }

                FactionsArray = new Data.Faction[LargestID + 1];

                foreach (var faction in FactionsList)
                {
                    FactionsArray[faction.id] = faction;
                }
            }

            using (var reader = new StreamReader(SystemsFile.FullName))
            {
                string json = reader.ReadToEnd();
                json = json.Replace("null", "0");
                ProgressMessage = "Reading Systems";
                var SystemList = new List<Data.System>();
                SystemList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Data.System>>(json);
                Progress = 20;

                ProgressMessage = "Processing Systems";
                int LargestID = 0;
                foreach (var system in SystemList)
                {
                    if (system.id > LargestID)
                        LargestID = system.id;
                }

                var SysArray = new Data.System[LargestID + 1];

                foreach (var system in SystemList)
                {
                    if (system.power == "0")
                        system.power = "";
                    if (system.primary_economy == "0")
                        system.primary_economy = "";
                    if (system.security == "0")
                        system.security = "";
                    if (system.state == "0")
                        system.state = "";
                    if (system.government == "0")
                        system.government = "";
                    if (system.allegiance == "0")
                        system.allegiance = "";

                    system.faction = FactionsArray[system.controlling_minor_faction_id];
                    SysArray[system.id] = system;
                }
                SystemList.Clear();
                SystemList = null;

                foreach(var faction in FactionsArray)
                {
                    if (faction != null)
                        faction.home_system = SysArray[faction.home_system_id];
                }
                

                Progress = 40;

                ProgressMessage = "Reading Stations";
                var Stations = new List<Data.Station>();
                using (var sreader = new StreamReader(StationsFile.FullName))
                {
                    string sjson = sreader.ReadToEnd();
                    sjson = sjson.Replace("null", "0");
                    Stations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Data.Station>>(sjson);
                }
                Progress = 80;
                ProgressMessage = "Processing Stations";

                foreach (var station in Stations)
                {
                    station.Faction = FactionsArray[station.FactionID];

                    SysArray[station.System_ID].Stations.Add(station);
                }
                Stations.Clear();


                Systems = SysArray.Where(x => x != null).ToList();

                foreach (var system in Systems)
                {
                    system.ParseNote();
                }
                Progress = 95;


            }
        }

        public delegate void OnLoadingFinishedHandler();
        public static event OnLoadingFinishedHandler OnLoadingFinished;

    }
}
