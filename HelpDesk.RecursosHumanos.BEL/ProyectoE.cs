using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class ProyectoE
    {
        public int id_proyecto { get; set; }
        public DateTime fecha_inicio { get; set; }
        public string nombre_proyecto { get; set; }
        public int id_empresa { get; set; }
        public int id_pais { get; set; }
        public int id_tipoContrato { get; set; }
        public int id_estadoProyecto { get; set; }

        public ProyectoE() { }
        public ProyectoE(int pId_proyecto, DateTime pFecha_inicio, string pNombre_proyecto,
                            int pId_empresa, int pId_pis, int pid_tipoContrato,
                           int pId_estadoProyecto)
        {
            id_proyecto = pId_proyecto;
            fecha_inicio = pFecha_inicio;
            nombre_proyecto = pNombre_proyecto;
            id_empresa = pId_empresa;
            id_pais = pId_pis;
            id_tipoContrato = pid_tipoContrato;
            id_estadoProyecto = pId_estadoProyecto;

        }
       
    }
}
