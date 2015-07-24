using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class RolUsuarioE
    {
        public int id_rol { get; set; }
        public string descripcion { get; set; }

        public RolUsuarioE() { }
        public RolUsuarioE(int pId_rol, string pDescripcion)
        {
            id_rol = pId_rol;
            descripcion = pDescripcion; 
        }
    }
}
