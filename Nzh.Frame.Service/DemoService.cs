using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Nzh.Frame.IRepository;
using Nzh.Frame.IService;
using Nzh.Frame.Model;
using Nzh.Frame.Model.Common;
using Nzh.Frame.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.Service
{
    public class DemoService : IDemoService
    {
        private readonly IDemoRepository _demoRepository;
        private readonly EFDbContext _context;

        private readonly string DEFAULT_SORT_FIELD = "Age";

        public DemoService(IDemoRepository demoRepository,  EFDbContext context)
        {
            _demoRepository = demoRepository;
            _context = context;
        }

        /// <summary>
        /// 获取Demo分页
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="SortField"></param>
        /// <param name="SortType"></param>
        /// <returns></returns>
        public async Task<PageResult<Demo>> GetDemoPageAsyncList(int PageIndex, int PageSize, string SortField, string SortType)
        {
            var demoList = new PageResult<Demo>();
            var demoModel = _demoRepository.GetAsIQuerable();
            var MaxPage = demoModel.Count() == 0 ? demoModel.Count() / PageSize : (demoModel.Count() / PageSize) + 1;
            if (PageIndex > MaxPage)
            {
                PageIndex = MaxPage; //超过最大页数默认获取最后一页
            }
            demoList.PageIndex = PageIndex;
            demoList.PageSize = PageSize;
            demoList.TotalCount = demoModel.Count();
            if (demoModel.Any())
            {
                demoList.list = await PaginationHelper.SortingAndPaging(demoModel.AsQueryable(), SortField, SortType, PageIndex, PageSize).ToListAsync();
            }
            return demoList;
        }

        /// <summary>
        /// 获取Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Demo> GetDemoByIDAsync(Guid ID)
        {
           var demoModel = await _demoRepository.FindAsync(ID);
            return demoModel;
        }

        /// <summary>
        /// 添加Demo
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Age"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> AddDemoAsync(string Name, string Sex, int Age, string Remark)
        {
            using (var tran = _context.Database.BeginTransaction())//开始事务
            {
                try
                {
                    Demo model = new Demo();
                    model.ID = Guid.NewGuid();
                    model.Name = Name;
                    model.Sex = Sex;
                    model.Age = Age;
                    model.Remark = Remark;
                    var result = new OperationResult<bool>();
                    result.data = await _demoRepository.AddAsync(model);
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
       /// <param name="ID"></param>
       /// <param name="Name"></param>
       /// <param name="Sex"></param>
       /// <param name="Age"></param>
       /// <param name="Remark"></param>
       /// <returns></returns>
        public async Task<OperationResult<bool>> UpdateDemoAsync(Guid ID, string Name, string Sex, int Age, string Remark)
        {
            using (var tran = _context.Database.BeginTransaction())//开始事务     
            {
                try
                {
                    var result = new OperationResult<bool>();
                    var demo = await _demoRepository.FindAsync(ID);
                    if (demo != null)
                    {
                        demo.Name = Name;
                        demo.Sex = Sex;
                        demo.Age = Age;
                        demo.Remark = Remark;
                        result.data = await _demoRepository.UpdateAsync(demo);
                        tran.Commit();//提交事务
                    }
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
            using (var tran = _context.Database.BeginTransaction())//开始事务
            {
                try
                {
                    var result = new OperationResult<bool>();
                    var demo = await _demoRepository.FindAsync(ID);
                    if (demo != null)
                    {
                        result.data = await _demoRepository.DeleteAsync(demo);
                        tran.Commit();//提交事务
                    }
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
