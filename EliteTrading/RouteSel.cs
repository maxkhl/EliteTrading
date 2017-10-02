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
    public partial class RouteSel : Form
    {
        Data.System Start = null;
        Data.System End = null;

        public RouteSel()
        {
            InitializeComponent();
            cB_Start.Text = UserData.Location;
            cB_Start.Items.AddRange(GlobalData.Systems.ToArray());
            cB_End.Items.AddRange(GlobalData.Systems.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var route = Data.Route.Calculate(Start, End);
            if (route == null)
                MessageBox.Show("No route found.");
            else
                new RouteViewer(route, Start.ToString() + " -> " + End.ToString()).Show();
        }

        private void cB_Start_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
                Start = (Data.System)((ComboBox)sender).SelectedItem;

            CheckButtonOk();
        }

        private void cB_Start_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
                Start = (Data.System)((ComboBox)sender).SelectedItem;

            CheckButtonOk();
        }

        private void CheckButtonOk()
        {
            if (Start != null && End != null)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void cB_End_TextChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
                End = (Data.System)((ComboBox)sender).SelectedItem;

            CheckButtonOk();
        }

        private void cB_End_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
                End = (Data.System)((ComboBox)sender).SelectedItem;

            CheckButtonOk();
        }
    }
}
