using DailyTimeRecorder.Domain.Core.Interfaces;
using DailyTimeRecorder.Domain.Core.Models;
using DailyTimeRecorder.Infra.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DailyTimeRecorder.Infra.Data.EntityFramework.Repository
{
    public abstract class Repository<TEntity> : IWriteRepository<TEntity>, IReadRepository<TEntity>
        where TEntity : Entity
    {
        #region Fields
        private readonly DailyTimeRecorderContext _db;
        private readonly DbSet<TEntity> _dbSet;
        #endregion

        #region Constructor
        protected Repository(DailyTimeRecorderContext context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }
        #endregion

        #region Methods
        public void Add(TEntity entity) => _dbSet.Add(entity);
        public virtual Task AddAsync(TEntity entity) => _dbSet.AddAsync(entity);

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity Get(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual Task<TEntity> GetAsync(long id)
        {
            return _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll() =>
            _dbSet;

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter, bool @readonly = true) =>
            (@readonly ? _dbSet.AsNoTracking() : _dbSet).Where(filter);

        public virtual void Remove(long id) =>
            _dbSet.Remove(_dbSet.Find(id));

        public int SaveChanges() =>
            _db.SaveChanges();

        public virtual void Update(TEntity entity) =>
            _dbSet.Update(entity);
        #endregion
    }
}
