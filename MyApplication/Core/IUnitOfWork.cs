using MyApplication.Core.Repositories;

namespace MyApplication.Core
{
    public interface IUnitOfWork
    {
        IQuoteRepository Quotes { get; }
        ILearnedRepository Learneds { get; }
        ILearningRepository Learnings { get; }
        IMovieRepository Movies { get; }

        void Complete();
    }
}