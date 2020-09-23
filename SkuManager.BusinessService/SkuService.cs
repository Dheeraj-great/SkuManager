using SkuManager.FrameWorkModels;
using SkuManager.FrameWorkModels.UI.Sku;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.BusinessService
{
    public class SkuService : BaseService
    {
        public List<SkuModel> GetAllSku()
        {
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
            List<SkuModel> resultList = new List<SkuModel>();
            using (this.connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sku", connection);
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
