using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit
{
    public class ProcessActionLog : KitActionLog
    {
        public string PROCESS_LOGGED { get; set; }
        public string USER { get; set; }
    }
}
