using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.ResolutionDictionary
{
    public class Reason
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public List<ReasonCategory> Categories { get; set; }
    }
}
