using System;
using System.Collections.Generic;

namespace SkuManager.AppModels.DataBaseEntities
{
    public partial class Sku
    {
        public Sku()
        {
            PromotionDetails = new HashSet<PromotionDetails>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<PromotionDetails> PromotionDetails { get; set; }
    }
}
