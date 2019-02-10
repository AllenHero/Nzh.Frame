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
                result.data = await _demoService.GetDemoPageAsyncList(query);
            }
            catch (System.Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return Json(result);
        }

        /// <summary>
        ///  获取单个Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetDemoByIDAsync")]
        public async Task<JsonResult> GetDemoByIDAsync(Guid ID)
        {
            var result = new OperationResult<Demo>();
            try
            {
                result.data = await _demoService.GetDemoByIDAsync(ID);
            }
            catch (Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return Json(result);
        }

        /// <summary>
        /// 新增Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddDemoAsync")]
        public async Task<JsonResult> AddDemoAsync([FromBody]Demo model)
        {
            var result = new OperationResult<bool>();
            try
            {
                result = await _demoService.AddDemoAsync(model);
            }
            catch (Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return Json(result);
        }

        /// <summary>
        /// 修改Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateDemoAsync")]
        public async Task<JsonResult> UpdateDemoAsync([FromBody]Demo model)
        {
            var result = new OperationResult<bool>();
            try
            {
                result = await _demoService.UpdateDemoAsync(model);
            }
            catch (Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return Json(result);
        }

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDemoAsync")]
        public async Task<JsonResult> DeleteDemoAsync(Guid ID)
        {
            var result = new OperationResult<bool>();
            try
            {
                result = await _demoService.DeleteDemoAsync(ID);
            }
            catch (Exception ex)
            {
                result.code = -1;
                result.msg = ex.Message;
            }
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return Json(result);
        }
    }
}