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
        private readonly IDemoService _demoservice;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="demoservice"></param>
        public DemoController(IDemoService demoservice)
        {
            _demoservice = demoservice;
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
        public async Task<OperationResult<IEnumerable<ViewDemo>>> GetDemoPageAsyncList(string Name, int? PageIndex, int? PageSize,string SortExpression)
        {
            var startTime = DateTime.Now;
            var result = await _demoservice.GetDemoPageAsyncList(Name, PageIndex ?? 1, PageSize ?? 10, SortExpression);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return result;
        }

        /// <summary>
        ///  获取单个Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("GetDemoByIDAsync")]
        public async Task<OperationResult<ViewDemo>> GetDemoByIDAsync(Guid ID)
        {
            var startTime = DateTime.Now;
            var result = await _demoservice.GetDemoByIDAsync(ID);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return result;
        }

        /// <summary>
        /// 新增Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddDemoAsync")]
        public async Task<OperationResult<bool>> AddDemoAsync([FromBody]Demo model)
        {
            var startTime = DateTime.Now;
            var result = await _demoservice.AddDemoAsync(model);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return result;
        }

        /// <summary>
        /// 修改Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateDemoAsync")]
        public async Task<OperationResult<bool>> UpdateDemoAsync([FromBody]Demo model)
        {
            var result = new OperationResult<bool>();
            var startTime = DateTime.Now;
            if (model.ID==Guid.Empty)
            {
                result.Success = false;
                result.ErrorMessage = "ID参数有误";
            }
            else
                result = await _demoservice.UpdateDemoAsync(model);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return result;
        }

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDemoAsync")]
        public async Task<OperationResult<bool>> DeleteDemoAsync(Guid ID)
        {
            var startTime = DateTime.Now;
            var result = await _demoservice.DeleteDemoAsync(ID);
            TimeSpan ts = DateTime.Now - startTime;
            result.TimeSpan = ts.TotalSeconds.ToString("F3");
            Logger.Info(JsonConvert.SerializeObject(result)); //此处调用日志记录函数记录日志
            return result;
        }
    }
}