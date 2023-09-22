using Kafedra.Domain.Entities.Common;
using Kafedra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Persistence.Repositories.Implementations
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly KafedraContext _context;

        public Repository(KafedraContext context)
        {
            _context = context;
        }
       
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> GetAll()
         => Table.AsQueryable();

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp = null)
        => GetQuery().Where(exp).AsQueryable();

        public async Task<TEntity> GetByIdAsync(int id)
           => await Table.FindAsync(id);

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
  
            => await GetQuery(includes).FirstOrDefaultAsync(exp);       
        

        public async Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
  
            => await GetQuery(includes).Where(exp).ToListAsync();
        

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> exp = null)
       => await GetQuery().AnyAsync(exp);

        public async Task<bool> CreateAsync(TEntity entity)
        {
            var data = await Table.AddAsync(entity);
           
            return data.State == EntityState.Added;
        }
        public void Update(TEntity entity)
          =>Table.Update(entity);

        public bool Delete(TEntity entity)    
           => Table.Remove(entity).State == EntityState.Deleted;
        

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }
        public async Task<int> SaveAysnc()
        => await _context.SaveChangesAsync();
        public int Save()
        => _context.SaveChanges();

        public bool UnActive(TEntity entity)
          => entity.IsDeleted == true;

        
        public bool Active(TEntity entity)
          => entity.IsDeleted == false;



        private IQueryable<TEntity> GetQuery(params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }
            return query;
        }
    }
}
