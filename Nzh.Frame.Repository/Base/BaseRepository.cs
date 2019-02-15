using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nzh.Frame.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetObjectSet()
        {
            return _context.Set<T>();
        }


        #region  新增

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AddRange(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().AddRange(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            await _context.Set<T>().AddRangeAsync(entity);
            return await _context.SaveChangesAsync() >= 1;
        }



        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AddRange(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().AddRange(entity);
        }

       
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddRangeAsync(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            await _context.Set<T>().AddRangeAsync(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        #endregion

        #region  删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            return _context.SaveChanges() >= 1;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="predicate"></param>
        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> DeleteWhereAsync(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> RemoveAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void RemoveRange(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().RemoveRange(entity);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> RemoveRangeAsync(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().RemoveRange(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void RemoveRange(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().RemoveRange(entity);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> RemoveRangeAsync(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().RemoveRange(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Update(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> EditAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void EditRange(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().UpdateRange(entity);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> EditRangeAsync(IEnumerable<T> entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().UpdateRange(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void EditRange(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().UpdateRange(entity);
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual async Task<bool> EditRangeAsync(T[] entity)
        {
            EntityEntry dbEntityEntry = _context.Entry(entity);
            _context.Set<T>().UpdateRange(entity);
            return await _context.SaveChangesAsync() >= 1;
        }

        #endregion

        #region 查询

         /// <summary>
         /// 求和
         /// </summary>
         /// <param name="selector"></param>
         /// <returns></returns>
        public virtual int Sum(Expression<Func<T, int>> selector)
        {
            return _context.Set<T>().Sum(selector);
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual async Task<int> SumAsync(Expression<Func<T, int>> selector)
        {
            return await _context.Set<T>().SumAsync(selector);
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual int Max(Expression<Func<T, int>> selector)
        {
            return _context.Set<T>().Max(selector);
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual async Task<int> MaxAsync(Expression<Func<T, int>> selector)
        {
            return await _context.Set<T>().MaxAsync(selector);
        }

        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual int Min(Expression<Func<T, int>> selector)
        {
            return _context.Set<T>().Min(selector);
        }

        /// <summary>
        /// 最小值
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual async Task<int> MinAsync(Expression<Func<T, int>> selector)
        {
            return await  _context.Set<T>().MinAsync(selector);
        }

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual double Average(Expression<Func<T, int>> selector)
        {
            return  _context.Set<T>().Average(selector);
        }

        /// <summary>
        /// 平均值
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public virtual async Task<double> AverageAsync(Expression<Func<T, int>> selector)
        {
            return await _context.Set<T>().AverageAsync(selector);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        public virtual T First()
        {
            return _context.Set<T>().First();
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <returns></returns>
        public virtual async Task<T> FirstAsync()
        {
            return await _context.Set<T>().FirstAsync();
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().First(predicate);
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstAsync(predicate);
        }


        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public virtual T Find(Guid ID)
        {
            return  _context.Set<T>().Find(ID);
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(Guid ID)
        {
            return await _context.Set<T>().FindAsync(ID);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public virtual T Single()
        {
            return _context.Set<T>().Single();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public virtual async Task<T> SingleAsync()
        {
            return await _context.Set<T>().SingleAsync();
        }

        /// <summary>
        /// 根据条件获取单个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Single(predicate);
        }

        /// <summary>
        /// 根据条件获取单个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual  async Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleAsync(predicate);
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public virtual T SingleOrDefault()
        {
            return _context.Set<T>().SingleOrDefault();
        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <returns></returns>
        public virtual async Task<T> SingleOrDefaultAsync()
        {
            return await _context.Set<T>().SingleOrDefaultAsync();
        }

        /// <summary>
        /// 根据条件获取单个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return  _context.Set<T>().SingleOrDefault(predicate);
        }

        /// <summary>
        /// 根据条件获取单个实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        /// <summary>
        ///  判断是否存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        /// <summary>
        /// 包括条件和不在条件在内
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool All(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().All(predicate);
        }

        /// <summary>
        /// 包括条件和不在条件在内
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> AllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AllAsync(predicate);
        }


        /// <summary>
        /// 返回数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Count(predicate);
        }

        /// <summary>
        /// 返回数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetList()
        {
            return _context.Set<T>().AsEnumerable().ToList();
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAsIQuerable()
        {
            return _context.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IQueryable<T>> GetAsIQuerableAsync()
        {
            return await Task.Run(() => _context.Set<T>().AsNoTracking());
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T FirstOrDefault()
        {
            return _context.Set<T>().FirstOrDefault();
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync()
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        /// <summary>
        ///  根据条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        ///  根据条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.Where(predicate).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync(int pageIndex, int pageSize)
        {
            return await Task.Run(() => GetObjectSet().Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList());
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<T> Query(int pageIndex, int pageSize)
        {
            return GetObjectSet().Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> where)
        {
            return await Task.Run(() => GetObjectSet().Where(where).ToList());
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> Query(Expression<Func<T, bool>> where)
        {
            return  GetObjectSet().Where(where).ToList();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<T>, int>> QueryAsync(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet();
                if (where != null)
                    list = GetObjectSet().Where(where);
                list = list.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                return new Tuple<List<T>, int>(list.ToList(), list.Count());
            });
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<List<T>, int> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            var list = GetObjectSet();
            if (where != null)
                list = GetObjectSet().Where(where);
            list = list.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return new Tuple<List<T>, int>(list.ToList(), list.Count());
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc)
        {
            return await Task.Run(() =>
            {
                if (isAsc)
                {
                    return GetObjectSet().Where(where).OrderBy(orderBy1).ToList();
                }
                else
                {
                    return GetObjectSet().Where(where).OrderByDescending(orderBy1).ToList();
                }
            });
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public List<T> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc)
        {
            if (isAsc)
            {
                return GetObjectSet().Where(where).OrderBy(orderBy1).ToList();
            }
            else
            {
                return GetObjectSet().Where(where).OrderByDescending(orderBy1).ToList();
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<T>, int>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                if (isAsc)
                {
                    return new Tuple<List<T>, int>(GetObjectSet().Where(where).OrderBy(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), GetObjectSet().Where(where).Count());
                }
                else
                {
                    return new Tuple<List<T>, int>(GetObjectSet().Where(where).OrderByDescending(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), GetObjectSet().Where(where).Count());
                }
            });
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<List<T>, int> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            if (isAsc)
            {
                return new Tuple<List<T>, int>(GetObjectSet().Where(where).OrderBy(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), GetObjectSet().Where(where).Count());
            }
            else
            {
                return new Tuple<List<T>, int>(GetObjectSet().Where(where).OrderByDescending(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), GetObjectSet().Where(where).Count());
            }
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc)
        {
            return await Task.Run(() =>
            {
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return GetObjectSet().Where(where).OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ToList();
                        else
                            return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).ToList();
                    }
                    else
                    {
                        if (isAsc)
                            return GetObjectSet().Where(where).OrderBy<T, A>(orderBy1).ToList();
                        else
                            return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy1).ToList();
                    }
                }
                else
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return GetObjectSet().Where(where).OrderBy<T, A>(orderBy2).ToList();
                        else
                            return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy2).ToList();
                    }
                    else
                    {
                        return GetObjectSet().Where(where).ToList();//排序都为null
                    }
                }
            });
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public List<T> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc)
        {
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return GetObjectSet().Where(where).OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ToList();
                    else
                        return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).ToList();
                }
                else
                {
                    if (isAsc)
                        return GetObjectSet().Where(where).OrderBy<T, A>(orderBy1).ToList();
                    else
                        return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy1).ToList();
                }
            }
            else
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return GetObjectSet().Where(where).OrderBy<T, A>(orderBy2).ToList();
                    else
                        return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy2).ToList();
                }
                else
                {
                    return GetObjectSet().Where(where).ToList();//排序都为null
                }
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<T>, int>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet();
                if (where != null)
                    list = GetObjectSet().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                else
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        return new Tuple<List<T>, int>(list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
            });
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<List<T>, int> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            var list = GetObjectSet();
            if (where != null)
                list = GetObjectSet().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
                else
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
            }
            else
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
                else
                {
                    return new Tuple<List<T>, int>(list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="orderBy3"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<T>, int>> QueryAsync<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (orderBy3 != null)
                        {
                            if (isAsc)
                                return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ThenBy<T, A>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                            else
                                return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2)
                                    .ThenByDescending<T, A>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        }
                        else
                        {
                            if (isAsc)
                                return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                            else
                                return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        }
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                return new Tuple<List<T>, int>(list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
            });
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="orderBy3"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<List<T>, int> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            var list = GetObjectSet().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (orderBy3 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ThenBy<T, A>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2)
                                .ThenByDescending<T, A>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                else
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
            }
            return new Tuple<List<T>, int>(list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return GetObjectSet().Where(where).OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList();
                        else
                            return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList();
                    }
                    else
                    {
                        if (isAsc)
                            return list.OrderBy<T, A>(orderBy1).ToList();
                        else
                            return list.OrderByDescending<T, A>(orderBy1).ToList();
                    }
                }
                else
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return GetObjectSet().Where(where).OrderBy<T, B>(orderBy2).ToList();
                        else
                            return GetObjectSet().Where(where).OrderByDescending<T, B>(orderBy2).ToList();
                    }
                    else
                    {
                        return GetObjectSet().Where(where).ToList();
                    }
                }
            });
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public List<T> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc)
        {
            var list = GetObjectSet().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return GetObjectSet().Where(where).OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList();
                    else
                        return GetObjectSet().Where(where).OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList();
                }
                else
                {
                    if (isAsc)
                        return list.OrderBy<T, A>(orderBy1).ToList();
                    else
                        return list.OrderByDescending<T, A>(orderBy1).ToList();
                }
            }
            else
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return GetObjectSet().Where(where).OrderBy<T, B>(orderBy2).ToList();
                    else
                        return GetObjectSet().Where(where).OrderByDescending<T, B>(orderBy2).ToList();
                }
                else
                {
                    return GetObjectSet().Where(where).ToList();
                }
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<T>, int>> QueryAsync<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                return new Tuple<List<T>, int>(list.ToList(), list.Count());
            });
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<List<T>, int> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            var list = GetObjectSet().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
                else
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                }
            }
            return new Tuple<List<T>, int>(list.ToList(), list.Count());
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <typeparam name="C"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="orderBy3"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryAsync<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet();
                if (where != null)
                    list = GetObjectSet().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (orderBy3 != null)
                        {
                            if (isAsc)
                                return list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ThenBy<T, C>(orderBy3)
                                    .ToList();
                            else
                            {
                                return list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2)
                                    .ThenByDescending<T, C>(orderBy3).ToList();
                            }
                        }
                        else
                        {
                            if (isAsc)
                                return list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList();
                            else
                                return list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList();
                        }
                    }
                    else
                    {
                        if (isAsc)
                            return list.OrderBy<T, A>(orderBy1).ToList();
                        else
                            return list.OrderByDescending<T, A>(orderBy1).ToList();
                    }
                }
                return list.ToList();
            });
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <typeparam name="C"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="orderBy3"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public List<T> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc)
        {
            var list = GetObjectSet();
            if (where != null)
                list = GetObjectSet().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (orderBy3 != null)
                    {
                        if (isAsc)
                            return list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ThenBy<T, C>(orderBy3)
                                .ToList();
                        else
                        {
                            return list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2)
                                .ThenByDescending<T, C>(orderBy3).ToList();
                        }
                    }
                    else
                    {
                        if (isAsc)
                            return list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList();
                        else
                            return list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList();
                    }
                }
                else
                {
                    if (isAsc)
                        return list.OrderBy<T, A>(orderBy1).ToList();
                    else
                        return list.OrderByDescending<T, A>(orderBy1).ToList();
                }
            }
            return list.ToList();
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <typeparam name="C"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="orderBy3"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<Tuple<List<T>, int>> QueryAsync<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet();
                if (where != null)
                    list = GetObjectSet().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (orderBy3 != null)
                        {
                            if (isAsc)
                                return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ThenBy<T, C>(orderBy3).ToList(), list.Count());
                            else
                            {
                                return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ThenByDescending<T, C>(orderBy3).AsQueryable().ToList(), list.Count());
                            }
                        }
                        else
                        {
                            if (isAsc)
                                return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList(), list.Count());
                            else
                                return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList(), list.Count());
                        }
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ToList(), list.Count());
                    }
                }
                return new Tuple<List<T>, int>(list.ToList(), list.Count());
            });
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <typeparam name="B"></typeparam>
        /// <typeparam name="C"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy1"></param>
        /// <param name="orderBy2"></param>
        /// <param name="orderBy3"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Tuple<List<T>, int> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            var list = GetObjectSet();
            if (where != null)
                list = GetObjectSet().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (orderBy3 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ThenBy<T, C>(orderBy3).ToList(), list.Count());
                        else
                        {
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ThenByDescending<T, C>(orderBy3).AsQueryable().ToList(), list.Count());
                        }
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList(), list.Count());
                    }
                }
                else
                {
                    if (isAsc)
                        return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ToList(), list.Count());
                    else
                        return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ToList(), list.Count());
                }
            }
            return new Tuple<List<T>, int>(list.ToList(), list.Count());
        }

        #endregion

        #region  EF扩展方法

        /// <summary>
        /// 执行Sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteSqlAsync(string sql)
        {
           return await Task.Run(() => _context.Database.ExecuteSqlCommandAsync(sql))>0;
        }

        /// <summary>
        /// 执行Sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSql(string sql)
        {
            return  _context.Database.ExecuteSqlCommand(sql) > 0;
        }

        /// <summary>
        /// 执行带参数的Sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteSqlAsync(string sql, params object[] parameters)
        {
           return await Task.Run(() => _context.Database.ExecuteSqlCommandAsync(sql, parameters))>0;
        }

        /// <summary>
        ///  执行带参数的Sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool ExecuteSql(string sql, params object[] parameters)
        {
            return  _context.Database.ExecuteSqlCommand(sql, parameters) > 0;
        }

        /// <summary>
        /// 执行Sql返回List
        /// </summary>
        /// <param name="querySql"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryBySqlAsync(string querySql)
        {
            return await Task.Run(() => GetObjectSet().FromSql(querySql).ToList());
        }

        /// <summary>
        /// 执行Sql返回List
        /// </summary>
        /// <param name="querySql"></param>
        /// <returns></returns>
        public List<T> QueryBySql(string querySql)
        {
            return  GetObjectSet().FromSql(querySql).ToList();
        }

        /// <summary>
        ///  执行Sql返回分页
        /// </summary>
        /// <param name="querySql"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<T>> QueryBySqlAsync(string querySql, int pageIndex, int pageSize)
        {
            return await Task.Run(() => GetObjectSet().FromSql(querySql).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList());
        }

        /// <summary>
        ///  执行Sql返回分页
        /// </summary>
        /// <param name="querySql"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<T> QueryBySql(string querySql, int pageIndex, int pageSize)
        {
            return   GetObjectSet().FromSql(querySql).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
        }

        #endregion
    }
}

