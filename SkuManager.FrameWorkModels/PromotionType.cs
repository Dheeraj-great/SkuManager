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
    
    public partial class PromotionType
    {
        public PromotionType()
        {
            this.Promotions = new HashSet<Promotion>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<Promotion> Promotions { get; set; }
    }
}