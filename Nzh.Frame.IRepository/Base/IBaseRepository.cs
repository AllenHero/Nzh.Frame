using Nzh.Frame.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.IRepository.Base
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        void Add(T entity);

        Task<bool> AddAsync(T entity);

        void AddRange(IEnumerable<T> entity);

        void AddRange(T[] entity);

        Task<bool> AddRangeAsync(IEnumerable<T> entity);

        Task<bool> AddRangeAsync(T[] entity);

        bool Delete(T entity);

        Task<bool> DeleteAsync(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        void RemoveRange(T[] entity);

        void Update(T entity);

        Task<bool> UpdateAsync(T entity);

        void Edit(T entity);

        void EditRange(IEnumerable<T> entity);

        void EditRange(T[] entity);

        T Find(Guid ID);

        Task<T> FindAsync(Guid ID);

        bool CheckExist(Expression<Func<T, bool>> predicate);

        Task<bool> CheckExistAsync(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> GetAllAsIQuerable();

        T GetSingle(Guid ID);

        T GetSingle(Expression<Func<T, bool>> predicate);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        int Commit();

        Task<bool> CommitAsync();

    }
}
