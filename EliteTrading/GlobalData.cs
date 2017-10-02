using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Commodities = Data.Commodity.Load(new FileInfo("Data/commodities.json"));
        }

        private static void LoadSystems()
        {
            Systems = new List<Data.System>();

            var SystemsFile = new System.IO.FileInfo("Data/systems.json");
            var StationsFile = new System.IO.FileInfo("Data/stations_lite.json");

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
                    if (system.power_control_faction == "0")
                        system.power_control_faction = "";
                    if (system.primary_economy == "0")
                        system.primary_economy = "";
                    if (system.security == "0")
                        system.security = "";
                    if (system.state == "0")
                        system.state = "";
                    if (system.government == "0")
                        system.government = "";
                    if (system.faction == "0")
                        system.faction = "";
                    if (system.allegiance == "0")
                        system.allegiance = "";

                    SysArray[system.id] = system;
                }
                SystemList.Clear();
                SystemList = null;

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
