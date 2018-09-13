using System;
using System.Linq;
using Domain.DAO;
using Microsoft.EntityFrameworkCore;

namespace Services.Repository
{
    public abstract class BaseRepository< T> :
    IBaseRepository<T> where T : class 
    {
        private  EMobileContext _context { get; set; }
        public BaseRepository(EMobileContext context)
        {
            this._context = context;
        }
        public EMobileContext Context
        {

            get { return _context; }
            set { _context = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _context.Set<T>();
            return query;
        }
        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual bool Save()
        {
           return _context.SaveChanges() > 0;
        }

    }
}
