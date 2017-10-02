using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EliteTrading.Data
{
    public class Commodity
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int ID { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "average_price")]
        public int AveragePrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "category")]
        public CommodityCategory Category { get; set; }

        public override string ToString()
        {
            return Name;
        }

        //[Newtonsoft.Json.JsonProperty(PropertyName = "category")]
        //public List<Newtonsoft.Json.> Category { get; set; }

        public static List<Commodity> Load(FileInfo CommodityFile)
        {
            var Commodities = new List<Commodity>();
            using (var sreader = new StreamReader(CommodityFile.FullName))
            {
                string sjson = sreader.ReadToEnd();
                sjson = sjson.Replace("null", "0");
                var jArr = (Newtonsoft.Json.Linq.JArray)Newtonsoft.Json.JsonConvert.DeserializeObject(sjson);
                var Categories = new List<CommodityCategory>();
                foreach(var item in jArr)
                {
                    var newCom = new Commodity()
                    {
                        ID = (int)item["id"],
                        AveragePrice = (int)item["average_price"],
                        Name = (string)item["name"],
                    };
                    foreach (var subitem in item["category"])
                    {
                        var id = subitem.Parent.Value<int>("id");
                        var Target = Categories.Find(c => c.ID == id);
                        if (Target != null)
                            newCom.Category = Target;
                        else
                        {
                            newCom.Category = new CommodityCategory()
                            {
                                ID = id,
                                Name = (string)subitem.Parent["name"],
                            };
                            Categories.Add(newCom.Category);
                        }
                        newCom.Category.Commodities.Add(newCom);
                    }
                    Commodities.Add(newCom);
                }
                //Commodities = ;
            }
            return Commodities;
        }

        public static Commodity GetByName(string Name)
        {
            return GlobalData.Commodities.SingleOrDefault(e => e.Name.ToUpper() == Name.ToUpper());
        }
    }

    [Newtonsoft.Json.JsonArrayAttribute(true)]
    public class CommodityCategory : IComparable
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Commodity> Commodities = new List<Commodity>();

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }

    
}
