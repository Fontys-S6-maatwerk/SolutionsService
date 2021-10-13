using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SolutionsService.Models
{
    public class Solution
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string WeatherExtreme { get; set; }
        public string SolutionType { get; set; }
        public string HeaderImageURL { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public List<string> SDGTypes { get; set; }
        public string Difficulty { get; set; }
        public string ImpactGoal { get; set; }
        public string CurrentImpact { get; set; }
        public long AuthorId { get; set; }
        public List<long> Reactions { get; set; }
        public DateTime UploadDate { get; set; }
        public long ViewCount { get; set; }
    }
}
