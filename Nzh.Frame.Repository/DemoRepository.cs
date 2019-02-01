using Nzh.Frame.IRepository;
using Nzh.Frame.Model;
using Nzh.Frame.Repository.Base;
using Nzh.Frame.Repository.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.Repository
{
    public class DemoRepository : BaseRepository<Demo>, IDemoRepository
    {
        public DemoRepository(EFDbContext context)
            : base(context)
        { }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SaveAsync(Demo model)
        {
            try
            {
                var demo = GetSingle(model.ID);
                if (demo == null)
                {
                    return await AddAsync(model);
                }  
                else
                {
                    demo.Name = model.Name;
                    demo.Sex = model.Sex;
                    demo.Age = model.Age;
                    demo.Remark = model.Remark;
                    return await UpdateAsync(demo);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Save(Demo model)
        {
            try
            {
                var demo = GetSingle(x => x.ID == model.ID);
                if (demo == null)
                {
                    Add(model);
                }
                else
                {
                    demo.Name = model.Name;
                    demo.Sex = model.Sex;
                    demo.Age = model.Age;
                    demo.Remark = model.Remark;
                    Update(demo);
                }
                return Commit() >= 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
