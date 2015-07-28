using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
    public class ExpLaboralE
    {
        public int id_experienciaLaboral { get; set;}
        public int id_candidato { get; set; }
        public string puesto { get; set; }
        public string descripcion { get; set; }
        public float salario { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFinal { get; set; }

        public ExpLaboralE() { }
        public ExpLaboralE(int pId_expericiaLaboral, int pId_candidato, string pPuesto,
                            string pDescripcion, float pSalario, string pFechaInicio, string pFechaFinal)
        {

            id_experienciaLaboral = pId_expericiaLaboral;
            id_candidato = pId_candidato;
            puesto = pPuesto;
            descripcion = pDescripcion;
            salario = pSalario;
            fechaInicio = pFechaInicio;
            fechaFinal = pFechaFinal;

        
        }

    }
}
