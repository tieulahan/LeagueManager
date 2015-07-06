using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface IUserRepository : IRepository<User>
    {
       string GetUrl();
    }
}
