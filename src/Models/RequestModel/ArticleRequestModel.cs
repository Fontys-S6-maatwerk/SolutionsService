using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.RequestModel
{
    public class ArticleRequestModel : SolutionRequestModel
    {
        public string Content { get; set; }
    }
}
