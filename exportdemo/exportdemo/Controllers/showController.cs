using exportdemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exportdemo.Controllers
{
    public class showController : Controller
    {
        public static readonly List<order> list = new List<order>
        {
            new order {OrderId ="111",Name ="ssss",Phone ="3333" },
            new order {OrderId ="112",Name ="ssss",Phone ="3333" },
            new order {OrderId ="113",Name ="ssss",Phone ="3333" },
            new order {OrderId ="114",Name ="ssss",Phone ="3333" },
            new order {OrderId ="115",Name ="ssss",Phone ="3333" }  ,
            new order {OrderId ="116",Name ="ssss",Phone ="3333" },
            new order {OrderId ="117",Name ="ssss",Phone ="3333" }

        };
        public List<order> getlist(string id )
        {
            return list.Where(i=>Convert.ToInt32( i.OrderId) >Convert.ToInt32( id)).ToList();
        }


        // GET: show
        public ActionResult Index(string id)
        {

            ViewBag.list = getlist(id);
            ViewData["list"] = getlist(id);

            return View();
        }


     
        public ActionResult ExportToExcel(   )
        {
            System.Web.HttpContext.Current.Response.Charset = "utf-8"; System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("123.xls", System.Text.Encoding.UTF8).ToString());
            

            System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
            //StringWriter tw = new StringWriter();
            System.Web.HttpContext.Current.Response.Output.Write("sdfsdfsdfsdfsdfsfsdf");
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
            return new EmptyResult();
        }

        [NonAction]
        protected string RenderViewToString(Controller controller, string viewName, string masterName)
        {
            IView view = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, masterName).View;
            using (StringWriter writer = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(controller.ControllerContext, view, controller.ViewData, controller.TempData, writer);
                viewContext.View.Render(viewContext, writer);
                return writer.ToString();
            }
        }
        [NonAction]
        protected string RenderPartialViewToString(Controller controller, string partialViewName)
        {
            IView view = ViewEngines.Engines.FindPartialView(controller.ControllerContext, partialViewName).View;
            using (StringWriter writer = new StringWriter())
            {
                ViewContext viewContext = new ViewContext(controller.ControllerContext, view, controller.ViewData, controller.TempData, writer);
                viewContext.View.Render(viewContext, writer);
                return writer.ToString();
            }
        }

        public ActionResult Export(string id)
        {

            //ViewBag.NoPaging = true;
            ViewBag.list = getlist(id);
            string viewHtml = RenderPartialViewToString(this, "Index");
            return File(System.Text.Encoding.UTF8.GetBytes(viewHtml), "application/ms-excel", string.Format("ccpi_{0}.xls", Guid.NewGuid()));
        }

    }
}