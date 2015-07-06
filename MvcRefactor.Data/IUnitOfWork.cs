using System;
using MvcRefactor.Data.Implementation;

namespace MvcRefactor.Data
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }

    public interface IDALContext : IUnitOfWork
    {      
        IUserRepository Users { get; }
    }

    public class DALContext : IDALContext
    {
        private MvcBasContext dbContext;      
        private IUserRepository user;

        public DALContext()
        {
            dbContext = new MvcBasContext();
        }

        public IUserRepository Users
        {
            get { return user ?? (user = new UserRepository(dbContext)); }
        }

        public int SaveChanges()
        {           
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {         
            if (dbContext != null)
                dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
