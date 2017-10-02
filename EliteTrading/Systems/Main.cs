using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTrading.Systems
{
    public partial class Main : Form
    {
        public Data.System DisplaySystem { get; private set; }
        public Main(Data.System System)
        {


            InitializeComponent();

            ApplyStyle();
            this.DisplaySystem = System;
            this.Text = System.name;

            this.lName.Text = System.name;
            this.lGovernment.Text = System.government;
            this.lFaction.Text = System.power_control_faction == "" ? "Uncontrolled" : System.power_control_faction;
            this.lEconomy.Text = System.primary_economy;
            this.lPermit.Text = System.needs_permit ? "Yes" : "No special permit needed";
            this.lPopulation.Text = string.Format("{0:n0}", System.population);
            this.lSecurity.Text = System.security;
            this.lState.Text = System.state;
            this.lCoordinates.Text = System.Coordinates.ToString();
            this.lSOL.Text = string.Format("{0:n} Ly", System.Coordinates.Length);
            this.lDistCurrent.Text = UserData.System != null ? string.Format("{0:n} Ly", (UserData.System.Coordinates - System.Coordinates).Length) : "unknown";
            this.lNotes.Text = System.note == "" ? "-" : System.note;

            this.dataGridView1.DataSource = System.Stations;
        }

        public void ApplyStyle()
        {
            Style.Apply(this);
            Style.Apply(dataGridView1);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

    }
}
