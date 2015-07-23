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
   public  class RefereciasDAL
    {
       public int GuardarReferencias(RefecenciasE preferencias, ref string oError)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {
                   SqlCommand comando = new SqlCommand();
                   comando.Connection = _conn;
                   comando.CommandType = System.Data.CommandType.StoredProcedure;
                   comando.CommandText = "SP_insertar_referencias";
                   comando.Parameters.AddWithValue("@id_referencias", preferencias.id_referencias);
                   comando.Parameters.AddWithValue("@id_tipoReferencias", preferencias.id_tipoReferencias);
                   comando.Parameters.AddWithValue("@nombre", preferencias.nombre);
                   comando.Parameters.AddWithValue("@telefono", preferencias.telefono);
                   comando.Parameters.AddWithValue("@descripcion", preferencias.descripcion);

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
