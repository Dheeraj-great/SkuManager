using SkuManager.FrameWorkModels.UI.Promotion;
using SkuManager.FrameWorkModels.UI.Sku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SkuManager.BusinessService
{
    public static class SessionManager
    {
        public static List<Promotion> PromotionList { 
            get
            {
                return HttpContext.Current.Session["PromotionList"] == null ? null : (List<Promotion>)HttpContext.Current.Session["PromotionList"];
            }
            set {
                HttpContext.Current.Session["PromotionList"] = value;
            } 
        }
        
        public static List<PromotionDetails> PromotionDetailsList { 
            get
            {
                return HttpContext.Current.Session["PromotionDetailsList"] == null ? null : (List<PromotionDetails>)HttpContext.Current.Session["PromotionDetailsList"];
            }
            set {
                HttpContext.Current.Session["PromotionDetailsList"] = value;
            } 
        }

        public static List<PromotionType> PromotionTypeList
        {
            get
            {
                return HttpContext.Current.Session["PromotionTypeList"] == null ? null : (List<PromotionType>)HttpContext.Current.Session["PromotionTypeList"];
            }
            set
            {
                HttpContext.Current.Session["PromotionTypeList"] = value;
            }
        }

        public static List<SkuModel> SkuList
        {
            get
            {
                return HttpContext.Current.Session["SkuList"] == null ? null : (List<SkuModel>)HttpContext.Current.Session["SkuList"];
            }
            set
            {
                HttpContext.Current.Session["SkuList"] = value;
            }
        }
        
        public static bool? IsItemLocked
        {
            get
            {
                return HttpContext.Current.Session["IsItemLocked"] == null ? (bool?)null : (bool)HttpContext.Current.Session["IsItemLocked"];
            }
            set
            {
                HttpContext.Current.Session["IsItemLocked"] = value;
            }
        }
    }
}
