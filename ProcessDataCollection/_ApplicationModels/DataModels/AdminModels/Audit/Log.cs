using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Audit
{
    public class Log
    {
        public Log()
        {
            DATE_LOGGED = DateTime.Now;
        }
        [Key]
        public int LOG_ID { get; set; }
        public DateTime DATE_LOGGED { get; set; }
        public string ACTION_INITIATED { get; set; }
    }
}
