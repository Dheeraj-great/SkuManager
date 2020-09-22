using SkuManager.FrameWorkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.BusinessService
{
    public class Test
    {
        public void TestMethod()
        {
            SKUEntities context = new SKUEntities();
            var listOfPromotion = context.Promotions;
        }
    }
}
