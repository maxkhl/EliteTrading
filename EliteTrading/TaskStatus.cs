using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTrading
{
    public class TaskStatus
    {
        public int Progress = 0;
        public int ProcessedObjects = 0;
        public object Tag1 = null;
        public object Tag2 = null;
        public object Tag3 = null;
        public bool CancelRequest = false;
    }
}
