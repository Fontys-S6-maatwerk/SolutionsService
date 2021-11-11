using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionsService.Models.ResponseModels
{
    public class SDGResponse
    {
        public Guid Id { get; set; }
        public int SDGNumber { get; set; }
        public string Name { get; set; }
    }
}
