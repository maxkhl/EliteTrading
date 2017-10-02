using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTrading.Pathfinder
{
    /// <summary>
    /// Author: Roy Triesscheijn (http://www.roy-t.nl)
    /// Class defining BreadCrumbs used in path finding to mark our routes
    /// </summary>
    public class SearchNode
    {
        public Data.System System;
        public int cost;
        public int pathCost;
        public SearchNode next;
        public SearchNode nextListElem;

        public SearchNode(Data.System System, int cost, int pathCost, SearchNode next)
        {
            this.System = System;
            this.cost = cost;
            this.pathCost = pathCost;
            this.next = next;
        }
    }
}
