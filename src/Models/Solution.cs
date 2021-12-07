using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolutionsService.Models.ResponseModels;

namespace SolutionsService.Models
{
    public abstract class Solution
    {
        protected Solution()
        {
            this.SDGs = new HashSet<SDGSolution>();
            this.Likes = new HashSet<Like>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WeatherExtreme { get; set; }
        public string HeaderImageURL { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UploadDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime LastUpdatedTime { get; set; }
        public int ViewCount { get; set; }
        public virtual ICollection<SDGSolution> SDGs { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public abstract SolutionResponse ConvertToResponseModel();
    }
}
