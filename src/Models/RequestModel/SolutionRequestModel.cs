using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.RequestModel
{
    public abstract class SolutionRequestModel
    {
        public string Name { get; set; }
        public string WeatherExtreme { get; set; }
        public string HeaderImageUrl { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> SDGIds { get; set; }
    }
}
