using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApplication.Core;
using MyApplication.Core.Models;
using MyApplication.Core.Repositories;
using MyApplication.Persistence.Repositories;

namespace MyApplication.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IQuoteRepository Quotes { get; private set; }
        public ILearnedRepository Learneds { get; private set ; }
        public ILearningRepository Learnings { get; private set; }
        public IMovieRepository Movies { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Quotes=new QuoteRepository(_context);
            Learneds=new LearnedRepository(_context);
            Learnings=new LearningRepository(_context);
            Movies=new MovieRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}