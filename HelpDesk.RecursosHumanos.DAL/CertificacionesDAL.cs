using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
namespace HelpDesk.RecursosHumanos.DAL
{
    public class CertificacionesDAL
    {
        public int GuardarCertificaciones(CertificacionesE pCertificaciones, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_Certificaciones";
                    comando.Parameters.AddWithValue("@id_certificaciones", pCertificaciones.id_candidato);
                    comando.Parameters.AddWithValue("@nombre", pCertificaciones.nombre);
                    comando.Parameters.AddWithValue("@insititucion", pCertificaciones.institucion);
                    comando.Parameters.AddWithValue("@anio", pCertificaciones.anio);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }


        public int AgregarCertificaciones(CertificacionesE pCertificaciones, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_CertificacionesConId";
                    comando.Parameters.AddWithValue("@id",id);
                    comando.Parameters.AddWithValue("@id_certificaciones", pCertificaciones.id_candidato);
                    comando.Parameters.AddWithValue("@nombre", pCertificaciones.nombre);
                    comando.Parameters.AddWithValue("@insititucion", pCertificaciones.institucion);
                    comando.Parameters.AddWithValue("@anio", pCertificaciones.anio);

                    resultado = (int)comando.ExecuteScalar();

                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }

        public int ActualizarCertificaciones(CertificacionesE pCertificaciones, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_update_CertificacionesConId";
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@id_certificaciones", pCertificaciones.id_certificaciones);
                    comando.Parameters.AddWithValue("@nombre", pCertificaciones.nombre);
                    comando.Parameters.AddWithValue("@insititucion", pCertificaciones.institucion);
                    comando.Parameters.AddWithValue("@anio", pCertificaciones.anio);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }

        public int BorrarCertificacion(int certiId, string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {

                    try
                    {

                        //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                        SqlCommand comm = new SqlCommand("DELETE FROM Certificacion WHERE id_certificacion=" +
                       certiId + "", _conn);
                        return comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //If Any Exception Will Occur then It Will Display That Message...
                        MessageBox.Show("Ocurrion un error al eliminar la certificacion.");
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
