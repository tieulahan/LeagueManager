using System.Collections.Generic;
using MvcRefactor.Data;
using MvcRefactor.Entity;

namespace MvcRefactor.Service
{
    public interface IUserService
    {
        int Register(User content);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Update(User user);
    }
}
