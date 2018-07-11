﻿using System.Data.Entity;
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
    }
}