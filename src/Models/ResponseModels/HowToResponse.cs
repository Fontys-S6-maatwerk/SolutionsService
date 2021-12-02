using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models.ResponseModels
{
    public class HowToResponse : SolutionResponse
    {
        public string Introduction { get; set; }
        public string Difficulty { get; set; }
        public List<string> Materials { get; set; }
        public List<string> Tools { get; set; }
        public List<StepResponse> Steps { get; set; }
    }
}
