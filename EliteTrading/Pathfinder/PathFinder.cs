using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTrading.Pathfinder
{    
    /// <summary>
    /// Author: Roy Triesscheijn (http://www.roy-t.nl)
    /// Class providing 3D pathfinding capabilities using A*.
    /// Heaviliy optimized for speed therefore uses slightly more memory
    /// On rare cases finds the 'almost optimal' path instead of the perfect path
    /// this is because we immediately return when we find the exit instead of finishing
    /// 'neighbour' loop.
    /// </summary>
    public static class PathFinder
    {                   
        /// <summary>
        /// Method that switfly finds the best path from start to end.
        /// </summary>
        /// <returns>The starting breadcrumb traversable via .next to the end or null if there is no path</returns>        
        /*public static SearchNode FindPath(World world, Point3D start, Point3D end)
        {
            //note we just flip start and end here so you don't have to.            
            return FindPathReversed(world, end, start); 
        }        

        /// <summary>
        /// Method that switfly finds the best path from start to end. Doesn't reverse outcome
        /// </summary>
        /// <returns>The end breadcrump where each .next is a step back)</returns>
        private static SearchNode FindPathReversed(World world, Point3D start, Point3D end)
        {
            SearchNode startNode = new SearchNode(start, 0, 0, null);

            MinHeap openList = new MinHeap();            
            openList.Add(startNode);

            int sx = world.Right;
            int sy = world.Top;
            int sz = world.Back;
            bool[] brWorld = new bool[sx * sy * sz];
            brWorld[start.X + (start.Y + start.Z * sy) * sx] = true;

            while (openList.HasNext())
            {                
                SearchNode current = openList.ExtractFirst();

                if (current.position.GetDistanceSquared(end) <= 3)
                {
                    return new SearchNode(end, current.pathCost + 1, current.cost + 1, current);
                }

                for (int i = 0; i < surrounding.Length; i++)
                {
                    Surr surr = surrounding[i];
                    Point3D tmp = new Point3D(current.position, surr.Point);
                    int brWorldIdx = tmp.X + (tmp.Y + tmp.Z * sy) * sx;

                    if (world.PositionIsFree(tmp) && brWorld[brWorldIdx] == false)
                    {
                        brWorld[brWorldIdx] = true;
                        int pathCost = current.pathCost + surr.Cost;
                        int cost = pathCost + tmp.GetDistanceSquared(end);
                        SearchNode node = new SearchNode(tmp, cost, pathCost, current);
                        openList.Add(node);
                    }
                }
            }
            return null; //no path found
        }*/

        public static SearchNode FindPath(Data.System start, Data.System end, int MaxJumpCount = 0)
        {
            //note we just flip start and end here so you don't have to.            
            return FindPathReversed(end, start, MaxJumpCount);
        }
        private static SearchNode FindPathReversed(Data.System start, Data.System end, int MaxJumpCount = 0)
        {
            SearchNode startNode = new SearchNode(start, 0, 0, null);

            MinHeap openList = new MinHeap();
            openList.Add(startNode);

            bool[] brWorld = new bool[GlobalData.Systems.Count-1];

            brWorld[GlobalData.Systems.FindIndex(a=>a == start)] = true;

            int Jumps = 0;
            while (openList.HasNext())
            {
                if (MaxJumpCount > 0 && Jumps >= MaxJumpCount) return null;

                SearchNode current = openList.ExtractFirst();

                if ((current.System.Coordinates - end.Coordinates).Length <= 3)
                {
                    return new SearchNode(end, current.pathCost + 1, current.cost + 1, current);
                }

                var surroundings = surrounding(current.System);
                for (int i = 0; i < surroundings.Length; i++)
                {
                    Surr surr = surroundings[i];
                    int brWorldIdx = GlobalData.Systems.FindIndex(a => a == surr.System);

                    if (brWorld[brWorldIdx] == false)
                    {
                        brWorld[brWorldIdx] = true;
                        int pathCost = current.pathCost + surr.Cost;
                        int cost = pathCost + (int)(surr.System.Coordinates - end.Coordinates).Length;
                        SearchNode node = new SearchNode(surr.System, cost, pathCost, current);
                        openList.Add(node);
                        Jumps++;
                    }
                }
            }
            return null; //no path found
        }

        class Surr
        {
            public Surr(Data.System System)
            {
                this.System = System;
                Cost = 0;
            }

            public Data.System System;
            public int Cost;
        }

        //Neighbour options
        private static Surr[] surrounding(Data.System System)
        {
            return (from sSystem in GlobalData.Systems
                    where (System.Coordinates - sSystem.Coordinates).Length < UserData.Max_Jump_Distance
                    select new Surr(sSystem)).ToArray();
        }
    }           
}
