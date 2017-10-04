using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    public class Station
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "system_id")]
        public int System_ID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "max_landing_pad_size")]
        public string Max_landing_pad_size { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "distance_to_star")]
        public int Distance_to_Star { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "controlling_minor_faction_id")]
        public int FactionID { get; set; }
        
        public Faction Faction { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "government")]
        public string Government { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "allegiance")]
        public string Allegiance { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_blackmarket")]
        public bool HasBlackmarket { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_commodities")]
        public bool HasCommodities { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_refuel")]
        public bool HasRefuel { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_repair")]
        public bool HasRepair { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_rearm")]
        public bool HasRearm { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_outfitting")]
        public bool HasOutfitting { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "has_shipyard")]
        public bool HasShipyard { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "import_commodities")]
        public string[] ImportCommodities { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "export_commodities")]
        public string[] ExportCommodities { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "prohibited_commodities")]
        public string[] ProhibitedCommodities { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "economies")]
        public string[] Economies { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "updated_at")]
        public int UpdatedAt { get; set; }

        public string Note { get; set; }

        /// <summary>
        /// Distance to closest star
        /// </summary>
        public double Distance { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
