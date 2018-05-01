using DailyTimeRecorder.Domain.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Domain.Core.Interfaces
{
    public interface IReadRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity Get(long id);
        Task<TEntity> GetAsync(long id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter, bool @readonly = true);
    }
}
