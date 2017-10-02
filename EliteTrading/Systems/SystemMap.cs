using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace EliteTrading.Systems
{
    public partial class SystemMap : Form
    {
        public SystemMap()
        {
            InitializeComponent();
            map1.InitializeMap();
            map1.OnVisibleSystemsChanged += map1_OnVisibleSystemsChanged;
            var path = Pathfinder.PathFinder.FindPath(UserData.System, GlobalData.Systems[0]);

            Data.Route testRoute = new Data.Route();
            while (path.next != null)
            {
                testRoute.AddDirect(path.System);
                path = path.next;
            }
            map1.Routes.Add(testRoute);
            map1.Refresh();
        }

        void map1_OnVisibleSystemsChanged(int Amount)
        {
            l_visibleSystems.Text = String.Format("{0} Systems visible", Amount.ToString());
        }
    }
}
