using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nzh.Frame.Common.Logger;
using Nzh.Frame.IService;
using Nzh.Frame.Model;
using Nzh.Frame.Model.Common;
using Nzh.Frame.Model.ViewModel;

namespace Nzh.Frame.Controllers
{
    /// <summary>
    /// Demo
    /// </summary>
    [Produces("application/json")]
    [Route("api/Demo")]
    public class DemoController : Controller
    {
        private readonly IDemoService _demoService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demoservice"></param>
        public DemoController(IDemoService demoService)
        {
            _demoService = demoService;
        }

        /// <summary>
        /// 获取Demo分页
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="SortExpression"></param>
        /// <returns></returns>
        [HttpGet("GetDemoPageAsyncList")]
        public async Task<JsonResult> GetDemoPageAsyncList(QueryHelper query)
        {
            var result = new OperationResult<PageResult<Demo>>();
            try
            {
                //判断page_size是否在0-100之间，超出范围则默认为20。
                query.page_size = query.page_size > 0 && query.page_size <= 100 ? query.page_size : 20;
                //判断page_size是否大于0，超出范围则默认为1。
                query.page_num = query.page_num > 0 ? query.page_num : 1;
                result.data = await _demoService.GetDemoPageAsyncList(query);
            }
            catch (System.Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            return Json(result);
        }

        /// <summary>
        ///  获取单个Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetDemoByIDAsync")]
        public async Task<OperationResult<Demo>> GetDemoByIDAsync(Guid ID)
        {
            return null;
        }

        /// <summary>
        /// 新增Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddDemoAsync")]
        public async Task<OperationResult<bool>> AddDemoAsync([FromBody]Demo model)
        {
            return null;
        }

        /// <summary>
        /// 修改Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateDemoAsync")]
        public async Task<OperationResult<bool>> UpdateDemoAsync([FromBody]Demo model)
        {
            return null;
        }

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDemoAsync")]
        public async Task<OperationResult<bool>> DeleteDemoAsync(Guid ID)
        {
            return null;
        }
    }
}