using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolutionsService.Models;

namespace SolutionsService.Data
{
    public class SolutionsServiceContext : DbContext
    {
        public SolutionsServiceContext (DbContextOptions<SolutionsServiceContext> options)
            : base(options)
        {
        }

        public DbSet<SolutionsService.Models.Solution> Solution { get; set; }
    }
}
