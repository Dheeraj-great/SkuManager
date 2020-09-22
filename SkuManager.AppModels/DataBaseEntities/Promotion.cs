using System;
using System.Collections.Generic;

namespace SkuManager.AppModels.DataBaseEntities
{
    public partial class Promotion
    {
        public Promotion()
        {
            PromotionDetails = new HashSet<PromotionDetails>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long PromotionTypeId { get; set; }
        public decimal Rate { get; set; }
        public bool? IsActive { get; set; }

        public virtual PromotionType PromotionType { get; set; }
        public virtual ICollection<PromotionDetails> PromotionDetails { get; set; }
    }
}
