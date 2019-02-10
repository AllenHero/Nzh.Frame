using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Nzh.Frame.Model.Common
{
    public static class PaginationHelper
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">元数据</param>
        /// <param name="sortExpression">排序的字段</param>
        /// <param name="sortDirection">排序方式：ASC， DESC</param>
        /// <returns></returns>
        public static IQueryable<T> DataSorting<T>(IQueryable<T> source, string sortExpression, string sortDirection)
        {
            string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "OrderBy";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";
            ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源数据</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <returns></returns>
        public static IQueryable<T> GetPageList<T>(IQueryable<T> source, int? pageIndex, int? pageSize)
        {
            if (pageIndex == null || pageIndex < 0) { pageIndex = 1; }//默认显示第1页数据
            if (pageSize == null || pageSize < 0) { pageSize = 20; }//默认每页显示20条数据
            if (pageSize > 100) { pageSize = 100; }
            int previousPageIndex = pageIndex.Value - 1;
            if (previousPageIndex < 0)
            {
                previousPageIndex = 0;
            }
            return source.Skip((previousPageIndex) * pageSize.Value).Take(pageSize.Value);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源数据</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDirection">排序方式</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <returns></returns>
        public static IQueryable<T> SortingAndPaging<T>(IQueryable<T> source, string sortExpression, string sortDirection, int pageNumber, int pageSize)
        {
            if (!string.IsNullOrWhiteSpace(sortDirection) && !string.IsNullOrWhiteSpace(sortExpression))
            {
                source = DataSorting<T>(source, sortExpression, sortDirection);
            }
            return GetPageList(source, pageNumber, pageSize);
        }
    }
}
