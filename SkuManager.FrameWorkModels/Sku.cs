//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkuManager.FrameWorkModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sku
    {
        public Sku()
        {
            this.PromotionDetails = new HashSet<PromotionDetails>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<PromotionDetails> PromotionDetails { get; set; }
    }
}
