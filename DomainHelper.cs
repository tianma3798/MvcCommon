using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web
{
    /// <summary>
    /// 线上域名常用封装
    /// </summary>
    public class DomainHelper
    {
        /// <summary>
        /// 获取配置文件中的 二级域名
        /// </summary>
        public static string Domain = ConfigValue.Get("Domain");
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
        /// 获取子域名信息
        /// </summary>
        /// <param name="sub">二级子域名名称</param>
        /// <returns></returns>
        public static string GetSubDomain(string sub)
        {
            return sub + "." + Domain;
        }
        /// <summary>
        /// 主站域名
        /// </summary>
        public static string WWW
        {
            get
            {
                return "www." + Domain;
            }
        }
        /// <summary>
        /// 后台管理域名
        /// </summary>
        public static string Manage
        {
            get
            {
                return "manage." + Domain;
            }
        }
        /// <summary>
        /// 邮件程序
        /// </summary>
        public static string Email
        {
            get
            {
                return "email." + Domain;
            }
        }
        /// <summary>
        /// 视频程序
        /// </summary>
        public static string Video
        {
            get
            {
                return "video." + Domain;
            }
        }
        /// <summary>
        /// 服务程序
        /// </summary>
        public static string Service
        {
            get
            {
                return "service." + Domain;
            }
        }
        /// <summary>
        /// API, 程序
        /// </summary>
        public static string API
        {
            get
            {
                return "api." + Domain;
            }
        }
        /// <summary>
        /// 手机 程序
        /// </summary>
        public static string Mobile
        {
            get
            {
                return "m." + Domain;
            }
        }
        /// <summary>
        /// 微信管理程序
        /// </summary>
        public static string WX
        {
            get
            {
                return "wx." + Domain;
            }
        }
    }
}