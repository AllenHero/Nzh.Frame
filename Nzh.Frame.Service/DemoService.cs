using AutoMapper;
using Nzh.Frame.IRepository;
using Nzh.Frame.IService;
using Nzh.Frame.Model;
using Nzh.Frame.Model.Common;
using Nzh.Frame.Model.ViewModel;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.Service
{
    public class DemoService : IDemoService
    {
        private readonly IMapper _mapper;
        private readonly IDemoRepository _demorepository;

        //事务

        public DemoService(IDemoRepository demorepository, IMapper mapper)
        {
            _demorepository = demorepository;
            _mapper = mapper;
        }

        /// <summary>
        ///  获取Demo分页
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="SortExpression"></param>
        /// <returns></returns>
        public async Task<OperationResult<IEnumerable<ViewDemo>>> GetDemoPageAsyncList(string Name, int PageIndex, int PageSize, string SortExpression)
        {
            string baseSortExpression = "Name";
            var query = _demorepository.GetAllAsIQuerable();
            if (!string.IsNullOrWhiteSpace(Name))
                query = query.Where(c => c.Name == Name);
            if (string.IsNullOrWhiteSpace(SortExpression))
                SortExpression = baseSortExpression;
            var result = new OperationResult<IEnumerable<Demo>>()
            {
                Data = await PagingList.CreateAsync(query, PageSize, PageIndex, SortExpression, baseSortExpression)
            };
            return _mapper.Map<OperationResult<IEnumerable<Demo>>, OperationResult<IEnumerable<ViewDemo>>>(result);
        }

        /// <summary>
        /// 获取单个Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<OperationResult<ViewDemo>> GetDemoByIDAsync(Guid ID)
        {
            var result = new OperationResult<Demo>();
            if (ID == Guid.Empty)
            {
                result.ErrorMessage = string.Format("ID有误:{0}", ID);
                result.Success = false;
            }
            else
                result.Data = await _demorepository.FindAsync(ID);
            return _mapper.Map<OperationResult<ViewDemo>>(result);
        }

        /// <summary>
        /// 保存Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> SaveDemoAsync(Demo model)
        {
            var result = new OperationResult<bool>();
            if (model == null)
            {
                result.ErrorMessage = "参数有误";
                result.Success = false;
                return result;
            }
            result.Data = await _demorepository.SaveAsync(model);
            return result;
        }

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> DeleteDemoAsync(Guid ID)
        {
            var result = new OperationResult<bool>();
            if (ID == Guid.Empty)
            {
                result.ErrorMessage = string.Format("ID有误:{0}", ID);
                result.Success = false;
                return result;
            }
            var model = await _demorepository.FindAsync(ID);
            if (model == null)
            {
                result.ErrorMessage = string.Format("ID有误:{0}", ID);
                result.Success = false;
            }
            else
                result.Data = await _demorepository.DeleteAsync(model);
            return result;
        }
    }
}
