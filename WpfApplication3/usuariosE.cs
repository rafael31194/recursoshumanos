using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
   public class usuariosE
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }

        public usuariosE() { }
        public usuariosE(int pId_usuario, string pNombre, string pContrasena)
        {
            id_usuario = pId_usuario;
            nombre = pNombre;
            contrasena = pContrasena; 
        
        }
    }
}
