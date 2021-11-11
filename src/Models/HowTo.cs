using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models
{
    public class HowTo : Solution
    {
        public HowTo()
        {
            this.Materials = new HashSet<Material>();
            this.Tools = new HashSet<Tool>();
            this.Steps = new HashSet<Step>();
        }

        public string Introduction { get; set; }
        public string Difficulty { get; set; }
        [InverseProperty("Materials")]
        public ICollection<Material> Materials { get; set; }
        [InverseProperty("Tools")]
        public ICollection<Tool> Tools { get; set; }
        public ICollection<Step> Steps { get; set; }
    }
}
