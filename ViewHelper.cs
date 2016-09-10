using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    /// <summary>
    /// 后台获取视图对应的字符串
    /// </summary>
    public class ViewHelper
    {
        /// <summary>
        /// 将View输出为字符串
        /// (注：不会执行对应的action方法)
        /// </summary>
        /// <param name="controller">Controller实例</param>
        /// <param name="viewName">如果view文件在当前Controller目录下，则直接输入文件名(例如：Toolbar)
        /// 否则，从根路径开始指定（例如：~/Views/User/Toolbar.cshtml）
        /// </param>
        /// <param name="masterName">模板页文件名（注：显示指定可修改Layout）</param>
        /// <returns></returns>
        public static string RenderViewToString(Controller controller, string viewName, string masterName)
        {
            IView view = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, masterName).View;

            using (StringWriter sw = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(controller.ControllerContext, view, controller.ViewData, controller.TempData, sw);
                viewContext.View.Render(viewContext, sw);
                return sw.ToString();
            }
        }
        /// <summary>
        /// 将PartialView输出字符串
        /// </summary>
        /// <param name="controller">controller实例</param>
        /// <param name="viewName">如果PartialView文件在当前Controller目录下，则直接输入文件名（例如：Toolbar）；
        /// 否则，从根路径开始指定（例如：~/View/User/Toolbar.cshtml）
        /// </param>
        /// <param name="model">构造页面所需要的实体参数</param>
        /// <returns>字符串</returns>
        public static string ReaderPartialViewToString(Controller controller, string viewName, object model)
        {
            IView view = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName).View;
            controller.ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(controller.ControllerContext, view, controller.ViewData, controller.TempData, sw);

                viewContext.View.Render(viewContext, sw);

                return sw.ToString();
            }
        }
    }
}
