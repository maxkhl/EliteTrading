using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading.Data
{
    public class Route
    {
        public List<RouteStep> Steps { get; private set; }
        public RouteStep LastStep
        {
            get
            {
                if (Steps.Count <= 0)
                    return new RouteStep() { System = UserData.System, Distance = new Distance(0) };
                else
                    return Steps[Steps.Count - 1];
            }
        }

        public Route()
        {
            Steps = new List<RouteStep>();
        }

        public static Route Calculate(System Start, System End)
        {
            var path = Pathfinder.PathFinder.FindPath(Start, End);

            if (path == null) return null;
            Data.Route retRoute = new Data.Route();
            while (path.next != null)
            {
                retRoute.AddDirect(path.System);
                path = path.next;
            }
            retRoute.AddDirect(End);
            return retRoute;
        }

        public bool AddTarget(System System, int JumpCount = 0)
        {
            return AddTarget(System, null, JumpCount);
        }
        public bool AddTarget(System System, Station Station, int JumpCount = 0)
        {
            if (System == LastStep.System && Station == LastStep.Station) return true;

            var path = Pathfinder.PathFinder.FindPath(LastStep.System, System, JumpCount);

            if (path == null) return false;

            Data.Route retRoute = new Data.Route();
            while (path.next != null)
            {
                AddDirect(path.System);
                path = path.next;
            }

            AddDirect(System, Station);

            return true;
        }

        public void AddDirect(System System, Station Station)
        {
            Steps.Add(new RouteStep()
            {
                System = System,
                Station = Station,
                Distance = new Distance(Steps.Count == 0 ? (UserData.System.Coordinates - System.Coordinates).Length : (Steps[Steps.Count - 1].System.Coordinates - System.Coordinates).Length),
            });
        }

        public void AddDirect(System System)
        {
            Steps.Add(new RouteStep()
            {
                System = System,
                Distance = new Distance(Steps.Count == 0 ? (UserData.System.Coordinates - System.Coordinates).Length : (Steps[Steps.Count - 1].System.Coordinates - System.Coordinates).Length),
            });
        }

        public override string ToString()
        {
            Distance overalDistance = new Distance(0);
            for (int i = 1; i < Steps.Count; i++)
                overalDistance += Steps[i].Distance;
            return overalDistance.ToString();
        }


        public class RouteStep
        {
            public System System { get; set; }
            public Station Station { get; set; }
            public Distance Distance { get; set; }
        }
    }
}
