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
    public class InfomacionBasicaDAL
    {
        public int GudarInfBasica(InfoBasicaE pinfobasica, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand Comando = new SqlCommand();
                    Comando.Connection = _conn;
                    Comando.CommandType = System.Data.CommandType.StoredProcedure;
                    Comando.CommandText = "SP_insertar_infobasica";
                    Comando.Parameters.AddWithValue("@nombre", pinfobasica.nombre);
                    Comando.Parameters.AddWithValue("@nacionalidad", pinfobasica.nacionalidad);
                    Comando.Parameters.AddWithValue("@telefono_celular", pinfobasica.telefono_celular);
                    Comando.Parameters.AddWithValue("@telefono_fijo", pinfobasica.telefono_fijo);
                    Comando.Parameters.AddWithValue("@correo", pinfobasica.correo);
                    Comando.Parameters.AddWithValue("@fecha_nacimiento", pinfobasica.fecha_nacimiento);
                    Comando.Parameters.AddWithValue("@direccion", pinfobasica.direccion);
                    Comando.Parameters.AddWithValue("@DUI", pinfobasica.DUI);
                    Comando.Parameters.AddWithValue("@NIT", pinfobasica.NIT);
                    Comando.Parameters.AddWithValue("@AFP", pinfobasica.AFP);
                    Comando.Parameters.AddWithValue("@ISSS", pinfobasica.ISSS);
                    Comando.Parameters.AddWithValue("@idgenero", pinfobasica.id_genero);
                    Comando.Parameters.AddWithValue("@idmunicipio", pinfobasica.id_municipio);
                    Comando.Parameters.AddWithValue("@idsituacionprofesional", pinfobasica.id_situacionProfesional);
                    Comando.Parameters.AddWithValue("@id_profesiones", pinfobasica.id_profesiones);
                    Comando.Parameters.AddWithValue("@foto", pinfobasica.FotoCandidato);

                    resultado = Comando.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }

        public DataSet BusquedaInfoBasica(string valorFiltro, ref string oError)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {

                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_Busqueda", oConn);
                oCmd.Parameters.AddWithValue("@busqueda", valorFiltro);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        public DataSet BusquedaInfoBasicaLLenar(int valorFiltro, ref string oError)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {

                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_masivoperfil", oConn);
                oCmd.Parameters.AddWithValue("@Id", valorFiltro);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        public void borrarCandidato(int id)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    try
                    {     
                        SqlCommand Comando = new SqlCommand();
                        Comando.Connection = _conn;
                        Comando.CommandType = System.Data.CommandType.StoredProcedure;
                        Comando.CommandText = "SP_delete_EliminarCandidato";
                        Comando.Parameters.AddWithValue("@Id", id);
                        Comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al momento de eliminar este candidato");
                        throw ex;
                    }

                }
            }
        }
        public int ActualizarInfBasica(InfoBasicaE pinfobasica, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand Comando = new SqlCommand();
                    Comando.Connection = _conn;
                    Comando.CommandType = System.Data.CommandType.StoredProcedure;
                    Comando.CommandText = "SP_update_infoBasica";
                    Comando.Parameters.AddWithValue("@id_info", id);
                    Comando.Parameters.AddWithValue("@nombre", pinfobasica.nombre);
                    Comando.Parameters.AddWithValue("@nacionalidad", pinfobasica.nacionalidad);
                    Comando.Parameters.AddWithValue("@telefono_celular", pinfobasica.telefono_celular);
                    Comando.Parameters.AddWithValue("@telefono_fijo", pinfobasica.telefono_fijo);
                    Comando.Parameters.AddWithValue("@correo", pinfobasica.correo);
                    Comando.Parameters.AddWithValue("@fecha_nacimiento", pinfobasica.fecha_nacimiento);
                    Comando.Parameters.AddWithValue("@direccion", pinfobasica.direccion);
                    Comando.Parameters.AddWithValue("@DUI", pinfobasica.DUI);
                    Comando.Parameters.AddWithValue("@NIT", pinfobasica.NIT);
                    Comando.Parameters.AddWithValue("@AFP", pinfobasica.AFP);
                    Comando.Parameters.AddWithValue("@ISSS", pinfobasica.ISSS);
                    Comando.Parameters.AddWithValue("@idgenero", pinfobasica.id_genero);
                    Comando.Parameters.AddWithValue("@idmunicipio", pinfobasica.id_municipio);
                    Comando.Parameters.AddWithValue("@idsituacionprofesional", pinfobasica.id_situacionProfesional);
                    Comando.Parameters.AddWithValue("@id_profesiones", pinfobasica.id_profesiones);
                    Comando.Parameters.AddWithValue("@foto", pinfobasica.FotoCandidato);

                    resultado = Comando.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }

        public DataTable selectInfoBasic(int id, ref string oerro)
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
						                         CASE when InformacionBasica.Foto is null
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

