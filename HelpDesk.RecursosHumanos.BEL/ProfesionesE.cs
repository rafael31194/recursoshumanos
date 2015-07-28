using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class ProfesionesE
    {
        public int id_profesiones { get; set; }
        public string descripcion { get; set; }

        public ProfesionesE() { }
        public ProfesionesE(int pId_profesion, string pDescripcion)
        {
            id_profesiones = pId_profesion;
            descripcion = pDescripcion;
        }
    }
}
