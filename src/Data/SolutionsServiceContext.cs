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

        public DbSet<Solution> Solutions { get; set; }
        public DbSet<SDG> SDGs { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Step> Steps { get; set; }
    }
}
