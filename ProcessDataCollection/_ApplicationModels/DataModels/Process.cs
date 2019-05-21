using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels
{
    public class Process
    {
        public int Id { get; set; }
        public Guid KitId { get; set; }
        public int StepOrder { get; set; }
        public string ProcessName { get; set; }
        public int In { get; set; }
        public int InCount { get; set; }
        public int ReworkQty { get; set; }
        public int ScrapQty { get; set; }
        public string WorkOrder { get; set; }
        public string PartNumber { get; set; }
        public List<ProcessEntries> ProcessEntries { get; set; }

    }
}
