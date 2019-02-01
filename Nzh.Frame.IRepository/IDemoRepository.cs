using Nzh.Frame.IRepository.Base;
using Nzh.Frame.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.IRepository
{
    public interface IDemoRepository : IBaseRepository<Demo>
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveAsync(Demo model);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Save(Demo model);
    }
}
