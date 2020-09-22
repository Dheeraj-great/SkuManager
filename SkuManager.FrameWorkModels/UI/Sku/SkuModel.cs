using System;
using System.Collections.Generic;
using System.Text;

namespace SkuManager.FrameWorkModels.UI.Sku
{
    public class SkuModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool? IsActive { get; set; }
    }

    public class SkuIndexViewModel
    {
        public List<SkuModel> SkuList { get; set; }
    }
}
