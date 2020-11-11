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
        void Insert(T entity);

        Task<bool> InsertAsync(T entity);

        void InsertRange(IEnumerable<T> entity);

        Task<bool> InsertRangeAsync(IEnumerable<T> entity);

        void InsertRange(T[] entity);

        Task<bool> InsertRangeAsync(T[] entity);

        bool Delete(T entity);

        Task<bool> DeleteAsync(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate);

        void Remove(T entity);

        Task<bool> RemoveAsync(T entity);

        void RemoveRange(IEnumerable<T> entity);

        Task<bool> RemoveRangeAsync(IEnumerable<T> entity);

        void RemoveRange(T[] entity);

        Task<bool> RemoveRangeAsync(T[] entity);

        void Update(T entity);

        Task<bool> UpdateAsync(T entity);

        void Edit(T entity);

        Task<bool> EditAsync(T entity);

        void EditRange(IEnumerable<T> entity);

        Task<bool> EditRangeAsync(IEnumerable<T> entity);

        void EditRange(T[] entity);

        int Sum(Expression<Func<T, int>> selector);

        Task<int> SumAsync(Expression<Func<T, int>> selector);

        int Max(Expression<Func<T, int>> selector);

        Task<int> MaxAsync(Expression<Func<T, int>> selector);

        int Min(Expression<Func<T, int>> selector);

        Task<int> MinAsync(Expression<Func<T, int>> selector);

        double Average(Expression<Func<T, int>> selector);

        Task<double> AverageAsync(Expression<Func<T, int>> selector);

        int Count(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        bool Contains(T entity);

        Task<bool> ContainsAsync(T entity);

        bool Any(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        bool All(Expression<Func<T, bool>> predicate);

        Task<bool> AllAsync(Expression<Func<T, bool>> predicate);

        T First();

        Task<T> FirstAsync();

        T First(Expression<Func<T, bool>> predicate);

        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        T FirstOrDefault();

        Task<T> FirstOrDefaultAsync();

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        T Find(string Id);

        Task<T> FindAsync(string Id);

        T Single();

        Task<T> SingleAsync();

        T Single(Expression<Func<T, bool>> predicate);

        Task<T> SingleAsync(Expression<Func<T, bool>> predicate);

        T SingleOrDefault();

        Task<T> SingleOrDefaultAsync();

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        T SingleOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetList();

        Task<IEnumerable<T>> GetListAsync();

        IQueryable<T> GetAsIQuerable();

        Task<IQueryable<T>> GetAsIQuerableAsync();

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<List<T>> QueryAsync(int pageIndex, int pageSize);

        List<T> Query(int pageIndex, int pageSize);

        Task<List<T>> QueryAsync(Expression<Func<T, bool>> where);

        List<T> Query(Expression<Func<T, bool>> where);

        Task<Tuple<List<T>, int>> QueryAsync(Expression<Func<T, bool>> where, int pageIndex, int pageSize);

        Tuple<List<T>, int> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize);

        Task<List<T>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc);

        List<T> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc);

        Task<Tuple<List<T>, int>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize);

        Tuple<List<T>, int> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize);

        Task<List<T>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc);

        List<T> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc);

        Task<Tuple<List<T>, int>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize);

        Tuple<List<T>, int> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize);

        Task<Tuple<List<T>, int>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize);

        Tuple<List<T>, int> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize);

        Task<List<T>> QueryAsync<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc);

        List<T> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc);

        Task<Tuple<List<T>, int>> QueryAsync<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize);

        Tuple<List<T>, int> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize);

        Task<List<T>> QueryAsync<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc);

        List<T> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc);

        Task<Tuple<List<T>, int>> QueryAsync<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize);

        Tuple<List<T>, int> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize);

        #region  EF扩展方法

        Task<bool> ExecuteSqlAsync(string sql);

        bool ExecuteSql(string sql);

        Task<bool> ExecuteSqlAsync(string sql, params object[] parameters);

        bool ExecuteSql(string sql, params object[] parameters);

        Task<List<T>> QueryBySqlAsync(string querySql);

        List<T> QueryBySql(string querySql);

        Task<List<T>> QueryBySqlAsync(string querySql, int pageIndex, int pageSize);

        List<T> QueryBySql(string querySql, int pageIndex, int pageSize);

        #endregion

    }
}
