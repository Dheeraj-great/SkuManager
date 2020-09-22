using System;
using System.Web.Mvc;

namespace SkuManager.WebApp.Controllers
{
    public class SkuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}