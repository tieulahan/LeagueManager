using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface IRoleRepository : IRepository<Role>
    {
        string GetUrl();
    }
}
