using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SolutionsService.Models.ResponseModels
{
    public class StepResponse
    {
        public string CoverImage { get; set; }
        public string Description { get; set; }
    }
}
