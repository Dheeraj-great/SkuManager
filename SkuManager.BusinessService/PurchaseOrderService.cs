using SkuManager.FrameWorkModels.UI.Promotion;
using SkuManager.FrameWorkModels.UI.Sku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.BusinessService
{
    public class PurchaseOrderService
    {
        MasterService _service;
        public PurchaseOrderService()
        {
            _service = new MasterService();
        }

        /// <summary>
        /// Method to calculate the purchase amount based on the cart items
        /// </summary>
        /// <param name="myPurchase"></param>
        /// <returns></returns>
        public decimal CalculatePurchaseAmount(CartModel myPurchase)
        {
            decimal totalAmount = 0;
            try
            {
                LoadMasterDataIntoSession();
                foreach (SkuModel sku in myPurchase.CartItems)
                {
                    if (GetPromotionType(sku.Id) == 1)
                    {
                        totalAmount = totalAmount + GetSkuAmount(sku);
                    }
                }
                totalAmount = totalAmount + GetSkuAmount(myPurchase);
            }
            catch(Exception ex)
            {
                totalAmount = 0;
                ///Handle Generic Exception if any.... Log4Net or NLog packages 
                ///can be used for logging events...
            }
            return totalAmount;
        }

        /// <summary>
        /// This method sets Session Variables
        /// </summary>
        private void LoadMasterDataIntoSession()
        {
            try
            {
                if (SessionManager.PromotionList == null)
                {
                    List<Promotion> promotionList = _service.GetPromotions();
                    SessionManager.PromotionList = promotionList;
                }
                if (SessionManager.PromotionDetailsList == null)
                {
                    List<PromotionDetails> promotionDetailsList = _service.GetAllPromotionDetailsByPromotionId();
                    SessionManager.PromotionDetailsList = promotionDetailsList;
                }
                if (SessionManager.PromotionTypeList == null)
                {
                    List<PromotionType> promotionTypeList = _service.GetPromotionTypes();
                    SessionManager.PromotionTypeList = promotionTypeList;
                }
                if (SessionManager.SkuList == null)
                {
                    List<SkuModel> skuList = _service.GetAllSku();
                    SessionManager.SkuList = skuList;
                }
                SessionManager.IsItemLocked = false;
            }
            catch(Exception ex)
            {
                ///Handle Method Specific Exception if any.... 
                ///Log4Net or NLog packages can be used for logging events...
            }
        }

        /// <summary>
        /// Method to get Sku Amount based on Sku Id
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns>decimal</returns>
        private decimal GetSkuAmount(long? skuId)
        {
            decimal skuAmount = 0;
            if (SessionManager.PromotionDetailsList != null && SessionManager.PromotionList != null)
            {
                var result = (from promotionDetail in SessionManager.PromotionDetailsList
                              join promotion in SessionManager.PromotionList
                              on promotionDetail.PromotionId equals promotion.Id
                              join skuItem in SessionManager.SkuList
                              on promotionDetail.SkuId equals skuItem.Id
                              where promotionDetail.SkuId == skuId
                              select new
                              {
                                  SkuQuantity = promotionDetail.Quantity,
                                  PromotionType = promotion.PromotionTypeId,
                                  SkuUnitPrice = skuItem.UnitPrice,
                                  PromotionAmount = promotion.Rate
                              }).ToList();

                if (result != null)
                {
                    if (result.Count > 1)
                    {
                        //Handle scenario where there are multiple promotion offers for 1 SKU
                    }
                    else if (result.Count > 0)
                    {
                        skuAmount = result[0].PromotionAmount;
                    }
                }
            }
            SessionManager.IsItemLocked = true;
            return skuAmount;
        }

        /// <summary>
        /// Method to get Sku Amount for a Sku item
        /// </summary>
        /// <param name="sku"></param>
        /// <returns>decimal</returns>
        private decimal GetSkuAmount(SkuModel sku)
        {
            decimal skuAmount = 0;
            if(SessionManager.PromotionDetailsList != null && SessionManager.PromotionList != null)
            {
                var result = (from promotionDetail in SessionManager.PromotionDetailsList
                              join promotion in SessionManager.PromotionList
                              on promotionDetail.PromotionId equals promotion.Id
                              join skuItem in SessionManager.SkuList
                              on promotionDetail.SkuId equals skuItem.Id
                              where promotionDetail.SkuId == sku.Id
                              select new
                              {
                                  SkuQuantity = promotionDetail.Quantity,
                                  PromotionType = promotion.PromotionTypeId,
                                  SkuUnitPrice = skuItem.UnitPrice,
                                  PromotionAmount = promotion.Rate
                              }).ToList();

                if(result != null)
                {
                    if(result.Count > 1)
                    {
                        //Handle scenario where there are multiple promotion offers for 1 SKU
                    }
                    else if(result.Count > 0)
                    {
                        long? promotionSkuQuantity = sku.PurchaseQuantity / result[0].SkuQuantity;
                        long? remainingSkuQuantity = sku.PurchaseQuantity % result[0].SkuQuantity;
                        decimal? tempAmount = remainingSkuQuantity * result[0].SkuUnitPrice;
                        tempAmount = tempAmount + (promotionSkuQuantity * result[0].PromotionAmount);
                        skuAmount = tempAmount.HasValue ? tempAmount.Value : 0;
                    }
                }
            }
            return skuAmount;
        }

        /// <summary>
        /// Method to get Sku Amount for a Cart Item
        /// </summary>
        /// <param name="myPurchase"></param>
        /// <returns>decimal</returns>
        private decimal GetSkuAmount(CartModel myPurchase)
        {
            decimal skuAmount = 0;
            List<SkuModel> comboSkuList = new List<SkuModel>();
            List<long?> comboSkuQuantity = new List<long?>();
            foreach (SkuModel sku in myPurchase.CartItems)
            {
                if(GetPromotionType(sku.Id) == 2)
                {
                    comboSkuList.Add(sku);
                    comboSkuQuantity.Add(sku.PurchaseQuantity);
                }
            }

            long? minPurchaseQuantity = comboSkuList.Select(q => q.PurchaseQuantity).Min();
            foreach (SkuModel sku in comboSkuList)
            {
                if (!SessionManager.IsItemLocked.Value)
                {
                    skuAmount = GetSkuAmount(sku.Id);
                }
                if (sku.PurchaseQuantity - minPurchaseQuantity != 0)
                {
                    skuAmount = skuAmount + 
                        (SessionManager.SkuList.Where(q => q.Id == sku.Id).Any() ? SessionManager.SkuList.FirstOrDefault(q => q.Id == sku.Id).UnitPrice.Value * (sku.PurchaseQuantity.Value - minPurchaseQuantity.Value) : 0);
                }
            }

            return skuAmount;
        }

        /// <summary>
        /// Method to get Promotion Type for a Sku
        /// </summary>
        /// <param name="skuId"></param>
        /// <returns>long</returns>
        private long GetPromotionType(long skuId)
        {
            var result = (from promotionDetail in SessionManager.PromotionDetailsList
                          join promotion in SessionManager.PromotionList
                          on promotionDetail.PromotionId equals promotion.Id
                          join skuItem in SessionManager.SkuList
                          on promotionDetail.SkuId equals skuItem.Id
                          where promotionDetail.SkuId == skuId
                          select new
                          {
                              SkuQuantity = promotionDetail.Quantity,
                              PromotionType = promotion.PromotionTypeId,
                              SkuUnitPrice = skuItem.UnitPrice,
                              PromotionAmount = promotion.Rate
                          }).ToList();
            if (result != null)
                return result[0].PromotionType;
            else
                return -1;
        }
    }
}
