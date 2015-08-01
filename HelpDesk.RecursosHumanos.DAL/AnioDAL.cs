using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.DAL
{
    public class AnioDAL
    {
        public DataSet getAnios()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {

                    SqlConnection oConn = CommonDb.ObtenerConnSql();
                    SqlCommand oCmd = new SqlCommand("SP_select_anios", oConn);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(oCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;

                }
                return null;
            }
        }
        public AnioDAL()
        {

        }

    }
}
