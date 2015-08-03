using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class usuariosE
    {
        public int id_usuario { get; set; }
        public string userName { get; set; }
        public string contrasena { get; set; }
        public string name { get; set; }
        public RolUsuarioE id_rol { get; set; }

       

        public usuariosE() { }
        public usuariosE(int pId_usuario, string pUserName, string pContrasena, string pName)
        {
            id_usuario = pId_usuario;
            userName = pUserName;
            contrasena = pContrasena;
            name = pName ;
           
 
        }
   }
}
