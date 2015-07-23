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
   public class tipoReferenciaDAL
    {
       public DataSet SelecttipoReferenciaALL()
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql()) 
           {
               SqlConnection oConn = CommonDb.ObtenerConnSql();
               SqlCommand oCmd = new SqlCommand("SP_select_tipoReferencia", oConn);
               oCmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(oCmd);
               DataSet ds8 = new DataSet();
               da.Fill(ds8);
               return ds8;
           }
       }


       public List<TipoReferenciaE> ObtenerTipoReferencia()
       {
           throw new NotImplementedException();
       }
    }
}
