using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Parameters
{
    public class SolutionParameters : QueryStringParameters
    {
        public string WeatherExtreme { get; set; }

        public string SDG { get; set; }

        public string Difficulty { get; set; }

        public int MinimumImpact { get; set; } = 0;

        public Guid AuthorId { get; set; }

        public long MimimalViewCount { get; set; } = 0;

        public int MinimalAmountOfLikes { get; set; } = 0;

        public SolutionParameters()
        {
            OrderBy = "UploadDate";
        }
    }
}
