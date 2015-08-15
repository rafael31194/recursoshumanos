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
    public class InformacionAcademicaDAL
    {
        public int GuardarInformacionAcademica(InformacionAcademicaE pinformacionAcademica, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_InformacionAcademica";
                  //  comando.Parameters.AddWithValue("@id_informacionAcademica", pinformacionAcademica.id_informacionAcademica);
                    comando.Parameters.AddWithValue("@titulo", pinformacionAcademica.titulo);
                    comando.Parameters.AddWithValue("@institucion", pinformacionAcademica.institucion);
                    comando.Parameters.AddWithValue("@anio_de_finalizacion", pinformacionAcademica.anio_de_finalizacion);
                    comando.Parameters.AddWithValue("@id_statusAcademico", pinformacionAcademica.id_statusAcademico);
                    comando.Parameters.AddWithValue("@id_tipoEducacion", pinformacionAcademica.id_tipoEducacion);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }

        public int AgregarInformacionAcademica(InformacionAcademicaE pinformacionAcademica, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_InformacionAcademicaConId";
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@titulo", pinformacionAcademica.titulo);
                    comando.Parameters.AddWithValue("@institucion", pinformacionAcademica.institucion);
                    comando.Parameters.AddWithValue("@anio_de_finalizacion", pinformacionAcademica.anio_de_finalizacion);
                    comando.Parameters.AddWithValue("@id_statusAcademico", pinformacionAcademica.id_statusAcademico);
                    comando.Parameters.AddWithValue("@id_tipoEducacion", pinformacionAcademica.id_tipoEducacion);

                    resultado = (int)comando.ExecuteScalar();

                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }

        public int ActualizarInformacionAcademica(InformacionAcademicaE pinformacionAcademica, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();//debo agregar al objeto que se recibe el id de su informacion
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_update_InformacionAcademicaConId";
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@id_informacionAcademica", pinformacionAcademica.id_informacionAcademica);
                    comando.Parameters.AddWithValue("@titulo", pinformacionAcademica.titulo);
                    comando.Parameters.AddWithValue("@institucion", pinformacionAcademica.institucion);
                    comando.Parameters.AddWithValue("@anio_de_finalizacion", pinformacionAcademica.anio_de_finalizacion);
                    comando.Parameters.AddWithValue("@id_statusAcademico", pinformacionAcademica.id_statusAcademico);
                    comando.Parameters.AddWithValue("@id_tipoEducacion", pinformacionAcademica.id_tipoEducacion);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }

        public int BorrarInfoAcade(int p, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {

                    try
                    {

                        //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                        SqlCommand comm = new SqlCommand("DELETE FROM InformacionAcademica WHERE id_infomacionAcademica=" +
                       p + "", _conn);
                        return comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //If Any Exception Will Occur then It Will Display That Message...
                        MessageBox.Show("Ocurrion un error al eliminar la informacion academica.");
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

        public DataTable SelectInfoAcade(int p, ref string oerro)
        {
            
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    string query=
                        "SELECT        InformacionAcademica.institucion, TipoEducacion.descripcion as tipoEducacion, InformacionAcademica.titulo, InformacionAcademica.anio_de_finalizacion, StatusAcademico.descripcion AS estado"+
                            " FROM            InformacionAcademica INNER JOIN"+
                         " StatusAcademico ON InformacionAcademica.id_statusAcademico = StatusAcademico.id_statusAcademico INNER JOIN"+
                         " TipoEducacion ON InformacionAcademica.id_tipoEducacion = TipoEducacion.id_tipoEducacion where id_candidato =";
                    try
                    {

                        //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                        SqlCommand comm = new SqlCommand(query + p + "", _conn);
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        //If Any Exception Will Occur then It Will Display That Message...
                        MessageBox.Show("Ocurrion un error al recuperar los tados la informacion academica.");
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
