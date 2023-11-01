using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class PoemContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Poem-Project;Trusted_Connection=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Poem> Poems { get; set; }
        public DbSet<PoemScore> PoemScores { get; set; }
        public DbSet<PoemGetScore> PoemGetScore { get; set; }

    }
}
