using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuManager.BusinessService
{
    public abstract class BaseService
    {
        protected SqlConnection connection;
        public BaseService()
        {
            connection = new SqlConnection("server=.;database=SKU;Integrated Security=SSPI;");
        }
    }
}
