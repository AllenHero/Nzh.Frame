using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nzh.Frame.IRepository.Base;
using Nzh.Frame.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        #region  新增

        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        public virtual void AddRange(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().AddRange(entity);
        }

        public virtual void AddRange(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().AddRange(entity);
        }


        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            await _context.Set<T>().AddRangeAsync(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        public virtual async Task<bool> AddRangeAsync(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            await _context.Set<T>().AddRangeAsync(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        #endregion

        #region  删除


        public virtual bool Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            return _context.SaveChanges() >= 1;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            return await _context.SaveChangesAsync() >= 1;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public async Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            return await _context.SaveChangesAsync();
        }

        public virtual void Remove(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().RemoveRange(entity);
        }

        public virtual void RemoveRange(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().RemoveRange(entity);
        }

        #endregion

        #region 修改


        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            return await _context.SaveChangesAsync() >= 1;
        }

        public virtual void Edit(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Update(entity);
        }

        public virtual void EditRange(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().UpdateRange(entity);
        }

        public virtual void EditRange(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().UpdateRange(entity);
        }

        #endregion

        #region 查询


        public virtual T Find(Guid ID)
        {
            return  _context.Set<T>().Find(ID);
        }

        public async Task<T> FindAsync(Guid ID)
        {
            return await _context.Set<T>().FindAsync(ID);
        }

        public virtual bool CheckExist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public async Task<bool> CheckExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public  int Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(c => c.IsDelete ==0).AsNoTracking().ToListAsync();
        }

        public virtual IQueryable<T> GetAllAsIQuerable()
        {
            return _context.Set<T>().Where(c => c.IsDelete == 0).AsNoTracking();
        }

        public T GetSingle(Guid ID)
        {
            return _context.Set<T>().FirstOrDefault(x => x.ID == ID);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
