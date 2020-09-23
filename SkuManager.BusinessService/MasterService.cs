using SkuManager.FrameWorkModels.UI.Promotion;
using SkuManager.FrameWorkModels.UI.Sku;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.BusinessService
{
    /// <summary>
    /// Master Service having methods to perform CRUD operations on the master tables
    /// </summary>
    public class MasterService : BaseService
    {
        /// <summary>
        /// Gets all the active promotions
        /// </summary>
        /// <returns>List of Promotion</returns>
        public List<Promotion> GetPromotions()
        {
            List<Promotion> resultList = new List<Promotion>();
            using (this.connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(Query.GetAllPromotions, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new Promotion()
                    {
                        Id = Convert.ToInt64(Convert.ToString(reader["Id"])),
                        PromotionTypeId = Convert.ToInt64(Convert.ToString(reader["PromotionTypeId"])),
                        Name = Convert.ToString(reader["Name"]),
                        IsActive = Convert.ToBoolean(Convert.ToString(reader["IsActive"])),
                        Rate = Convert.ToDecimal(Convert.ToString(reader["UnitPrice"])),
                    });
                }
                connection.Close();
            }
            return resultList;
        }
        
        /// <summary>
        /// Gets all the active promotion types
        /// </summary>
        /// <returns>List of PromotionType</returns>
        public List<PromotionType> GetPromotionTypes()
        {
            List<PromotionType> resultList = new List<PromotionType>();
            using (this.connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(Query.GetAllPromotionTypes, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new PromotionType()
                    {
                        Id = Convert.ToInt64(Convert.ToString(reader["Id"])),
                        Name = Convert.ToString(reader["Name"]),
                        IsActive = Convert.ToBoolean(Convert.ToString(reader["IsActive"])),
                    });
                }
                connection.Close();
            }
            return resultList;
        }
        
        /// <summary>
        /// Gets all promotion details based on promotion id, if id is null then it will get all
        /// the promotions
        /// </summary>
        /// <param name="promotionId"></param>
        /// <returns></returns>
        public List<PromotionDetails> GetAllPromotionDetailsByPromotionId(long? promotionId = null)
        {
            List<PromotionDetails> resultList = new List<PromotionDetails>();
            using (this.connection)
            {
                connection.Open();
                SqlCommand cmd;
                if(promotionId.HasValue)
                    cmd = new SqlCommand(Query.GetPromotionDetailsByPromotionId + Convert.ToString(promotionId), connection);
                else
                    cmd = new SqlCommand(Query.GetAllPromotionDetails, connection);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new PromotionDetails()
                    {
                        Id = Convert.ToInt64(Convert.ToString(reader["Id"])),
                        PromotionId = Convert.ToInt64(Convert.ToString(reader["PromotionId"])),
                        SkuId = Convert.ToInt64(Convert.ToString(reader["SkuId"])),
                        Quantity = Convert.ToInt64(Convert.ToString(reader["Quantity"])),
                        IsActive = Convert.ToBoolean(Convert.ToString(reader["IsActive"])),
                    });
                }
                connection.Close();
            }
            return resultList;
        }

        /// <summary>
        /// Gets all active Sku
        /// </summary>
        /// <returns>List of Sku</returns>
        public List<SkuModel> GetAllSku()
        {
            #region EF - NOT FUNCTIONAL
            ////EF Approach
            //SKUCS context = new SKUCS();
            //IQueryable<Sku> result = context.Sku;
            //if (result != null && result.Count() > 0)
            //{
            //    List<SkuModel> resultList = new List<SkuModel>();
            //    foreach (Sku item in result)
            //    {
            //        resultList.Add(new SkuModel()
            //        {
            //            Id = item.Id,
            //            Name = item.Name,
            //            UnitPrice = item.UnitPrice,
            //            IsActive = item.IsActive,
            //        });
            //    }
            //    return resultList;
            //}
            //return null;
            #endregion

            //Dapper Approach
            List<SkuModel> resultList = new List<SkuModel>();
            using (this.connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(Query.GetAllSkus, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new SkuModel()
                    {
                        Id = Convert.ToInt64(Convert.ToString(reader["Id"])),
                        Name = Convert.ToString(reader["Name"]),
                        IsActive = Convert.ToBoolean(Convert.ToString(reader["IsActive"])),
                        UnitPrice = Convert.ToDecimal(Convert.ToString(reader["UnitPrice"])),
                    });
                }
                connection.Close();
            }
            return resultList;
        }
    }
}
