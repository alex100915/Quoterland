using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyApplication.Core.Models;

namespace MyApplication.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Learned> Learneds { get; set; }
        public DbSet<Learning> Learnings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UpvotedComments> UpvotedComents { get; set; }
        public DbSet<Genre> Genres { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Learned>().HasRequired(l => l.ApplicationUser).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Learning>().HasRequired(l => l.ApplicationUser).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}