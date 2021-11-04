﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models
{
    public class Like
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public Solution Solution { get; set; }
    }
}