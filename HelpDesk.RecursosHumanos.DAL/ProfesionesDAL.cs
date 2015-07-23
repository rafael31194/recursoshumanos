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
    public  class ProfesionesDAL
    {
        public DataSet SelectdepartamentoALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {

                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_Profesion", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds10 = new DataSet();
                da.Fill(ds10);
                return ds10;
            }
        }

        public List<ProfesionesE> ObtenerProfesiones()
        {
            throw new NotImplementedException();
        }
    }

}
