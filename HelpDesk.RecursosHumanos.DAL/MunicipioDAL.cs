using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HelpDesk.RecursosHumanos.DAL
{
   public class MunicipioDAL
    {

       public DataSet SelectmunicipioALL(int id_departamento)
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {

               SqlConnection oConn = CommonDb.ObtenerConnSql();
               SqlCommand oCmd = new SqlCommand("SP_select_Municipio", oConn);
               oCmd.CommandType = CommandType.StoredProcedure;
               SqlParameter idmun = new SqlParameter("@idDepartamento", id_departamento);
               oCmd.Parameters.Add(idmun);
               SqlDataAdapter da = new SqlDataAdapter(oCmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
       }

       public DataSet SelectmunicipioALL()
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {

               SqlConnection oConn = CommonDb.ObtenerConnSql();
               SqlCommand oCmd = new SqlCommand("SP_select_MunicipioTodos", oConn);
               oCmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(oCmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
       }

       public DataSet SelectDptoMunicipio(int id_municipio)
       {
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {

               SqlConnection oConn = CommonDb.ObtenerConnSql();
               SqlCommand oCmd = new SqlCommand("SP_select_DepartamentoPorMunicipio", oConn);
               oCmd.CommandType = CommandType.StoredProcedure;
               SqlParameter idmun = new SqlParameter("@Id", id_municipio);
               oCmd.Parameters.Add(idmun);
               SqlDataAdapter da = new SqlDataAdapter(oCmd);
               DataSet ds = new DataSet();
               da.Fill(ds);
               return ds;
           }
       }

    }
}
