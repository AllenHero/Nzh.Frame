using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Model.Common
{
    public class QueryHelper
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sort_field { get; set; }

        /// <summary>
        /// 排序方式 1: ASC(升序) 或 2: DESC(降序)
        /// </summary>
        public int sort_type { get; set; }

        /// <summary>
        /// 分页起始页
        /// </summary>
        public int page_num { get; set; }

        /// <summary>
        /// 每页显示的条数
        /// </summary>
        public int page_size { get; set; }

    }
}
