using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTrading.Commodity
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ApplyStyle();
            commodityList1.Load(GlobalData.Commodities);
        }

        public void ApplyStyle()
        {
            Style.Apply(this);
        }
    }
}
