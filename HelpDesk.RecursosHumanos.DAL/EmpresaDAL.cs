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
   public class EmpresaDAL
    {
       public DataSet SelectEmpresaALL()
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           { 
           
               SqlConnection _oConn = CommonDb.ObtenerConnSql();
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_empresas", oConn);
                   oCmd.CommandType = CommandType.StoredProcedure;
                   SqlDataAdapter da = new SqlDataAdapter(oCmd);
                   DataSet dsEmpresa = new DataSet();
                   da.Fill(dsEmpresa);
                   return dsEmpresa;
           }
        }
       public List<EmpresaE> ObtenerEmpresa()
       {
           throw new NotImplementedException();
       }
     }
 }

