using MyApplication.Core.Repositories;

namespace MyApplication.Core
{
    public interface IUnitOfWork
    {
        IQuoteRepository Quotes { get; }
        ILearnedRepository Learneds { get; }
        ILearningRepository Learnings { get; }
        IMovieRepository Movies { get; }
        IProductionTypeRepository ProductionTypes { get; }
        IGenreRepository Genres { get; }
        IApplicationUserRepository ApplicationUsers { get; }
        ICommentRepository Comments { get; }
        IUpvotedCommentRepository UpvotedComments { get;}

        void Complete();
    }
}