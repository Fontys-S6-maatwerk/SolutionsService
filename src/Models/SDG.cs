using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SolutionsService.Models
{
    public class SDG
    {
        public SDG()
        {
            this.Solutions = new HashSet<SDGSolution>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SDGNumber { get; set; }
        [JsonIgnore]
        public virtual ICollection<SDGSolution> Solutions { get; set; }

        public override bool Equals(object obj)
        {
            SDG other = obj as SDG;
            if (other == null)
            {
                return false;
            }
            return other.Name == Name && other.SDGNumber == SDGNumber; 
        }
    }
}
