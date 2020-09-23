using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkuManager.BusinessService;
using SkuManager.FrameWorkModels.UI.Sku;
using System.Collections.Generic;

namespace SkuManager.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScenarioA()
        {
            CartModel testModel = new CartModel();
            testModel.CartItems = new List<SkuModel>()
            {
                new SkuModel(){ Id = 1, PurchaseQuantity = 1},
                new SkuModel(){ Id = 2, PurchaseQuantity = 1},
                new SkuModel(){ Id = 3, PurchaseQuantity = 1},
            };

            PurchaseOrderService service = new PurchaseOrderService();
            decimal result = service.CalculatePurchaseAmount(testModel);
            Assert.AreEqual(100, result);
        }
    }
}
