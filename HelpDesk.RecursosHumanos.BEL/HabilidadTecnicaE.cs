using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class HabilidadTecnicaE
    {
        public int id_habilidadTecnica { get; set; }
        public string descripcion { get; set; }

        public HabilidadTecnicaE() { }
        public HabilidadTecnicaE(int pId_habilidadTecnica, string pDescripcion)
        
        {
            id_habilidadTecnica = pId_habilidadTecnica;
            descripcion = pDescripcion; 
        }
    }
}
