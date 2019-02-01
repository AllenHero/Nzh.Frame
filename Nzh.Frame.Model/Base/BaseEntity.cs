using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Model.Base
{

    /// <summary>
    /// 基础实体
    /// </summary>
    public class BaseEntity: IBaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid CreateID { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public Guid UpdateID { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime  DeleteTime { get; set; }

        /// <summary>
        /// 删除人
        /// </summary>
        public Guid  DeleteID { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int  IsDelete { get; set; } = 0;
    }
}
