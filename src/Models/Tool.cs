using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models
{
    public class Tool
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual HowTo Solution { get; set; }
    }
}
