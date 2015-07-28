using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class MunicipoE
    {
        public int id_municipio { get; set; }
        public string descripcion { get; set; }
        public int id_departamento { get; set; }

        public MunicipoE() { }
        public MunicipoE(int pId_municipio, string pDescripcion, int pId_departamento)
        {
            id_municipio = pId_municipio;
            descripcion = pDescripcion;
            id_departamento = pId_departamento; 
        }
    }
}
