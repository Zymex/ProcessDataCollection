using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit
{
    public class UserActionLog : Log
    {
        public string USER_LOGGED { get; set; }
    }
}
