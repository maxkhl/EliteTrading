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
    public partial class Results : Form
    {
        public Results(string Text, List<Data.System> Systems)
        {
            InitializeComponent();
            this.Text = Text;
            systemList1.LoadData(Systems);
        }
    }
}
