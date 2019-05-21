﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessDataCollection._ApplicationModels.DataModels.AdminModels.Process
{
    public class ProcessDefinitions
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
