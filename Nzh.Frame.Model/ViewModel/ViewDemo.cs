using System;
using System.Collections.Generic;
using System.Text;

namespace Nzh.Frame.Model.ViewModel
{
    /// <summary>
    /// ViewDemo 
    /// </summary>
    public class ViewDemo
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }

        public string Remark { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public Guid CreateID { get; set; }

        public DateTime UpdateTime { get; set; }

        public Guid UpdateID { get; set; }

        public DateTime DeleteTime { get; set; }

        public Guid DeleteID { get; set; }

        public int IsDelete { get; set; } = 0;
    }
}
