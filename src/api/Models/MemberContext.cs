using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                        .HasKey(m => m.Id);
        }
    }
}