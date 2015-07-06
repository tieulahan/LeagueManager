using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public interface IPositionRepository : IRepository<Position>
    {
        string GetUrl();
    }
}
