using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Times()
        {
            return View();
        }
    }
}