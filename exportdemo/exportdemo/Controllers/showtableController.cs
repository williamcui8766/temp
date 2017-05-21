using exportdemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exportdemo.Controllers
{
    public class showtableController : Controller
    {
        // GET: showtable
        public ActionResult Index(List<order> list)
        {
            return View("table",list);
        }

   
    }
}