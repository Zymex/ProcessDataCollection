using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels
{
    public class Kit
    {
        public Kit()
        {
            DateAdded = DateTime.Now;
            Opened = true;
        }
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string WorkOrder { get; set; }
        public string PartNumber { get; set; }
        public bool? FirstBuild { get; set; }
        public bool Opened { get; set; }
        public int StartQty { get; set; }
        public string Comment { get; set; }
        public List<Process> Processes { get; set; }
    }
}
