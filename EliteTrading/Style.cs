using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EliteTrading
{
    public static class Style
    {
        public static void Apply(Form control, StyleType type)
        {
            switch(type)
            {
                case StyleType.Default:
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                    break;
                case StyleType.Elite:
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.DarkOrange;
                    break;
                case StyleType.Contrast:
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.White;
                    break;
            }
        }
        public static void Apply(MenuStrip control, StyleType type)
        {
            switch (type)
            {
                case StyleType.Default:
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                    break;
                case StyleType.Elite:
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.DarkOrange;
                    break;
                case StyleType.Contrast:
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.White;
                    break;
            }
        }
        public static void Apply(DataGridView control, StyleType type)
        {
            switch (type)
            {
                case StyleType.Default:
                    var cellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = SystemColors.Control,
                        ForeColor = SystemColors.ControlText,
                        SelectionBackColor = SystemColors.Highlight,
                        SelectionForeColor = SystemColors.HighlightText,
                    };
                    control.ColumnHeadersDefaultCellStyle = cellStyle;
                    control.DefaultCellStyle = cellStyle;
                    control.RowHeadersDefaultCellStyle = cellStyle;
                    control.RowsDefaultCellStyle = cellStyle;
                    control.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
                    control.BackColor = SystemColors.Control;
                    control.BackgroundColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                    control.GridColor = SystemColors.ControlText;
                    break;
                case StyleType.Elite:
                    cellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = Color.Black,
                        ForeColor = Color.DarkOrange,
                        SelectionBackColor = Color.DimGray,
                        SelectionForeColor = Color.Orange,
                    };
                    control.ColumnHeadersDefaultCellStyle = cellStyle;
                    control.DefaultCellStyle = cellStyle;
                    control.RowHeadersDefaultCellStyle = cellStyle;
                    control.RowsDefaultCellStyle = cellStyle;
                    control.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    control.BackColor = Color.Black;
                    control.BackgroundColor = Color.Black;
                    control.ForeColor = Color.DarkOrange;
                    control.GridColor = Color.Orange;
                    break;
                case StyleType.Contrast:
                    cellStyle = new DataGridViewCellStyle()
                    {
                        BackColor = Color.Black,
                        ForeColor = Color.White,
                        SelectionBackColor = Color.DimGray,
                        SelectionForeColor = Color.LightGray,
                    };
                    control.ColumnHeadersDefaultCellStyle = cellStyle;
                    control.DefaultCellStyle = cellStyle;
                    control.RowHeadersDefaultCellStyle = cellStyle;
                    control.RowsDefaultCellStyle = cellStyle;
                    control.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    control.BackColor = Color.Black;
                    control.BackgroundColor = Color.Black;
                    control.ForeColor = Color.White;
                    control.GridColor = Color.RoyalBlue;
                    break;
            }
        }
        public static void Apply(StatusStrip control, StyleType type)
        {
            switch (type)
            {
                case StyleType.Default:
                    control.BackColor = SystemColors.Control;
                    control.ForeColor = SystemColors.ControlText;
                    break;
                case StyleType.Elite:
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.DarkOrange;
                    break;
                case StyleType.Contrast:
                    control.BackColor = Color.Black;
                    control.ForeColor = Color.White;
                    break;
            }
        }


        public static void Apply(object Control)
        {
            if (Control == null) return;

            if(typeof(Form).IsAssignableFrom(Control.GetType()))
                Apply((Form)Control, UserData.Style);
            if (typeof(MenuStrip).IsAssignableFrom(Control.GetType()))
                Apply((MenuStrip)Control, UserData.Style);
            if (typeof(DataGridView).IsAssignableFrom(Control.GetType()))
                Apply((DataGridView)Control, UserData.Style);
            if (typeof(StatusStrip).IsAssignableFrom(Control.GetType()))
                Apply((StatusStrip)Control, UserData.Style);
        }
    }

    [Serializable]
    public enum StyleType
    {
        Default,
        Elite,
        Contrast
    }
}
