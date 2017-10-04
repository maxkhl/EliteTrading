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
    public partial class Faction : Form
    {
        Data.Faction Target;
        public Faction(Data.Faction Target)
        {
            InitializeComponent();
            this.Target = Target;

            this.Text = Target.name;

            this.lName.Text = Target.name;
            this.lHomeSystem.Text = Target.home_system.ToString();
            this.lGovernment.Text = Target.government;
            this.lState.Text = Target.state;
            this.lAllegiance.Text = Target.allegiance;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lAllegiance_Click(object sender, EventArgs e)
        {

        }

        private void lHomeSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Main(Target.home_system).Show();
        }
    }
}
