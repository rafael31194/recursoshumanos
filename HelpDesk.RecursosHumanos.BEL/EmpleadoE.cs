using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    class EmpleadoE
    {
        public int id_empleado { get; set; }
        public string proyecto_actual { get; set; }
        public DateTime fecha_contratacion { get; set; }
        public int id_candidato { get; set; }
        public bool Disponible { get; set; }

        public EmpleadoE() { }
        public EmpleadoE(int pId_empleado, string pProyecto_actual,
                            DateTime pFecha_contratacion, int pId_candidato,
                            bool pDisponible)
        {
            id_empleado = pId_empleado;
            proyecto_actual = pProyecto_actual;
            fecha_contratacion = pFecha_contratacion;
            id_candidato = pId_candidato;
            Disponible = pDisponible;
        }
    }
}

