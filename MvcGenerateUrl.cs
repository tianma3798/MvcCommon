using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace System.Web.Mvc
{
    /// <summary>
    /// MVC,一个网站多域名， 链接产生基类
    /// </summary>
    public class MvcGenerateUrl
    {
        StringBuilder _Builder = new StringBuilder(100);
        /// <summary>
        /// 获取或设置 域名，不带http
        /// </summary>
        public string DomainName { get; set; }
        /// <summary>
        /// 判断是否是本地测试
        /// </summary>
        public static bool IsLocal
        {
            get
            {
                return HttpContext.Current.Request.Url.Host.Contains("localhost");
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="DomainName"></param>
        public MvcGenerateUrl(string DomainName)
        {
            this.DomainName = DomainName;
        }

        #region 生成链接，指定controller，action等
        /// <summary>
        /// 不指定返回带http，的根域名
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            return _Builder.ToString();
        }
        /// <summary>
        /// 只有controller 的地址生成
        /// </summary>
        /// <returns></returns>
        public string GetUrl(string controller, bool IsHtml = false)
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            _Builder.Append("/").Append(controller);
            if (IsHtml)
                _Builder.Append(".html");
            else
                _Builder.Append("/");
            return _Builder.ToString();
        }
        /// <summary>
        /// 有controller，action或一级分类的地址生成
        /// </summary>
        /// <returns></returns>
        public string GetUrl(string controller, string action, bool IsHtml = false)
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            _Builder.Append("/").Append(controller);
            _Builder.Append("/").Append(action);
            if (IsHtml)
                _Builder.Append(".html");
            else
                _Builder.Append("/");
            return _Builder.ToString();
        }
        /// <summary>
        /// 有controller， 有ID 的地址生成
        /// </summary>
        public string GetUrl(string controller, int id, bool IsHtml = true)
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            _Builder.Append("/").Append(controller);
            _Builder.Append("/").Append(id);
            if (IsHtml)
                _Builder.Append(".html");
            else
                _Builder.Append("/");
            return _Builder.ToString();
        }
        /// <summary>
        /// 有controller ，有action或一级分类,有ID 的地址生成
        /// </summary>
        public string GetUrl(string controller, string action, int id, bool IsHtml = true)
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            _Builder.Append("/").Append(controller);
            _Builder.Append("/").Append(action);
            _Builder.Append("/").Append(id);
            if (IsHtml)
                _Builder.Append(".html");
            else
                _Builder.Append("/");
            return _Builder.ToString();
        }
        /// <summary>
        /// 有controller ，有action或一级分类,二级分类，没有ID 的地址生成
        /// </summary>
        public string GetUrl(string controller, string action, string cla, bool IsHtml = false)
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            _Builder.Append("/").Append(controller);
            _Builder.Append("/").Append(action);
            _Builder.Append("/").Append(cla);
            if (IsHtml)
                _Builder.Append(".html");
            else
                _Builder.Append("/");
            return _Builder.ToString();
        }
        /// <summary>
        /// 有controller ，有action或一级分类,二级分类，有ID 的地址生成
        /// </summary>
        public string GetUrl(string controller, string action, string cla, int id, bool IsHtml = true)
        {
            _Builder.Append("http://");
            _Builder.Append(DomainName);
            _Builder.Append("/").Append(controller);
            _Builder.Append("/").Append(action);
            _Builder.Append("/").Append(cla);
            _Builder.Append("/").Append(id);
            if (IsHtml)
                _Builder.Append(".html");
            else
                _Builder.Append("/");
            return _Builder.ToString();
        }
        #endregion
    }
}
