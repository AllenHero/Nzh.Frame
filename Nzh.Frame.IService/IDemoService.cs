
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
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PageResult<Demo>> GetDemoPageAsyncList(QueryHelper query);

        /// <summary>
        ///  获取Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<Demo> GetDemoByIDAsync(Guid ID);

        /// <summary>
        /// 添加Demo
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Age"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> AddDemoAsync(string Name, string Sex, int Age, string Remark);

        /// <summary>
        /// 修改Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Age"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> UpdateDemoAsync(Guid ID, string Name, string Sex, int Age, string Remark);

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> DeleteDemoAsync(Guid ID);
    }
}
