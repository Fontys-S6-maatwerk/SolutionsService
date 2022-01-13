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

        public SolutionsServiceContext()
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<HowTo> HowTos { get; set; }
        public DbSet<SDG> SDGs { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Step> Steps { get; set; }
        public virtual DbSet<Solution> Solutions { get; set; }
        public virtual DbSet<SDGSolution> SDGSolutions { get; set; }

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
            modelBuilder.Entity<SDGSolution>().ToTable("SDGSolutions");
            modelBuilder.Entity<SDGSolution>().HasKey(i => new { i.SDGId, i.SolutionId });

            modelBuilder.Entity<SDG>().HasData(
                new SDG { Name = "No poverty", SDGNumber = 1, Id = Guid.NewGuid() },
                new SDG { Name = "Zero hunger", SDGNumber = 2, Id = Guid.NewGuid() },
                new SDG { Name = "Good health and well-being", SDGNumber = 3, Id = Guid.NewGuid() },
                new SDG { Name = "Quality education", SDGNumber = 4, Id = Guid.NewGuid() },
                new SDG { Name = "Gender equality", SDGNumber = 5, Id = Guid.NewGuid() },
                new SDG { Name = "Clean water and sanitation", SDGNumber = 6, Id = Guid.NewGuid() },
                new SDG { Name = "Affordable and clean energy", SDGNumber = 7, Id = Guid.NewGuid() },
                new SDG { Name = "Decent work and economic growth", SDGNumber = 8, Id = Guid.NewGuid() },
                new SDG { Name = "Industry, innovation and infrastructure", SDGNumber = 9, Id = Guid.NewGuid() },
                new SDG { Name = "Reducted inequalities", SDGNumber = 10, Id = Guid.NewGuid() },
                new SDG { Name = "Sustainable cities and communities", SDGNumber = 11, Id = Guid.NewGuid() },
                new SDG { Name = "Responsible consumption and production", SDGNumber = 12, Id = Guid.NewGuid() },
                new SDG { Name = "Climate action", SDGNumber = 13, Id = Guid.NewGuid() },
                new SDG { Name = "Life below water", SDGNumber = 14, Id = Guid.NewGuid() },
                new SDG { Name = "Life on land", SDGNumber = 15, Id = Guid.NewGuid() },
                new SDG { Name = "Peace justice and strong institutions", SDGNumber = 16, Id = Guid.NewGuid() },
                new SDG { Name = "Partnerships for the goals", SDGNumber = 17, Id = Guid.NewGuid() }
                );
        }
    }
}
