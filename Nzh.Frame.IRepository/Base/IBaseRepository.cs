using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.IRepository.Base
{
    public interface IBaseRepository<T> where T : class, new()
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

        Task<List<T>> Query(int pageIndex, int pageSize);

        Task<List<T>> Query(Expression<Func<T, bool>> where);

        Task<Tuple<List<T>, int>> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize);

        Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc);

        Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize);

        Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc);

        Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize);

        Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize);

        Task<List<T>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc);

        Task<Tuple<List<T>, int>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize);

        Task<List<T>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc);

        Task<Tuple<List<T>, int>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize);

        Task ExecuteSql(string sql);

        Task ExecuteSql(string sql, params object[] parameters);

        Task<List<T>> QueryBySql(string querySql);

        Task<List<T>> QueryBySql(string querySql, int pageIndex, int pageSize);

    }
}
