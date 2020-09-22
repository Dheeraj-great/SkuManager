using System;
using System.Collections.Generic;

namespace SkuManager.AppModels.DataBaseEntities
{
    public partial class PromotionDetails
    {
        public long Id { get; set; }
        public long? PromotionId { get; set; }
        public long? SkuId { get; set; }
        public long? Quantity { get; set; }
        public bool? IsActive { get; set; }

        public virtual Promotion Promotion { get; set; }
        public virtual Sku Sku { get; set; }
    }
}
