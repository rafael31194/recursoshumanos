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
        public DataSet Selecusuarios (string valorFiltro, ref string oError)
        {
            return _usuarioDAL.BusquedaUsuarios(valorFiltro, ref oError);


        }
    }

}
