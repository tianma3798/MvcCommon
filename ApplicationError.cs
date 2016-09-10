using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System.Web
{
    /// <summary>
    /// Mvc中  Global Error的处理
    /// </summary>
    public class ApplicationError
    {
        /// <summary>
        /// 处理Error的控制器实例
        /// </summary>
        public IController IContoller = null;
        /// <summary>
        /// 当前程序实例
        /// </summary>
        public HttpApplication Application = null;
        /// <summary>
        /// 当前请求上下文
        /// </summary>
        public HttpRequest Request = null;
        /// <summary>
        /// 当前响应上下文
        /// </summary>
        public HttpResponse Response = null;
        /// <summary>
        /// 当前服务器对象
        /// </summary>
        public HttpServerUtility Server = null;
        /// <summary>
        /// 构造器
        /// </summary>
        ///  <param name="app">当前服务器对象</param>
        /// <param name="errorController">处理Error的控制器实例</param>
        public ApplicationError(HttpApplication app, IController errorController)
        {
            this.Application = app;
            this.IContoller = errorController;
            Init();
        }
        /// <summary>
        /// 构造器
        /// </summary>
        ///  <param name="app">当前服务器对象</param>
        public ApplicationError(HttpApplication app)
        {
            this.Application = app;
            Init();
        }
        /// <summary>
        /// 异常事件处理
        /// </summary>
        public void DoError()
        {
            //是否自定义处理error
            if (Common.ConfigValue.IsCustomError == false)
                return;
            Exception exception = Server.GetLastError();
            Response.Clear();
            HttpException httpException = exception as HttpException;
            RouteData route = new RouteData();
            route.Values.Add("controller", "HttpError");
            if (Request.Url.Segments.Any(q => q.Equals("httperror", StringComparison.InvariantCultureIgnoreCase)))
            {
                Server.ClearError();
                Response.Write("HttpError出错或对应的模板出错！");
                Response.StatusCode = 500;
                Response.End();
                return;
            }
            if (httpException == null)
            {
                route.Values.Add("action", "Status500");
                route.Values.Add("msg", exception.Message);
                Response.StatusCode = 500;
            }
            else
            {
                if (httpException.GetHttpCode() == 404)
                {
                    route.Values.Add("action", "Status404");
                    Response.StatusCode = 404;
                }
                else if (httpException.GetHttpCode() == 509)
                {
                    route.Values.Add("action", "Status509");
                    Response.StatusCode = 509;
                }
                else
                {
                    route.Values.Add("action", "Status500");
                    Response.StatusCode = 500;
                }
                route.Values.Add("msg", httpException.Message);
            }
            IController errorController = this.IContoller;
            errorController.Execute(new RequestContext(new HttpContextWrapper(Application.Context), route));
            Server.ClearError();
            Response.End();
        }
        /// <summary>
        /// 初始化处理
        /// </summary>
        private void Init()
        {
            this.Request = Application.Request;
            this.Response = Application.Response;
            this.Server = Application.Server;
        }
    }
}