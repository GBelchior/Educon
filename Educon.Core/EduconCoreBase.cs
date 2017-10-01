using Educon.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Educon.Core
{
    public abstract class EduconCoreBase<TEntity> : IEduconCoreBase<TEntity> where TEntity : class, new()
    {
        private IEduconRepositoryBase<TEntity> FRepository;

        public EduconCoreBase(IEduconRepositoryBase<TEntity> ARepository)
        {
            FRepository = ARepository;
        }

        public virtual void Add(TEntity AEntity)
        {
            FRepository.Add(AEntity);
        }

        public virtual TEntity Get(params object[] AKeyValues)
        {
            return FRepository.Get(AKeyValues);
        }

        public virtual TEntity Get(int ANidEntity)
        {
            return FRepository.Get(ANidEntity);
        }

        public virtual ICollection<TEntity> FindBy(Expression<Func<TEntity, bool>> AExpression)
        {
            return FRepository.FindBy(AExpression);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> AExpression)
        {
            return FRepository.Count(AExpression);
        }

        public virtual void Delete(TEntity AEntity)
        {
            FRepository.Delete(AEntity);
        }

        public virtual void Edit(TEntity AEntity)
        {
            FRepository.Edit(AEntity);
        }

        public virtual void Dispose()
        {
            FRepository.Dispose();
        }
    }
}
