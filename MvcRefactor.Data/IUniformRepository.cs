using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface IUniformRepository : IRepository<Uniform>
    {
        string GetUrl();
    }
}
