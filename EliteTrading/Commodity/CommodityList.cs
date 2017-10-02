using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EliteTrading.Commodity
{
    public partial class CommodityList : UserControl
    {
        public CommodityList()
        {
            InitializeComponent();
            ApplyStyle();
        }

        public void ApplyStyle()
        {
            Style.Apply(dataGridView1);
        }
        public void Load(List<Data.Commodity> Commodities)
        {
            this.dataGridView1.DataSource = new SortableBindingList<Data.Commodity>(Commodities);
        }
    }
}
