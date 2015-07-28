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
   public class TipoEducacionDAL
    {
       public DataSet SelectTipoEducacionALL()
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               SqlConnection oConn = CommonDb.ObtenerConnSql();
               SqlCommand oCmd = new SqlCommand("SP_SELECT_TipoEducacion", oConn);
               oCmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(oCmd);
               DataSet ds3 = new DataSet();
               da.Fill(ds3);
               return ds3;

           }
       }

       public List<TipoEducacionE> ObtenerTipoeducacion()
       {
           throw new NotImplementedException();
       }
    }
}


