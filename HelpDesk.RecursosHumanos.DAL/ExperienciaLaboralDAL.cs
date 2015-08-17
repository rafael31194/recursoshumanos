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

       public int AgregarExpLaboral(ExpLaboralE pexpeLaboral, int id, ref string oerro)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {
                   SqlCommand comando = new SqlCommand();
                   comando.Connection = _conn;
                   comando.CommandType = System.Data.CommandType.StoredProcedure;
                   comando.CommandText = "SP_insertar_ExperienciaLaboralConId";
                   comando.Parameters.AddWithValue("@id", id);
                   comando.Parameters.AddWithValue("@id_experienciaLaboral", pexpeLaboral.id_experienciaLaboral);
                   comando.Parameters.AddWithValue("@nombreEmpresa", pexpeLaboral.nombreEmpresa);
                   comando.Parameters.AddWithValue("@cargoDesempe", pexpeLaboral.cargoDesp);
                   comando.Parameters.AddWithValue("@descripcionPuesto", pexpeLaboral.descripPuesto);
                   comando.Parameters.AddWithValue("@fechaIncio", pexpeLaboral.fechaInicio);
                   comando.Parameters.AddWithValue("@fechaFin", pexpeLaboral.fechaFin);

                   resultado = (int)comando.ExecuteScalar();

               }

               else
                   resultado = 0;
               oerro = "";
           }
           return resultado;
       }



       public int ActualizarExpLaboral(ExpLaboralE pexpeLaboral, int id, ref string oerro)
       {

           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {
                   SqlCommand comando = new SqlCommand();
                   comando.Connection = _conn;
                   comando.CommandType = System.Data.CommandType.StoredProcedure;
                   comando.CommandText = "SP_update_ExperienciaLaboralConId";
                   comando.Parameters.AddWithValue("@id", id);
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
               oerro = "";
           }
           return resultado;
       }

       public int BorrarExpLab(int p, ref string oerro)
       {
           int resultado = 0;
           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {

                   try
                   {

                       //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                       SqlCommand comm = new SqlCommand("DELETE FROM [ExperienciaLaboral] WHERE [id_experienciaLaboral]=" +
                      p + "", _conn);
                       return comm.ExecuteNonQuery();
                   }
                   catch (Exception ex)
                   {
                       //If Any Exception Will Occur then It Will Display That Message...
                       MessageBox.Show("Ocurrion un error al eliminar la informacion Laboral.");
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

       public DataTable selectExpeLab(int id, ref string oerro)
       {

           using (SqlConnection _conn = CommonDb.ObtenerConnSql())
           {
               if (!(_conn == null))
               {

                   try
                   {
                       SqlCommand comm = new SqlCommand
                           ("SELECT nombreEmpresa,cargoDesempe ,descripcionPuesto,fechaIncio, fechaFin  FROM ExperienciaLaboral where id_candidato=" +
                           +id + " ", _conn);

                       SqlDataAdapter da = new SqlDataAdapter(comm);
                       DataTable dt = new DataTable();
                       da.Fill(dt);
                       return dt;
                   }
                   catch (SqlException ex)
                   {
                       //If Any Exception Will Occur then It Will Display That Message...
                       MessageBox.Show("Ocurrion un error al recuperar los datos de la informacion laboral.");
                       return null;
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
                   return null;
               }
           }

           
       }

    }
}
