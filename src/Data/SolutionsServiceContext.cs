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
        public DbSet<Article> Articles { get; set; }
        public DbSet<HowTo> HowTos { get; set; }
        public DbSet<SDG> SDGs { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Solution> Solutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<HowTo>().ToTable("HowTos");
            modelBuilder.Entity<SDG>().ToTable("SDGs");
            modelBuilder.Entity<Like>().ToTable("Likes");
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<Tool>().ToTable("Tools");
            modelBuilder.Entity<Step>().ToTable("Steps");
            modelBuilder.Entity<Solution>().ToTable("Solutions");
        }
    }
}
