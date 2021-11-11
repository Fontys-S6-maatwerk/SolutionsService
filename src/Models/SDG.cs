using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolutionsService.Models
{
    public class SDG
    {
        public SDG()
        {
            this.Solutions = new HashSet<Solution>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SDGNumber { get; set; }
        public ICollection<Solution> Solutions { get; set; }
    }
}
