using System;
using System.Collections.Generic;
using System.Linq;
using MvcRefactor.Data;
using MvcRefactor.Entity;
using MvcRefactor.Logging;

namespace MvcRefactor.Service.Implementation
{
    public class UserService : IUserService, IDisposable
    {

        private readonly ILogger _logService = new FileLogManager(typeof(UserService));

        private IDALContext context;
        public UserService(IDALContext dal)
        {
            context = dal;
        }
        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

       /// <summary>
        /// Return 1: New User has succeeded to register.
        /// Return 0: Has exception
        /// Return 2: UserName or Email is already in system.
       /// </summary>
       /// z
       /// <param name="user"></param>
       /// <returns></returns>
        public int Register(User user)
        {
            if (CheckUser(user))
            {
                try
                {
                    context.Users.Create(user);
                    context.SaveChanges();
                    return 0;
                }
                catch (Exception exception)
                {
                    _logService.LogError("Function Register: {0}", exception);
                    return 2;
                }
            }
            return 1;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.All().ToList();
        }

        public User GetById(int id)
        {
            return context.Users.All().FirstOrDefault(x => x.UserId == id);
        }

        public User Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
            return user;
        }

        public bool Delete(User user)
        {
            context.Users.Delete(user);
            context.SaveChanges();
            return true;
        }

        public bool CheckUser(User user)
        {
            if (user == null) return false;
            var check = context.Users.All().FirstOrDefault(x => x.UserName == user.UserName || x.Email == user.Email);
            return check != null;
        }
    }
}
