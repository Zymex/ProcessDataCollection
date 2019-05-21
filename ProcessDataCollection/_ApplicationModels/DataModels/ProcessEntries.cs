using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels
{
    public class ProcessEntries
    {
        public ProcessEntries()
        {
            DateAdded = DateTime.Now;
        }
        public DateTime DateAdded { get; set; }
        public int Id { get; set; }
        public int In { get; set; }
        public int Out { get; set; }
        public string OperatorId { get; set; }
        public int ProcessId { get; set; }
        public List<ProcessItems> ProcessItems { get; set; }
    }
}
