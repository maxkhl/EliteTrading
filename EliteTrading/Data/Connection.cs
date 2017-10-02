using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    struct Connection
    {
        public Station StationA;
        public Station StationB;
        public float Distance;

        public Connection(Station A, Station B, float Distance)
        {
            this.StationA = A;
            this.StationB = B;
            this.Distance = Distance;
        }
    }
}
