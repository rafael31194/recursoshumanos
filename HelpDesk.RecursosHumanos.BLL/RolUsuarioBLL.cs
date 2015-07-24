using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class RolUsuarioBLL
    {
       RolUsuarioDAL _rolUsuariosDAL = new RolUsuarioDAL();
       public List<RolUsuarioE> obtenerRolUsuario()
       {
           return _rolUsuariosDAL.obtenerRolUsuario ();
       }
       public DataSet SelectRolUsuarioALL()
       {
           return _rolUsuariosDAL.SelectRolALL();
       }
    }
}
