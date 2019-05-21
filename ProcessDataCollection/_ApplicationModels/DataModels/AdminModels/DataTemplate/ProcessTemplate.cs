using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.DataTemplate
{
    public class ProcessTemplate
    {
        [Key]
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public int StepOrder { get; set; }
        public Guid KitTemplateId { get; set; }
    }
}
