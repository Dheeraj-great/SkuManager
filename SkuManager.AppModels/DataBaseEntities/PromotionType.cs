using System;
using System.Collections.Generic;

namespace SkuManager.AppModels.DataBaseEntities
{
    public partial class PromotionType
    {
        public PromotionType()
        {
            Promotion = new HashSet<Promotion>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Promotion> Promotion { get; set; }
    }
}
