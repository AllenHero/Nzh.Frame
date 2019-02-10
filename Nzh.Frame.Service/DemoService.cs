﻿using Microsoft.EntityFrameworkCore;
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
        ///  获取Demo分页
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="SortExpression"></param>
        /// <returns></returns>
        public async Task<PageResult<Demo>> GetDemoPageAsyncList(QueryHelper query)
        {
            var demoPage = new PageResult<Demo>();
            var demoModel = _demoRepository.GetAllAsIQuerable();
            var sortType = query.sort_type == 2 ? "DESC" : "ASC"; //默认升序（ASC）
            var sortField = string.Empty;
            QueryFieldExtension.OrderFieldMapping().TryGetValue(query.sort_field, out sortField);
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = DEFAULT_SORT_FIELD; //默认按RankNo排序
            }
            var maxPage = demoModel.Count() == 0 ? demoModel.Count() / query.page_size : (demoModel.Count() / query.page_size) + 1;
            if (query.page_num > maxPage)
            {
                query.page_num = maxPage; //超过最大页数默认获取最后一页
            }
            demoPage.page_num = query.page_num;
            demoPage.page_size = query.page_size;
            demoPage.total = demoModel.Count();
            if (demoModel.Any())
            {
                demoPage.list = await PaginationHelper.SortingAndPaging(demoModel.AsQueryable(), sortField, sortType, query.page_num, query.page_size).ToListAsync();
            }
            return demoPage;
        }

        /// <summary>
        /// 获取单个Demo
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Demo> GetDemoByIDAsync(Guid ID)
        {
            var demoInfo = new Demo();
            demoInfo =await _demoRepository.FindAsync(ID);
            return demoInfo;
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
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OperationResult<bool>> UpdateDemoAsync(Demo model)
        {
            using (var tran = _context.Database.BeginTransaction())//开始事务
            {
                try
                {
                    var result = new OperationResult<bool>();
                    var demo = await _demoRepository.FindAsync(model.ID);
                    if (model != null)
                    {
                        demo.Name = model.Name;
                        demo.Sex = model.Sex;
                        demo.Age = model.Age;
                        demo.Remark = model.Remark;
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
