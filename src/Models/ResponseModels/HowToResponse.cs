using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.ResponseModels
{
    public class HowToResponse : ArticleResponse
    {
        public string Introduction { get; set; }
        public string Difficulty { get; set; }
        public List<MaterialResponse> Material { get; set; }
        public List<ToolResponse> Tools { get; set; }
        public List<StepResponseModel> Steps { get; set; }
    }
}
