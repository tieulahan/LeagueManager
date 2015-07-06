using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface ILeagueRepository : IRepository<League>
    {
       string GetUrl();
    }
}
