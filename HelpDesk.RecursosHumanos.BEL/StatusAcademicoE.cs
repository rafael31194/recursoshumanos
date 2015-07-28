using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class StatusAcademicoE
    {
        public int id_statusAcademico { get; set; }
        public string descripcion { get; set; }

        public StatusAcademicoE() { }
        public StatusAcademicoE(int pId_statusAcademico, string pDescripcion)
        {
            id_statusAcademico = pId_statusAcademico;
            descripcion = pDescripcion;

        }
    }
}
