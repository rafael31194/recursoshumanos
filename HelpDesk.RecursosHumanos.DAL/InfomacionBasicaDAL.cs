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
    public class InfomacionBasicaDAL
    {
        public int GudarInfBasica(InfoBasicaE pinfobasica,ref string oError)
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
    }

}

