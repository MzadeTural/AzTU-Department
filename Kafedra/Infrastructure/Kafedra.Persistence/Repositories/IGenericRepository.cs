using Kafedra.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        DbSet<TEntity> Table { get; }
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp = null);
        Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> CreateAsync(TEntity entity);
        bool Delete(TEntity entity);
        Task<bool> IsExist(Expression<Func<TEntity, bool>> exp = null);
        bool DeleteRange(List<TEntity> entities);
        Task<bool> DeleteAsync(int id);
        void Update(TEntity entity);
        bool UnActive(TEntity entity);
        bool Active(TEntity entity);
        Task<int> SaveAysnc();
        int Save();
    }
}
