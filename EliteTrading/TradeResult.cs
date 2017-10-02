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
    public partial class TradeResult : Form
    {
        Timer ProgressTimer;
        Task SearchTask;
        TaskStatus taskStatus = new TaskStatus();
        Data.Trade.SearchFunctions TradeFunction;
        public TradeResult(Data.Trade.SearchFunctions TradeFunction = Data.Trade.SearchFunctions.Default)
        {
            this.TradeFunction = TradeFunction;
            InitializeComponent();
            ApplyStyle();

            map1.InitializeMap();
            map1.Style.Add(UserData.System, new Systems.Map.SystemDrawOptions() { Size = 10, Text = "You are here", Color = System.Drawing.Color.Red, ShowName = true });
            map1.Target = UserData.System;

            ProgressTimer = new Timer() { Interval = 25 };
            ProgressTimer.Tick += ProgressTimer_Tick;
            toolStripProgressBar1.Visible = true;
            ProgressTimer.Start();

            SearchTask = new Task(new Action(Search));
            SearchTask.Start();
        }

        public void ApplyStyle()
        {
            Style.Apply(this);
            Style.Apply(dataGridView1);
            Style.Apply(statusStrip1);
        }

        private bool Closing = false;
        private delegate void dGVInvokeHandler(List<Data.Trade> Trades);
        private void Search()
        {
            var Trades = Data.Trade.FindTrades(taskStatus, TradeFunction);

            if (Closing) return;

            if(dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new dGVInvokeHandler(dGVInvoke), Trades);
            }
        }
        void dGVInvoke(List<Data.Trade> Trades)
        {
            if (Closing) return;
            dataGridView1.DataSource = new SortableBindingList<Data.Trade>(Trades);
        }


        private List<Data.Trade> OldTradeList = null;
        void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (Closing) return;
            toolStripProgressBar1.Value = taskStatus.Progress;
            foundTradeRoutes.Text = string.Format("{0} found Routes", taskStatus.ProcessedObjects);
            if (taskStatus.Progress >= 100)
            {
                toolStripProgressBar1.Visible = false;
                ProgressTimer.Stop();
                toolStripSplitButton1.Visible = false;
                return;
            }

            if (taskStatus.Tag1 == null)
                return;

            if (OldTradeList == null)
            {
                OldTradeList = (List<Data.Trade>)taskStatus.Tag1;
                return;
            }

            if (((List<Data.Trade>)taskStatus.Tag1).Count != OldTradeList.Count)
            {
                var newTrades = (List<Data.Trade>)taskStatus.Tag1;
                map1.Routes.Clear();
                foreach (var trade in newTrades)
                    map1.Routes.Add(trade.Route);
                map1.Refresh();

                dataGridView1.DataSource = new SortableBindingList<Data.Trade>(newTrades);
                OldTradeList = (List<Data.Trade>)taskStatus.Tag1;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Closing) return;
            var dgvSender = (DataGridView)sender;
            if (dgvSender.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var tTrade = (Data.Trade)dgvSender.Rows[e.RowIndex].DataBoundItem;
                if (tTrade == null) return;

                if(e.ColumnIndex == 0)
                {
                    new RouteViewer(tTrade.Route).Show();
                    return;
                }

                Data.System tSystem = null;
                if(dgvSender.Columns[e.ColumnIndex].HeaderText == "Start")
                {
                    tSystem = tTrade.Steps[0].System;
                }
                else // End
                {
                    tSystem = tTrade.Steps[tTrade.Steps.Count-1].System;
                }

                if (tSystem != null)
                    new Systems.Main(tSystem).Show();
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskStatus.CancelRequest = true;
        }

        private void TradeResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            Closing = true;
            taskStatus.CancelRequest = true;
            ProgressTimer.Stop();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (TextBox.Text == "")
                splitContainer1.Panel1Collapsed = true;
            else
                splitContainer1.Panel1Collapsed = false;
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public static void AppendText(this RichTextBox box, string text, Color color, float Size)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            var defSize = box.SelectionFont.Size;
            box.SelectionFont = new Font(box.SelectionFont.FontFamily, Size);
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionFont = new Font(box.SelectionFont.FontFamily, defSize);
        }
    }
}
