using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.ResponseModels
{
    public class StepResponseModel
    {
        public Guid Id { get; set; }
        public string CoverImage { get; set; }
        public string Description { get; set; }
    }
}
