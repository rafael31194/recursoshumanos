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
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_Usuarios";
                    comando.Parameters.AddWithValue("@id_usuario", pusuario.id_usuario);
                    comando.Parameters.AddWithValue("@nombre", pusuario.nombre);
                    comando.Parameters.AddWithValue("@contrasena", pusuario.contrasena);


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
