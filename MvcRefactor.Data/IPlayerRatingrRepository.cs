using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface IPlayerRatingrRepository : IRepository<PlayerRating>
    {
        string GetUrl();
    }
}
