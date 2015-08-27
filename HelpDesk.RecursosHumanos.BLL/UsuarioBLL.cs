using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
namespace HelpDesk.RecursosHumanos.BLL
{
    public class UsuarioBLL
    {
        //METODO PARA GUARDAR USUARIO
        UsuariosDAL _usuarioDAL = new UsuariosDAL();

        public int GuardarUsuarios(usuariosE pusuario, ref string oerro)
        {
            try
            {
                return _usuarioDAL.GuardarUsuarios(pusuario, ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al ingresar sus datos";
                throw;
            }

        }

        //METODO PARA SELCIONAR USUARIO
        public DataSet Selecusuarios(string valorFiltro, ref string oError)
        {
            return _usuarioDAL.BusquedaUsuarios(valorFiltro, ref oError);
        }

        //METODO PARA AUTENTICAR USUARIO
        public usuariosE AutentificacionUser(usuariosE pUsuario)
        {
            return _usuarioDAL.AutentificarUsuario(pUsuario);
        }

        //METODO PARA MODIFICAR USUARIO
        public int UpdateUsuarios(usuariosE pUsuario, ref string oerro)
        {
            try
            {
                return _usuarioDAL.UpdateUsuarios(pUsuario, ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al actualizar sus datos";
                throw;
            }

        }
        //METODO PARA ELIMINAR USUARIO
        public int DeleteUsuario(usuariosE pUsuario, ref string oerro)
        {
            try
            {
                return _usuarioDAL.DeleteUsuario(pUsuario, ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al elimanar sus datos";
                throw;
            }

        }

    }

}
