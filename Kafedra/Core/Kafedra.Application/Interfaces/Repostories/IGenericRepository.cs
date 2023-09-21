using Kafedra.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.Interfaces.Repostories
{
    public  interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp = null);
        Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<TEntity> GetSingleAsync (Expression<Func<TEntity, bool>> exp = null, params string[] includes);
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> Create(TEntity entity);
        bool Delete(TEntity entity);
        bool DeleteRange(List<TEntity> entity);
        Task<bool> DeleteAsync(int id);
        bool Update(TEntity entity);
        bool UnActive (TEntity entity);
        Task<int> Save();
        
    }
}
