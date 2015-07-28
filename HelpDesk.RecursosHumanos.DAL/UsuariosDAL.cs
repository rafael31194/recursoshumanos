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
    public class UsuariosDAL
    {
        public int GuardarUsuarios(usuariosE pusuario, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand Comando = new SqlCommand();
                    Comando.Connection = _conn;
                    Comando.CommandType = System.Data.CommandType.StoredProcedure;
                    Comando.CommandText = "SP_insertar_USUARIOS";
                    Comando.Parameters.AddWithValue("@userName ", pusuario.userName);
                    Comando.Parameters.AddWithValue("@contrasena", pusuario.contrasena);
                    Comando.Parameters.AddWithValue("@name", pusuario.name);
                    Comando.Parameters.AddWithValue("id_rol", pusuario.id_rol); 
                    resultado = Comando.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oError = "";
                
            }
            return resultado;

        }
        public DataSet BusquedaUsuarios(string valorFiltro, ref string oError)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_usuarios", oConn);
                oCmd.Parameters.AddWithValue("@busqueda", valorFiltro);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                return ds;
            }
        }

    }
}
