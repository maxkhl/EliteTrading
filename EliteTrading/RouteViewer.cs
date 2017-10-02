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
    public partial class RouteViewer : Form
    {
        public RouteViewer(Data.Route Route, string Text = "Route Viewer")
        {
            InitializeComponent();
            ApplyStyle();
            this.Text = Text;
            dataGridView1.DataSource = new SortableBindingList<Data.Route.RouteStep>(Route.Steps);
            map1.InitializeMap();
            map1.Routes.Add(Route);
            map1.Target = Route.Steps[0].System;

        }

        public void ApplyStyle()
        {
            Style.Apply(this);
            Style.Apply(dataGridView1);
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgvSender = (DataGridView)sender;
            if (dgvSender.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var SystemWindow = new Systems.Main(((Data.Route.RouteStep)dgvSender.Rows[e.RowIndex].DataBoundItem).System);
                SystemWindow.Show();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgvSender = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                map1.Target = ((Data.Route.RouteStep)dgvSender.Rows[e.RowIndex].DataBoundItem).System;
            }
        }
    }
}
