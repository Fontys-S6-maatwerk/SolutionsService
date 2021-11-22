using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsService.Models
{
    public class SDGSolution
    {
        [JsonIgnore]
        public Guid SolutionId { get; set; }
        [JsonIgnore]
        public Solution Solution { get; set; }

        [JsonIgnore]
        public Guid SDGId { get; set; }
        public SDG SDG { get; set; }
    }
}
