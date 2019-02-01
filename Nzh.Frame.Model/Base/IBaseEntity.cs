using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Model.Base
{
    /// <summary>
    /// 基础实体接口
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        Guid ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        Guid CreateID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        Guid UpdateID { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime DeleteTime { get; set; }

        /// <summary>
        /// 删除人
        /// </summary>
        Guid DeleteID { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        int IsDelete { get; set; }
    }
}
