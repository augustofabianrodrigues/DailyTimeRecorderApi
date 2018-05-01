using DailyTimeRecorder.Domain.Core.Models;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Domain.Core.Interfaces
{
    public interface IWriteRepository<in TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(long id);
        int SaveChanges();
    }
}
