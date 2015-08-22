using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class EstadoProyectoE
    {
        public int id_estadoProyecto { get; set; }
        public string descripcion_estadoProyecto { get; set; }

        public EstadoProyectoE() { }
        public EstadoProyectoE(int pId_estadoProyecto, string pDescripcion_estadoProyecto)
        {
            id_estadoProyecto = pId_estadoProyecto;
            descripcion_estadoProyecto = pDescripcion_estadoProyecto;
        }
    }
}
