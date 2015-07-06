using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface IPlayerRepository : IRepository<Player>
    {
        string GetUrl();
    }
}
