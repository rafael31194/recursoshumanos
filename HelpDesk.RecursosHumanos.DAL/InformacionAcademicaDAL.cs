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

        public DataTable SelectInfoAcade(int id, ref string oerro)
        {
            string query = @"
                        declare @psexo int
                        declare @nsexo varchar(max)
                        declare @Id int

                        set @Id=" + id + @"

                        select @psexo=id_genero from InformacionBasica where id_candidato=@Id;

                        select @nsexo=case @psexo 
                        when 1 then 
                        'User_default\Userman.png'
                        else
                        'User_default\userwoman.png' end


                        SELECT SituacionProfesional.descripcion as situacionProfesional, Profesiones.descripcion AS profesion, Municipio.descripcion AS municipio, Genero.descripcion AS sexo, InformacionBasica.nombre, InformacionBasica.nacionalidad,
                                                  InformacionBasica.telefono_celular, InformacionBasica.telefono_fijo, InformacionBasica.correo, InformacionBasica.fecha_nacimiento, InformacionBasica.direccion, InformacionBasica.DUI, InformacionBasica.NIT,
                                                 InformacionBasica.AFP, InformacionBasica.ISSS,
						                         CASE when  (InformacionBasica.Foto is null) or (InformacionBasica.Foto =' ')
						                         then @nsexo else InformacionBasica.Foto end as Foto
                                                     FROM            Genero INNER JOIN 
                                                          InformacionBasica ON Genero.id_genero = InformacionBasica.id_genero INNER JOIN
                                                          Municipio ON InformacionBasica.id_municipio = Municipio.id_municipio INNER JOIN
                                                          Profesiones ON InformacionBasica.id_profesiones = Profesiones.id_profesiones INNER JOIN
                                                          SituacionProfesional ON InformacionBasica.id_situacionProfesional = SituacionProfesional.id_SituacionProfesional where id_candidato=@Id";

            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {

                    try
                    {

                        //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                        SqlCommand comm = new SqlCommand(query, _conn);
                        //comm.Parameters.Add(new SqlParameter("@Id", id));
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        //If Any Exception Will Occur then It Will Display That Message...
                        MessageBox.Show("Ocurrion un error al recuperar los datos de la informacion basica.");
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

