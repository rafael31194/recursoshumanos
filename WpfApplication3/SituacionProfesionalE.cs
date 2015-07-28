using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
    public class SituacionProfesionalE
    {
        public int id_SituacionProfesional { get; set; }
        public string descripcion { get; set; }

        public SituacionProfesionalE() { }
        public SituacionProfesionalE(int pId_situacionProfesional, string Pdescripcion)
        {
            id_SituacionProfesional = pId_situacionProfesional;
            descripcion = Pdescripcion;
               
        }
    }
}
