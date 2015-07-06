using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface ITeamRepository : IRepository<Team>
    {
        string GetUrl();
    }
}
