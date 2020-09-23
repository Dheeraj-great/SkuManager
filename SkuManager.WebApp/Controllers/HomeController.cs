using SkuManager.BusinessService;
using SkuManager.FrameWorkModels.UI.Sku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkuManager.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test(string scenario)
        {
            CartModel testModel = new CartModel();
            if(scenario == "A")
                testModel.CartItems = new List<SkuModel>()
                {
                    new SkuModel(){ Id = 1, PurchaseQuantity = 1},
                    new SkuModel(){ Id = 2, PurchaseQuantity = 1},
                    new SkuModel(){ Id = 3, PurchaseQuantity = 1},
                };
            else if(scenario == "B")
                testModel.CartItems = new List<SkuModel>()
                {
                    new SkuModel(){ Id = 1, PurchaseQuantity = 5},
                    new SkuModel(){ Id = 2, PurchaseQuantity = 5},
                    new SkuModel(){ Id = 3, PurchaseQuantity = 1},
                };
            else if (scenario == "C")
                testModel.CartItems = new List<SkuModel>()
                {
                    new SkuModel(){ Id = 1, PurchaseQuantity = 3},
                    new SkuModel(){ Id = 2, PurchaseQuantity = 5},
                    new SkuModel(){ Id = 3, PurchaseQuantity = 1},
                    new SkuModel(){ Id = 4, PurchaseQuantity = 1},
                };

            PurchaseOrderService service = new PurchaseOrderService();
            decimal result = service.CalculatePurchaseAmount(testModel);
            return View("~/Views/Home/Index.cshtml", "~/Views/Shared/_Layout.cshtml", result.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}