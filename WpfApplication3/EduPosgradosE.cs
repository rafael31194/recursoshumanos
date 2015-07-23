using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
    public class EduPosgradosE
    {
        public int id_posgrados { get; set; }
        public int id_candidato { get; set; }
        public string titulo { get; set; }
        public string institucion { get; set; }
        public int anio_finalizacion { get; set;}
        public int id_statusAcademico { get; set; }


        public EduPosgradosE() {}
        public EduPosgradosE(int pId_posgrados, int pId_Candidato, string pTitulo, string pInstitucion,
                               int pAnio_finalizacion, int pId_statusAcademico)

        {
            id_posgrados = pId_posgrados;
            id_candidato = pId_Candidato;
            titulo = pTitulo;
            institucion = pInstitucion;
            anio_finalizacion = pAnio_finalizacion;
            id_statusAcademico = pId_statusAcademico;
        
        }
    }
}
