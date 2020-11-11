
using Nzh.Frame.Model;
using Nzh.Frame.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.IService
{
    public interface IDemoService 
    {
        /// <summary>
        /// 获取Demo分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="SortField"></param>
        /// <param name="SortType"></param>
        /// <returns></returns>
        Task<PageResult<Demo>> GetDemoPageListAsync(int PageIndex, int PageSize, string SortField, string SortType);

        /// <summary>
        ///  获取Demo
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Demo> GetDemoByIdAsync(string Id);

        /// <summary>
        /// 添加Demo
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Age"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> InsertDemoAsync(string Name, string Sex, int Age, string Remark);

        /// <summary>
        /// 修改Demo
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Age"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> UpdateDemoAsync(string Id, string Name, string Sex, int Age, string Remark);

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> DeleteDemoAsync(string Id);
    }
}
