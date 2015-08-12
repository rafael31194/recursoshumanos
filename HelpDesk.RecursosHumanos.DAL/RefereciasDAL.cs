using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

       public int AgregarReferencias(RefecenciasE preferencias, int id, ref string oerro)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {
                   SqlCommand comando = new SqlCommand();
                   comando.Connection = _conn;
                   comando.CommandType = System.Data.CommandType.StoredProcedure;
                   comando.CommandText = "SP_insertar_referenciasConId";
                   comando.Parameters.AddWithValue("@id", id);
                   comando.Parameters.AddWithValue("@id_referencias", preferencias.id_referencias);
                   comando.Parameters.AddWithValue("@id_tipoReferencias", preferencias.id_tipoReferencias);
                   comando.Parameters.AddWithValue("@nombre", preferencias.nombre);
                   comando.Parameters.AddWithValue("@telefono", preferencias.telefono);
                   comando.Parameters.AddWithValue("@descripcion", preferencias.descripcion);

                   resultado = (int)comando.ExecuteScalar();

               }
               else
                   resultado = 0;
               oerro = "";
           }
           return resultado;
       }

       public int ActualizarReferencias(RefecenciasE preferencias, int id, ref string oerro)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {
                   SqlCommand comando = new SqlCommand();
                   comando.Connection = _conn;
                   comando.CommandType = System.Data.CommandType.StoredProcedure;
                   comando.CommandText = "SP_update_referenciasConId";
                   comando.Parameters.AddWithValue("@id", id);
                   comando.Parameters.AddWithValue("@id_referencias", preferencias.id_referencias);
                   comando.Parameters.AddWithValue("@id_tipoReferencias", preferencias.id_tipoReferencias);
                   comando.Parameters.AddWithValue("@nombre", preferencias.nombre);
                   comando.Parameters.AddWithValue("@telefono", preferencias.telefono);
                   comando.Parameters.AddWithValue("@descripcion", preferencias.descripcion);

                   resultado = comando.ExecuteNonQuery();

               }
               else
                   resultado = 0;
               oerro = "";
           }
           return resultado;
       }

       public int BorrarReferencia(int p, ref string oerro)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {

                   try
                   {

                       //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                       SqlCommand comm = new SqlCommand("DELETE FROM  [Referencias] WHERE [id_referencias]=" +
                      p + "", _conn);
                       return comm.ExecuteNonQuery();
                   }
                   catch (Exception ex)
                   {
                       //If Any Exception Will Occur then It Will Display That Message...
                       MessageBox.Show("Ocurrion un error al eliminar la Referencia.");
                       return resultado;
                       throw ex;
                   }
                   finally
                   {
                       //Finally Close the Connection...
                       _conn.Close();


                   }
               }
               else
               {
                   return resultado;
               }
           }
       }
    }
}
