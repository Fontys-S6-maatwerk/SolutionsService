using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Parameters
{
    public class SolutionParameters : QueryStringParameters
    {
        public string Name { get; set; }

        public List<string> SolutionTypes { get; set; }

        public List<string> WeatherExtremes { get; set; }

        public List<string> SDGs { get; set; }

        public string Language { get; set; }

        //public Guid AuthorId { get; set; }

        //public long MimimalViewCount { get; set; } = 0;

        //public int MinimalAmountOfLikes { get; set; } = 0;

        public SolutionParameters()
        {
            OrderBy = "UploadDate";
        }
    }
}
