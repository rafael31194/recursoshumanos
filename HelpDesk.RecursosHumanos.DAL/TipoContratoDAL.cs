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
   public class TipoContratoDAL
    {
       public DataSet selectTipoContratoALL()
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               SqlConnection oConn = CommonDb.ObtenerConnSql();
               SqlCommand oCmd = new SqlCommand("SP_select_TipoContrato", oConn);
               oCmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(oCmd);
               DataSet dstipoContrato = new DataSet();
               da.Fill(dstipoContrato);
               return dstipoContrato;
           }
       }
       public List<TipoContratoDAL> obtenerTipoContrato()
       {
           throw new NotImplementedException();
       }

       public List<TipoContratoE> ObtenerTipoContrato()
       {
           throw new NotImplementedException();
       }
    }
}
