using Microsoft.EntityFrameworkCore;
using Nzh.Frame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Repository.EF
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
          : base(options)
        { }
        public DbSet<Demo> Demo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demo>().ToTable("Demo", "dbo");
        }
    }
}
