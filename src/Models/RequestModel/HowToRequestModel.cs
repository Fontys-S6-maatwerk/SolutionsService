using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.RequestModel
{
    public class HowToRequestModel : SolutionRequestModel
    {
        public string Introduction { get; set; }
        public string Difficulty { get; set; }
        public List<string> Tools { get; set; }
        public List<string> Materials { get; set; }
        public List<StepRequestModel> Steps { get; set; }
    }
}
