using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate
{
    public class KitTemplateModel
    {
        public Guid Id { get; set; }
        public int StartQty { get; set; }
        public string WorkOrder { get; set; }
        public string PartNumber { get; set; }

    }
}
