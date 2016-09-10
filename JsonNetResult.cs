using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    /// <summary>
    /// 继承JsonResut，重写序列化方式
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        /// <summary>
        /// 序列化配置
        /// </summary>
        public JsonSerializerSettings Settings { get; private set; }
        /// <summary>
        /// 日期格式化字符串
        /// </summary>
        public string DateFormatString { get; set; }
        /// <summary>
        /// 默认构造器
        /// </summary>
        public JsonNetResult()
        {
            DateFormatString = "yyyy-MM-dd";
            Settings = new JsonSerializerSettings
            {
                //这句是解决问题的关键,也就是json.net官方给出的解决配置选项.                 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = DateFormatString
            };
        }
        /// <summary>
        /// 构造器，指定转换时日期格式
        /// </summary>
        /// <param name="dateFormat"></param>
        public JsonNetResult(string dateFormat)
        {
            DateFormatString = dateFormat;
            Settings = new JsonSerializerSettings()
            {
                //这句是解决问题的关键,也就是json.net官方给出的解决配置选项.                 
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = DateFormatString
            };
        }
        /// <summary>
        /// 重写 序列化 方法
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;
            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;
            var scriptSerializer = JsonSerializer.Create(this.Settings);
            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, this.Data);
                response.Write(sw.ToString());
            }
        }
    }
}