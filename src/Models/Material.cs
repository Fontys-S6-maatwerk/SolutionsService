﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SolutionsService.Models
{
    public class Material
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual HowTo Solution { get; set; }
    }
}
