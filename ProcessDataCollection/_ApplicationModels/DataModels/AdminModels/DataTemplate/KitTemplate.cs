using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate
{
    public class KitTemplate
    {
        public KitTemplate()
        {
            TemplateId = Guid.NewGuid(); ;
        }
        //From this we will create a new Kit prepopluated with the processes and Qty listed.
        [Key]
        public Guid TemplateId { get; set; }
        public string TemplateName { get; set; }
        public List<ProcessTemplate> ProcessTemplate { get; set; }
    }
}
