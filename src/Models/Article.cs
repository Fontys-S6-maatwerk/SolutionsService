using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolutionsService.Models
{
    public class Article : Solution
    {
        public Article() : base()
        {
        }

        public string Content { get; set; }
    }
}
