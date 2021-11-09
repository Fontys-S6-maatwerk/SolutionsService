using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models
{
    public class Solution
    {
        public Solution()
        {
            this.SDGs = new HashSet<SDG>();
            this.Likes = new HashSet<Like>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WeatherExtreme { get; set; }
        public string SolutionType { get; set; }
        public virtual ICollection<SDG> SDGs { get; set; }
        public string HeaderImageURL { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Difficulty { get; set; }
        public string ImpactGoal { get; set; }
        public int CurrentImpact { get; set; }
        public Guid AuthorId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UploadDate { get; set; }
        public long ViewCount { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
