using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BL.TesteGol.Domain.Core.Models;

namespace BL.TesteGol.Domain.Airplane.Shared.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}