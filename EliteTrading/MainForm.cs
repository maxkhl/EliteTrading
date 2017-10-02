using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTrading
{
    public partial class MainForm : Form
    {
        SplashScreen splashScreen;
        public MainForm()
        {
            UserData.Load();

            if (UserData.ShowSplash)
                this.splashScreen = new SplashScreen();

            InitializeComponent();
            ApplyStyle();
            reloadToolStripMenuItem_Click(null, null);

            tDistance.Value = UserData.Max_Travel_Distance;
            tStationStarDist.Value = UserData.Max_Station_Star_Distance;
            jDistance.Value = UserData.Max_Jump_Distance;
            routeLength.Value = UserData.Max_Route_Length;
            minAveragePrice.Value = UserData.minAveragePrice;
            cB_LPad.Checked = UserData.LPad;

            if (UserData.Fullscreen)
                this.WindowState = FormWindowState.Maximized;
        }

        public void ApplyStyle()
        {
            Style.Apply(this);
            Style.Apply(menuStrip1);
            systemList1.ApplyStyle();
            Style.Apply(statusStrip1);
        }

        Timer ProgressBarUpdater;
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBarUpdater = new Timer() { Interval = 15, Enabled = true };
            ProgressBarUpdater.Tick += ProgressBarUpdater_Tick;
            ProgressBarUpdater.Start();
            GlobalData.OnLoadingFinished += GlobalData_OnLoadingFinished;
            GlobalData.Load();
        }

        void GlobalData_OnLoadingFinished()
        {
            systemList1.LoadData(GlobalData.Systems);
        }

        void ProgressBarUpdater_Tick(object sender, EventArgs e)
        {
            if (!progressBar.Visible)
                progressBar.Visible = true;

            if (UserData.ShowSplash)
            {
                if (!splashScreen.Visible)
                    splashScreen.Show();
                else
                    splashScreen.lStatus.Text = GlobalData.ProgressMessage;
            }

            progressBar.Value = GlobalData.Progress;
            l_LoadingStatus.Text = GlobalData.ProgressMessage;

            if(GlobalData.Progress >= 100)
            {
                progressBar.Visible = false;
                ProgressBarUpdater.Stop();
                l_Data.Text = string.Format("{0} Systems loaded", GlobalData.Systems.Count.ToString());
                this.Enabled = true;

                cB_Location.Items.AddRange(GlobalData.Systems.ToArray());
                cB_Location.Text = UserData.Location;
                l_LoadingStatus.Text = "";

                if (UserData.ShowSplash)
                    splashScreen.Close();
            }
        }

        private void cB_Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
            {
                bFindGoodTrade.Enabled = true;
                UserData.Location = cB_Location.Text;
                UserData.System = (Data.System)((ComboBox)sender).SelectedItem;
            }
            else
                bFindGoodTrade.Enabled = false;    
        }

        private void cB_Location_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
            {
                bFindGoodTrade.Enabled = true;
                UserData.Location = cB_Location.Text;
                UserData.System = (Data.System)((ComboBox)sender).SelectedItem;
            }
            else
                bFindGoodTrade.Enabled = false;    
        }

        private void bFindGoodTrade_Click(object sender, EventArgs e)
        {
            var tradeWindow = new TradeResult();
            tradeWindow.TextBox.AppendText("Potential Trade Routes" + Environment.NewLine, Color.Blue, 15);
            tradeWindow.TextBox.AppendText(Environment.NewLine + "The algorithm is calculating a packet of systems that are at most ");
            tradeWindow.TextBox.AppendText(UserData.Max_Travel_Distance + " Ly ", Color.OrangeRed);
            tradeWindow.TextBox.AppendText("away from ");
            tradeWindow.TextBox.AppendText(UserData.System.ToString(), Color.OrangeRed);
            tradeWindow.TextBox.AppendText(". ");
            tradeWindow.TextBox.AppendText("While iterating through every system in the designated space, neighbouring systems within ");
            tradeWindow.TextBox.AppendText(UserData.Max_Jump_Distance + " Ly ", Color.OrangeRed);
            tradeWindow.TextBox.AppendText("will be searched. ");

            if (UserData.Max_Route_Length > 1)
            {
                tradeWindow.TextBox.AppendText("Those systems can contain neighbours within the designated range aswell. This continues until ");
                tradeWindow.TextBox.AppendText(UserData.Max_Route_Length + " jumps ", Color.OrangeRed);
                tradeWindow.TextBox.AppendText("are reached. ");
            }
            tradeWindow.TextBox.AppendText("The distance of a station to its star needs to be smaller than ");
            tradeWindow.TextBox.AppendText(UserData.Max_Station_Star_Distance + " Ls", Color.OrangeRed);
            tradeWindow.TextBox.AppendText(". ");

            if (UserData.LPad)
                tradeWindow.TextBox.AppendText("A station has to offer a large landing pad. ");

            tradeWindow.TextBox.AppendText(Environment.NewLine);
            tradeWindow.TextBox.AppendText(Environment.NewLine);
            tradeWindow.TextBox.AppendText("Trade routes are defined by a simple import <-> export match. Its a match if one system imports a commodity that another system exports and the other way around. ");

            if (UserData.minAveragePrice > 0)
            {
                tradeWindow.TextBox.AppendText("Commodities need the have a galactic average price of at least ");
                tradeWindow.TextBox.AppendText(UserData.minAveragePrice + " credits", Color.OrangeRed);
                tradeWindow.TextBox.AppendText(". ");
            }
            else
                tradeWindow.TextBox.AppendText("All commodities are accepted.");

            tradeWindow.TextBox.AppendText(Environment.NewLine);
            tradeWindow.TextBox.AppendText(Environment.NewLine);

            tradeWindow.TextBox.AppendText("Depending on your cpu power and current load the search might take a while. A trade route will instantly be displayed when it is discovered.");



            
            tradeWindow.Show();
            //MessageBox.Show("Working on it goddammit.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserData.Fullscreen = this.WindowState == FormWindowState.Maximized;
            UserData.Save();
        }

        private void whereToBuyShipsGearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Targets = (from system in GlobalData.Systems
                           where system.power_control_faction == "Li Yong-Rui" &&
                                 system.needs_permit == false &&
                                 system.primary_economy == "High Tech" &&
                                 (from station in system.Stations
                                    where station.HasOutfitting == true
                                      select station) != null ? true : false
                           select system).ToList().OrderBy(a => a.population);

            if (UserData.System != null)
                Targets = Targets.OrderBy(a => (a.Coordinates - UserData.System.Coordinates).Length);

            var resultWindow = new Systems.Results("Where to buy Ships/Gear?", Targets.ToList());
            resultWindow.Show();

        }

        private void jDistance_ValueChanged(object sender, EventArgs e)
        {
            UserData.Max_Jump_Distance = (int)jDistance.Value;
        }

        private void routeLength_ValueChanged(object sender, EventArgs e)
        {
            UserData.Max_Route_Length = (int)routeLength.Value;
        }

        private void tDistance_ValueChanged(object sender, EventArgs e)
        {
            UserData.Max_Travel_Distance = (int)tDistance.Value;
        }

        private void tStationStarDist_ValueChanged(object sender, EventArgs e)
        {
            UserData.Max_Station_Star_Distance = (int)tStationStarDist.Value;
        }

        private void minAveragePrice_ValueChanged(object sender, EventArgs e)
        {
            UserData.minAveragePrice = (int)minAveragePrice.Value;
        }

        private void commoditiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalData.Commodities == null)
                MessageBox.Show("Commodity-Data not loaded yet");
            else
                new Commodity.Main().Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
            ApplyStyle();
        }

        private void cB_LPad_CheckedChanged(object sender, EventArgs e)
        {
            UserData.LPad = cB_LPad.Checked;
        }

        private void powerplayImperialSlaveRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tradeWindow = new TradeResult(Data.Trade.SearchFunctions.ImperialSlavePowerplay);
            tradeWindow.TextBox.AppendText("Imperial Slave Routes" + Environment.NewLine, Color.Blue, 15);
            tradeWindow.TextBox.AppendText(Environment.NewLine + "It is possible to buy Imperial Slaves in systems controlled by Zemina Torwal with a 10% discount and sell them on the black market in Acheron Delaine-controlled systems for a price boost of 15%. ");
            tradeWindow.TextBox.AppendText(Environment.NewLine + "This function will look for routes that match your filters and allow you to smuggle Imperial Slaves between the two powers. ");
            tradeWindow.TextBox.AppendText(Environment.NewLine + Environment.NewLine + "The current galactic average price of Imperial Slaves is ");

            var slavesAVG = (double)Data.Commodity.GetByName("Imperial Slaves").AveragePrice;
            tradeWindow.TextBox.AppendText(slavesAVG + " credits", Color.OrangeRed);
            tradeWindow.TextBox.AppendText(". A potential profit of around ");
            tradeWindow.TextBox.AppendText(Math.Round(slavesAVG * 1.15 - slavesAVG * 0.9) + " credits per ton", Color.OrangeRed);
            tradeWindow.TextBox.AppendText(" is possible." + Environment.NewLine + Environment.NewLine);

            tradeWindow.TextBox.AppendText("Please keep in mind that Imperial Slaves are probably illegal in systems controlled by Acheron Delaine.", Color.Red, 13);
            tradeWindow.Show();
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SystemMap = new Systems.SystemMap();
            if (!SystemMap.map1.Style.ContainsKey(UserData.System))
                SystemMap.map1.Style.Add(UserData.System, new Systems.Map.SystemDrawOptions() { Color = Color.Red, ShowName = true, Size = 10, Text = "You are here" });
            SystemMap.map1.Target = UserData.System;
            SystemMap.Show();
        }

        private void routeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RouteSel().Show();
        }
    }
}
