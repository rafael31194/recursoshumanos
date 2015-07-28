using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class ExpLaboralE
    {
        public int id_experienciaLaboral { get; set;}
        public int id_candidato { get; set; }
        public string nombreEmpresa { get; set; }
        public string cargoDesp { get; set; }
        public string descripPuesto { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }

        public ExpLaboralE() { }
        public ExpLaboralE(int pId_expericiaLaboral, int pId_candidato, string pnombreEmpresa,
                            string pcargoDesp, string pdescripPuesto, string pFechaInicio, string pFechaFin)
        {

            id_experienciaLaboral = pId_expericiaLaboral;
            id_candidato = pId_candidato;
            nombreEmpresa = pnombreEmpresa;
            cargoDesp = pcargoDesp;
            descripPuesto = pdescripPuesto;
            fechaInicio = pFechaInicio;
            fechaFin = pFechaFin;

        
        }

    }
}
