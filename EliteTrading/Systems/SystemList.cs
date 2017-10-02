using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EliteTrading.Systems
{
    public partial class SystemList : UserControl
    {
        public List<Data.System> Systems { get; private set; }

        public SystemList()
        {
            InitializeComponent();
            ApplyStyle();
            //Data.Vector3 vec = "bleh";
            /*Systems.Add(new Data.System("Oevaxy OA-A D0", new Data.Vector3(-221.25, -230, 65509.375)));
            Systems.Add(new Data.System("Sothis", new Data.Vector3(-352.78125, 10.5, -346.34375)));*/
        }

        public void ApplyStyle()
        {
            Style.Apply(this);
            Style.Apply(dataGridView1);
        }

        private delegate void dgvInvoke(List<Data.System> Systems);

        public void LoadData(List<Data.System> Systems)
        {
            if (dataGridView1.InvokeRequired)
                dataGridView1.Invoke(new dgvInvoke(dgvSetData), Systems);
            else
                dgvSetData(Systems);
        }

        private void dgvSetData(List<Data.System> Systems)
        {
            this.Systems = Systems;
            dataGridView1.DataSource = new SortableBindingList<Data.System>(Systems);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgvSender = (DataGridView)sender;
            if (dgvSender.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var SystemWindow = new Main((Data.System)dgvSender.Rows[e.RowIndex].DataBoundItem);
                SystemWindow.Show();
            }
        }
    }
}
