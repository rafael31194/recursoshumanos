using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;

namespace HelpDesk.RecursosHumanos.DAL
{
    public class NivelDAL
    {
        public DataSet SelectnivelALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_Nivel", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds4 = new DataSet();
                da.Fill(ds4);
                return ds4;

            }
        }

        public List<NivelE> ObtenerNivel()
        {
            throw new NotImplementedException();
        }
    }
}
