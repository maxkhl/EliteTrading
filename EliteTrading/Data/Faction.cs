using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using System.IO;

namespace EliteTrading.Data
{
    public class Faction
    {
        public int id { get; set; }
        public string name { get; set; }
        public string updated_at { get; set; }
        public int government_id { get; set; }
        public string government { get; set; }
        public int allegiance_id { get; set; }
        public string allegiance { get; set; }
        public int state_id { get; set; }
        public string state { get; set; }
        public int home_system_id { get; set; }
        public System home_system { get; set; }
        public bool is_player_faction { get; set; }

        public Faction()
        {

        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
