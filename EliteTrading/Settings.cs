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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = UserSettings.Default;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserSettings.Default.Save();
            UserData.Load();
        }
    }
}
