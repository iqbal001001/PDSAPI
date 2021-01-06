using PDS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PDS.Data
{
    public abstract class RepositoryBase<T> where T : class, IData
    {
        private DbContext _context;
        private IDbSet<T> _dbSet;

        protected RepositoryBase()
        {
            Context.Configuration.LazyLoadingEnabled = true;
            _dbSet = Context.Set<T>();
        }

        protected DbContext Context
        {
            get { return _context ?? (_context = PDSDBContextFactory.Get()); }
        }

        public IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> path, Expression<Func<T, bool>> filter)
        {
            return _dbSet.Include(path).Where(filter);
        }

        public IQueryable<T> Includes(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
                var query = _dbSet;
                return includes
                    .Aggregate(
                        query.AsQueryable(),
                        (current, include) => current.Include(include)
                    )
                    .Where(filter);
        }

        //public IQueryable<T> Includes( params Expression<Func<T, object>>[] includes)
        //{
        //    var query = _dbSet;
        //    return includes
        //        .Aggregate(
        //            query.AsQueryable(),
        //            (current, include) => current.Include(include)
        //        )
        //        .Where(filter);
        //}
        public IQueryable<T> Filter(Expression<Func<T, bool>> filter)
        {
            var query = _dbSet;
            return   query
                .Where(filter);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public IQueryable<T> Get()
        {
            return _dbSet;
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void DeleteChild(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.Entry(entityToUpdate).Property(x => x.CreatedOn).IsModified = false;
            Context.Entry(entityToUpdate).Property(x => x.CreatedBy).IsModified = false;

            var properties = entityToUpdate.GetType()
                 .GetProperties()
                 .Where(p => typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                         && !typeof(string).IsAssignableFrom(p.PropertyType)
                         && p.CanRead && p.GetGetMethod() != null
                         && p.GetIndexParameters().Length == 0);

            foreach (var property in properties)
            {
                if (property.GetValue(entityToUpdate) is IEnumerable values)
                {
                    foreach (var e in (IEnumerable)property.GetValue(entityToUpdate))
                    {
                        if (e is IData)
                        {
                                Context.Entry(e).State = EntityState.Deleted;
                        }

                    }
                }
            }

        }

        public void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.Entry(entityToUpdate).Property(x => x.CreatedOn).IsModified = false;
            Context.Entry(entityToUpdate).Property(x => x.CreatedBy).IsModified = false;

            var properties = entityToUpdate.GetType()
                 .GetProperties()
                 .Where(p => typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                         && !typeof(string).IsAssignableFrom(p.PropertyType)
                         && p.CanRead && p.GetGetMethod() != null
                         && p.GetIndexParameters().Length == 0);

            foreach (var property in properties)
            {
                if (property.GetValue(entityToUpdate) is IEnumerable values)
                {
                    foreach (var e in (IEnumerable)property.GetValue(entityToUpdate))
                    {
                        if (e is IData)
                        {
                            if (((IData)e).Id != 0)
                            {
                                Context.Entry(e).State = EntityState.Modified;
                                Context.Entry((IData)e).Property(x => x.CreatedOn).IsModified = false;
                                Context.Entry((IData)e).Property(x => x.CreatedBy).IsModified = false;
                            }
                            else
                            {
                                Context.Entry(e).State = EntityState.Added;
                            }
                        }

                    }
                }
            }

        }
    }
}

