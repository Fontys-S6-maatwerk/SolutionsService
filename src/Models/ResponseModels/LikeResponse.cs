using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.ResponseModels
{
    public class LikeResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
