using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MvcRefactor.Data.Implementation
{
    public class Repository<TObject> : IRepository<TObject> 
        where TObject : class
    {
        protected MvcBasContext Context;
        private bool shareContext = false;

        /// <summary>
        /// 
        /// </summary>
        public Repository()
        {
            Context = new MvcBasContext();
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return Context.Set<TObject>();
            }
        }

        public void Dispose()
        {
            if (shareContext && (Context != null))
                Context.Dispose();
        }

        public IQueryable<TObject> All()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public IQueryable<TObject> Filter<Key>(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? DbSet.Where(filter).AsQueryable() :
                DbSet.AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) :
                _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public TObject Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public TObject Create(TObject t)
        {
            var newEntry = DbSet.Add(t);
            if (!shareContext)
                Context.SaveChanges();
            return newEntry;
        }
     
        public int Update(TObject t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public int Delete(TObject t)
        {
            DbSet.Remove(t);
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }
    }
}
