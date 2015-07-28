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
    public class HabilidadTecnicaDAL
    {
       
 public DataSet SelectHabilidadTecnicaALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {

                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_HabilidadTecnica", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds5 = new DataSet();
                da.Fill(ds5);
                return ds5;

            }
        }

 public List<HabilidadTecnicaE> ObtenerHablidadTecnicas()
 {
     throw new NotImplementedException();
 }
    }

}

    

