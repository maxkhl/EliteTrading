using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    public class Distance
    {
        private double Value;

        public Distance(double Value)
        {
            this.Value = Value;
        }
        public override string ToString()
        {
            return string.Format("{0:n2} Ly", Value);
        }

        public static explicit operator double(Distance b)
        {
            return b.Value;
        }
        public static Distance operator +(Distance c1, Distance c2)
        {
            return new Distance((double)c1 + (double)c2);
        }
        public static Distance operator -(Distance c1, Distance c2)
        {
            return new Distance((double)c1 - (double)c2);
        }

    }
}
