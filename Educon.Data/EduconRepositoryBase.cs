using Educon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Educon.Data
{
    public abstract class EduconRepositoryBase<T> : IEduconRepositoryBase<T> where T : class, new()
    {
        protected EduconContext FContext;
        private DbSet<T> FDbSet;

        public EduconRepositoryBase(EduconContext AContext)
        {
            FContext = AContext;
            FDbSet = FContext.Set<T>();
        }

        public virtual void Add(T Entity)
        {
            FDbSet.Add(Entity);
        }

        public virtual int Count(Expression<Func<T, bool>> Expr)
        {
            return FDbSet.Count(Expr);
        }

        public virtual void Delete(T Entity)
        {
            FContext.Entry(Entity).State = EntityState.Deleted;
        }

        public virtual void Edit(T Entity)
        {
            FContext.Entry(Entity).State = EntityState.Modified;
        }

        public virtual List<T> FindBy(Expression<Func<T, bool>> Expr)
        {
            return FDbSet.Where(Expr).ToList();
        }

        public virtual T Get(int Id)
        {
            return FDbSet.Find(Id);
        }

        public virtual T Get(params object[] keyValues)
        {
            return FDbSet.Find(keyValues);
        }

        public virtual void Save()
        {
            FContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            FContext.Dispose();
        }
    }
}
