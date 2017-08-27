using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Interfaces
{
    public interface IEduconRepositoryBase<T>
    {
        void Add(T Entity);
        void Edit(T Entity);
        void Delete(T Entity);
        void Get(int Id);
        void FindBy(Expression<Func<T, bool>> Expr);
        void Count(Expression<Func<T, bool>> Expr);
        void Save();
    }
}
