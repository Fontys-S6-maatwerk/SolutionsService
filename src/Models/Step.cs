using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models
{
    public class Step
    {
        [Key]
        public Guid Id { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
        public virtual HowTo Solution { get; set; }
    }
}
