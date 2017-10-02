using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading
{
    static class UserData
    {
        public static string Location;
        public static int Max_Travel_Distance;
        public static int Max_Station_Star_Distance;
        public static int Max_Jump_Distance;
        public static int Max_Route_Length;
        public static int minAveragePrice;
        public static bool Fullscreen;
        public static bool ShowSplash;
        public static bool LPad;
        public static StyleType Style;
        public static Data.System System = null;

        public static void Load()
        {
            Location = AppSettings.Default.Location;
            /*if (Location != "")
                System = (from system in GlobalData.Systems
                          where system.name == Location
                          select system).FirstOrDefault();*/

            Max_Travel_Distance = AppSettings.Default.Max_Travel_Distance;
            Max_Station_Star_Distance = AppSettings.Default.Max_Station_Star_Distance;
            Max_Jump_Distance = AppSettings.Default.Max_Jump_Distance;
            Max_Route_Length = AppSettings.Default.Max_Route_Length;
            minAveragePrice = AppSettings.Default.minAveragePrice;
            Fullscreen = AppSettings.Default.Fullscreen;
            ShowSplash = UserSettings.Default.ShowSplash;
            Style = UserSettings.Default.Style;
            LPad = AppSettings.Default.LPad;
        }

        public static void Save()
        {
            AppSettings.Default.Location = Location;
            AppSettings.Default.Max_Travel_Distance = Max_Travel_Distance;
            AppSettings.Default.Max_Station_Star_Distance = Max_Station_Star_Distance;
            AppSettings.Default.Max_Jump_Distance = Max_Jump_Distance;
            AppSettings.Default.Max_Route_Length = Max_Route_Length;
            AppSettings.Default.minAveragePrice = minAveragePrice;
            AppSettings.Default.Fullscreen = Fullscreen;
            UserSettings.Default.ShowSplash = ShowSplash;
            UserSettings.Default.Style = Style;
            AppSettings.Default.LPad = LPad;

            AppSettings.Default.Save();
            UserSettings.Default.Save();
        }
    }
}
