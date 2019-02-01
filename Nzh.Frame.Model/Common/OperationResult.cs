using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace Nzh.Frame.Model.Common
{
    /// <summary>
    /// 操作返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class OperationResult<T>
    {
        [DataMember]
        public virtual T Data { get; set; }

        [DataMember]
        public bool Success { get; set; } = true;

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string Time { get; set; } = DateTime.Now.ToString("o", CultureInfo.InvariantCulture);

        [DataMember]
        public string TimeSpan { get; set; }
    }
}
