using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nzh.Frame.IRepository;
using Nzh.Frame.IService;
using Nzh.Frame.Model;
using Nzh.Frame.Model.Common;
using Nzh.Frame.Model.ViewModel;
using Nzh.Frame.Repository.EF;
using Nzh.Frame.Service.Extensions;
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
        private readonly EFDbContext _context;

        public DemoService(IDemoRepository demorepository, IMapper mapper, EFDbContext context)
        {
            _demorepository = demorepository;
            _mapper = mapper;
            _context = context;
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
            //result.Data = _context.Demo.FromSql<Demo>("select * from demo").FirstOrDefault(); //执行sql语句
            //int count = _context.Database.ExecuteSqlCommand("select * from demo"); //执行sql语句
            return _mapper.Map<OperationResult<ViewDemo>>(result);
        }

        /// <summary>
        /// 添加Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> AddDemoAsync(Demo model)
        {
            using (var tran = _context.Database.BeginTransaction())//开始事务
            {
                try
                {
                    var result = new OperationResult<bool>();
                    if (model == null)
                    {
                        result.ErrorMessage = "参数有误";
                        result.Success = false;
                        return result;
                    }
                    else
                        result.Data = await _demorepository.AddAsync(model);
                        tran.Commit();//提交事务
                        return result;
                }
                catch (Exception ex)
                {
                    tran.Rollback();//回滚事务
                    throw ex;
                }
            }
         }

        

        /// <summary>
        /// 修改Demo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> UpdateDemoAsync(Demo model)
        {
            using (var tran = _context.Database.BeginTransaction())//开始事务
            {
                try
                {
                    var result = new OperationResult<bool>();
                    var demo = await _demorepository.FindAsync(model.ID);
                    if (model == null)
                    {
                        result.ErrorMessage = string.Format("ID有误:{0}", model.ID);
                        result.Success = false;
                    }
                    else
                        demo.Name = model.Name;
                        demo.Sex = model.Sex;
                        demo.Age = model.Age;
                        demo.Remark = model.Remark;
                        result.Data = await _demorepository.UpdateAsync(demo);
                        tran.Commit();//提交事务
                        return result;
                }
                catch (Exception ex)
                {
                    tran.Rollback();//回滚事务
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 删除Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> DeleteDemoAsync(Guid ID)
        {
            using (var tran = _context.Database.BeginTransaction()) //开始事务
            {
                try
                {
                    var result = new OperationResult<bool>();
                    var model = await _demorepository.FindAsync(ID);
                    if (model == null)
                    {
                        result.ErrorMessage = string.Format("ID有误:{0}", ID);
                        result.Success = false;
                    }
                    else
                        result.Data = await _demorepository.DeleteAsync(model);
                        tran.Commit(); //提交事务
                        return result;   
                }
                catch (Exception ex)
                {
                    tran.Rollback();//回滚事务
                    throw ex;
                }
            }
        }
    }
}
