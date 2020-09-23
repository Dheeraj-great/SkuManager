using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.FrameWorkModels.UI.Promotion
{
    public class Promotion
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PromotionTypeId { get; set; }
        public decimal Rate { get; set; }
        public bool IsActive { get; set; }
    }

    public class PromotionType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }

    public class PromotionDetails
    {
        public long Id { get; set; }
        public Nullable<long> PromotionId { get; set; }
        public Nullable<long> SkuId { get; set; }
        public Nullable<long> Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
