using System.Data.Entity;
using MyApplication.Core.Models;

namespace MyApplication.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Quote> Quotes { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Learned> Learneds { get; set; }
        DbSet<Learning> Learnings { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        DbSet<ProductionType> ProductionTypes { get; set; }
        DbSet<Genre> Genres { get; }
        DbSet<Comment> Comments { get; }
        DbSet<UpvotedComment> UpvotedComments { get; set; }
    }
}