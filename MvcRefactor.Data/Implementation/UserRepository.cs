using MvcRefactor.Entity;

namespace MvcRefactor.Data.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private MvcBasContext _context;

        public UserRepository(MvcBasContext context)
        {
            this._context = context;
        }

        public string GetUrl()
        {
            //TODO: testing
            return string.Empty;
        }      
    }
}
