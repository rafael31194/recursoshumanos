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
                SqlCommand oCmd = new SqlCommand("SP_select_BusquedaUsuario", oConn);
                oCmd.Parameters.AddWithValue("@busquedaUsuario", valorFiltro);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        //METODO PARA AUTENTIFICAR USUARIO//////////////////////////////////////////////
        public usuariosE AutentificarUsuario(usuariosE pUsuario)
        {
            //Creo dos instancias
            usuariosE _Usuario = new usuariosE();
            //para retornar
            usuariosE _UsuarioRetorna = new usuariosE();

            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlConnection oConn = CommonDb.ObtenerConnSql();
                    SqlCommand oCmd = new SqlCommand("SP_select_UserLoginn", oConn); //SP para autenticacion en LOGIN
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.Add(new SqlParameter("@username", pUsuario.userName));
                    oCmd.Parameters.Add(new SqlParameter("@password", pUsuario.contrasena));
                    SqlDataReader _Reader = oCmd.ExecuteReader();
                    while (_Reader.Read())
                    {
                        _Usuario.id_usuario = _Reader.GetInt32(0);
                        _Usuario.userName = _Reader.GetString(1);
                        _Usuario.contrasena = _Reader.GetString(2);
                        _Usuario.name = _Reader.GetString(3);
                        _Usuario.id_rol = new RolUsuarioE();
                        _Usuario.id_rol.id_rol = _Reader.GetInt32(4);
                        _Usuario.id_rol.descripcion = _Reader.GetString(5);
                    }
                    _conn.Close();
                }
                else
                {
                    _Usuario = new usuariosE();
                }
            }
            //para comparar lo que venga en el parametro a lo que venga en la base de datos
            if (_Usuario.id_usuario < 1)
            {
                _Usuario = new usuariosE();
            }
            if (pUsuario.userName == _Usuario.userName && pUsuario.contrasena == _Usuario.contrasena)
            {
                _UsuarioRetorna.id_usuario = _Usuario.id_usuario;
                _UsuarioRetorna.name = _Usuario.name;
                _UsuarioRetorna.id_rol = new RolUsuarioE();
                _UsuarioRetorna.id_rol.id_rol = _Usuario.id_rol.id_rol;
                _UsuarioRetorna.id_rol.descripcion = _Usuario.id_rol.descripcion;
                _UsuarioRetorna.userName = _Usuario.userName;
            }
            else
            {
                _UsuarioRetorna.name = "";
                _UsuarioRetorna.id_rol = new RolUsuarioE();
                _UsuarioRetorna.id_rol.id_rol = 0;
                _UsuarioRetorna.id_rol.descripcion = "";
            }
            return _UsuarioRetorna;
        }
    }
}
