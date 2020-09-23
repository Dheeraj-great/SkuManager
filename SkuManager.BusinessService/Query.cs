using SkuManager.FrameWorkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.BusinessService
{
    public class Query
    {
        public const string GetAllSkus = "SELECT * FROM [dbo].[Sku] WHERE IsActive = 1";
        public const string GetAllPromotions = "SELECT * FROM [dbo].[Promotion] WHERE IsActive = 1";
        public const string GetPromotionDetailsByPromotionId = "SELECT * FROM [dbo].[PromotionDetails] WHERE IsActive = 1 AND PromotionId = ";
        public const string GetAllPromotionDetails = "SELECT * FROM [dbo].[PromotionDetails] WHERE IsActive = 1";
        public const string GetAllPromotionTypes = "SELECT * FROM [dbo].[PromotionType] WHERE IsActive = 1";
    }
}
