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
    public class ProyectoDAL
    {
        //para insertar proyecto
        public int AgregarProyecto(ProyectoE pProyecto, int idEmpleado, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_Proyectos";
                    comando.Parameters.AddWithValue("@id_empresa", pProyecto.id_empresa);
                    comando.Parameters.AddWithValue("@nombreProyecto", pProyecto.nombre_proyecto);
                    comando.Parameters.AddWithValue("@fecha", pProyecto.fecha_inicio);
                    comando.Parameters.AddWithValue("@idPais", pProyecto.id_pais);
                    comando.Parameters.AddWithValue("@idEstadoProyecto", pProyecto.id_estadoProyecto);
                    comando.Parameters.AddWithValue("@idTipoContrato", pProyecto.id_tipoContrato);
                    comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    resultado = (int)comando.ExecuteScalar();

                }

                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }
        //para seleccionar proyecto 
        public DataSet SelectProyectoALL(int id_proyecto)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_ProyectosPorEmpleado", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idProyecto = new SqlParameter ("@empleado", id_proyecto);
                oCmd.Parameters.Add(idProyecto);
                SqlDataAdapter da = new SqlDataAdapter (oCmd);
                DataSet dsProyecto = new DataSet();
                da.Fill(dsProyecto);
                return dsProyecto;
            
            }
        }

        public int actualizarProyecto(ProyectoE pProyecto, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_update_proyecto";
                    comando.Parameters.AddWithValue("@idEmpresa", pProyecto.id_empresa);
                    comando.Parameters.AddWithValue("@nombre", pProyecto.nombre_proyecto);
                    comando.Parameters.AddWithValue("@fecha", pProyecto.fecha_inicio);
                    comando.Parameters.AddWithValue("@idPais", pProyecto.id_pais);
                    comando.Parameters.AddWithValue("@idEstadoProyecto", pProyecto.id_estadoProyecto);
                    comando.Parameters.AddWithValue("@idTipoContrato", pProyecto.id_tipoContrato);
                    comando.Parameters.AddWithValue("@idProyecto", pProyecto.id_proyecto);
                    resultado = (int)comando.ExecuteNonQuery();

                }

                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }


        public void eliminarProyecto(int idProyecDelete,int idEmpleado, ref string oerro)
        {
            try
            {
                int resultado = 0;
                using (SqlConnection _conn = CommonDb.ObtenerConnSql())
                {
                    if (!(_conn == null))
                    {
                        SqlCommand comando = new SqlCommand();
                        comando.Connection = _conn;
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.CommandText = "SP_delete_proyecto";
                        comando.Parameters.AddWithValue("@idProyecto", idProyecDelete);
                        comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        resultado = (int)comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al borrar el proyecto de la base de datos.");
                throw (ex);
            }
        }
    }
}
