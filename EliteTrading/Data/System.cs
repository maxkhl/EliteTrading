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
    public class System
    {
        public int id { get; set; }
        public string name { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public string faction { get; set; }
        public Int64 population { get; set; }
        public string government { get; set; }
        public string allegiance { get; set; }
        public string state { get; set; }
        public string security { get; set; }
        public string primary_economy { get; set; }
        public bool needs_permit { get; set; }
        public int updated_at { get; set; }
        public string power_control_faction { get; set; }
        public string note { get; set; }

        public int StationAmount
        { 
            get
            {
                return Stations.Count;
            }
        }


        public List<Station> Stations { get; private set; }
        public Vector3 Coordinates 
        {
            get
            {
                return new Vector3(x, y, z);
            }            
        }

        /// <summary>
        /// Gets the distance to SOL.
        /// </summary>
        /// <value>
        /// The distance to SOL.
        /// </value>
        public double DistanceToSol
        {
            get
            {
                return Math.Round(Coordinates.Length, 2);
            }
        }

        public System()
        {
            Stations = new List<Station>();
        }

        public System(string Name, Vector3 Coordinates)
        {
            this.name = Name;
            this.x = Coordinates.X;
            this.y = Coordinates.Y;
            this.z = Coordinates.Z;
            Stations = new List<Station>();
        }

        public void ParseNote()
        {
            switch(power_control_faction)
            {
                case "Zachary Hudson":
                    note += "10% Weapons discount";
                    note += " + Shipyard has Vulture, Eagle & Dropship";
                    break;
                case "Li Yong-Rui":
                    note += "15% Ship/Outfitting Discount + High-tech 10% boost";
                    break;
                case "Felicia Winters":
                    note += "300% production/consumption food/basic medicine";
                    break;
                case "Arissa Lavigny-Duval":
                    note += "Fines/Bounties doubled + no Black Markets";
                    break;
                case "Denton Patreus":
                    note += "Imperial Slaves legal + 10% Imperial Ships discount";
                    break;
                case "Zemina Torval":
                    note += "10% Imperial Slaves discount + 10% mined material discount + Shipyard has imerpial ships";
                    break;
                case "Aisling Duval":
                    note += "Production/consumption high value goods increased + 10% bonus on high-value goods";
                    break;
                case "Edmund Mahon":
                    note += "20% hull reinforcement & cargo racks discount + 400% production/consumption agri goods/equipment + 5% price increase agri goods/equipment";
                    break;
                case "Archon Delaine":
                    note += "Production/consumption boost for narcotics & weapons + Black Markets everyhwere + Black Markets 15% better prices";
                    break;
                case "Pranav Antal":
                    note += "No Black Markets + Slaves/Narcotics/non-basic Medicine banned";
                    break;
            }

            if (primary_economy == "High Tech")
            {
                if (note != "")
                    note += " + ";
                note += "more Ships/Outfitting";
            }
        }

        /// <summary>
        /// Gets the distance from this system to the target system.
        /// </summary>
        /// <param name="Target">The target system.</param>
        /// <returns>The distance in Ls</returns>
        public double GetDistanceTo(System Target)
        {
            return (this.Coordinates - Target.Coordinates).Length;
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
