using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Interfaces
{
    public interface IEduconCoreBase<TEntity> : IDisposable where TEntity : class, new()
    {
        void Add(TEntity AEntity);
        TEntity Get(params object[] AKeyValues);
        TEntity Get(int ANidEntity);
        int Count(Expression<Func<TEntity, bool>> AExpression);
        void Edit(TEntity AEntity);
        ICollection<TEntity> FindBy(Expression<Func<TEntity, bool>> AExpression);
        void Delete(TEntity AEntity);
    }
}
