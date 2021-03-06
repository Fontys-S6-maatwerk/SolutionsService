using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.ResponseModels
{
    public class SolutionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WeatherExtreme { get; set; }
        public string HeaderImageURL { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastUpdatedTime { get; set; }
        public int ViewCount { get; set; }
        public List<SDGResponse> SDGs { get; set; }
        public int Likes { get; set; }
    }
}
