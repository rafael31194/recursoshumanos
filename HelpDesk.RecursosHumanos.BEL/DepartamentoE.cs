using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class DepartamentoE
    {
        public int id_departamento { get; set; }
        public string descripcion { get; set; }

        public DepartamentoE() { }
        public DepartamentoE(int pId_departamento, string pDescripcion)
        {
            id_departamento = pId_departamento;
            descripcion = pDescripcion;
        }

    }
}
