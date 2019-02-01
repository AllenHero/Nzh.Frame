using Nzh.Frame.Model;
using Nzh.Frame.Model.Common;
using Nzh.Frame.Model.ViewModel;
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
        /// <param name="Name"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="SortExpression"></param>
        /// <returns></returns>
        Task<OperationResult<IEnumerable<ViewDemo>>> GetDemoPageAsyncList(string Name, int PageIndex, int PageSize, string SortExpression);

        /// <summary>
        ///  获取单个Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<OperationResult<ViewDemo>> GetDemoByIDAsync(Guid ID);

        /// <summary>
        /// 保存Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> SaveDemoAsync(Demo model);

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<OperationResult<bool>> DeleteDemoAsync(Guid ID);
    }
}
