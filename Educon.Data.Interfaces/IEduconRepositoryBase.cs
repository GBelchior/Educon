using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Interfaces
{
    public interface IEduconRepositoryBase<T> : IDisposable where T : class, new()
    {
        void Add(T Entity);
        void Edit(T Entity);
        void Delete(T Entity);
        T Get(int Id);
        T Get(params object[] keyValues);
        List<T> FindBy(Expression<Func<T, bool>> Expr);
        int Count(Expression<Func<T, bool>> Expr);
        void Save();
    }
}
