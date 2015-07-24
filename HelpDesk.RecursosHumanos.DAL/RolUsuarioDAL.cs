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
    public class RolUsuarioDAL
    {
        public DataSet SelectRolALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oconn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_rol", oconn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da1 = new SqlDataAdapter(oCmd);
                DataSet ds10 = new DataSet();
                da1.Fill(ds10);
                return ds10;
            }
        }
        public List<RolUsuarioE> obtenerRolUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
