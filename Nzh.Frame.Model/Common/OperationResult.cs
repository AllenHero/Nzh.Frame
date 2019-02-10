using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Nzh.Frame.Model.Common
{
    public class OperationResult
    {
        public int code { get; set; }

        public string msg { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public OperationResult()
        {
            code = 0;
            msg = "成功";
        }
        public T data { get; set; }
    }
}
