using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;

namespace HelpDesk.RecursosHumanos.DAL
{
   public class ExperienciaLaboralDAL
    {
       public int GuardarExpLaboral(ExpLaboralE pexpeLaboral, ref string oError)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {
                   SqlCommand comando = new SqlCommand();
                   comando.Connection = _conn;
                   comando.CommandType = System.Data.CommandType.StoredProcedure;
                   comando.CommandText = "SP_insertar_ExperienciaLaboral";
                   comando.Parameters.AddWithValue("@id_experienciaLaboral", pexpeLaboral.id_experienciaLaboral);
                   comando.Parameters.AddWithValue("@nombreEmpresa", pexpeLaboral.nombreEmpresa);
                   comando.Parameters.AddWithValue("@cargoDesempe", pexpeLaboral.cargoDesp);
                   comando.Parameters.AddWithValue("@descripcionPuesto", pexpeLaboral.descripPuesto);
                   comando.Parameters.AddWithValue("@fechaIncio", pexpeLaboral.fechaInicio);
                   comando.Parameters.AddWithValue("@fechaFin", pexpeLaboral.fechaFin);

                   resultado = comando.ExecuteNonQuery();

               }

               else
                   resultado = 0;
               oError = "";
           }
           return resultado;
       }
    }
}
