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
    public class SituacionProfesionalDAL
    {
        public DataSet SelectSituacionProfeALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_SituacionProfesional", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        public List<SituacionProfesionalE> obtenersituacionp()
        {
            throw new NotImplementedException();
        }
    }
}
