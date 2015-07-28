using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
    public class EduSuperiorE
    {
        public int id_edusuperior { get; set; }
        public int id_candidato { get; set; }
        public string titulo { get; set; }
        public string institucion { get; set; }
        public int anio_finalizacion { get; set; }
        public int id_statusAcademico { get; set; }

        public EduSuperiorE() { }
        public EduSuperiorE(int pId_edusuperior, int pId_candidato, string pTitulo,
               string pInstitucion, int pAnio_finalizacion, int pId_statusAcademico)
        {
            id_edusuperior = pId_edusuperior;
            id_candidato = pId_candidato;
            titulo = pTitulo;
            institucion = pInstitucion;
            anio_finalizacion = pAnio_finalizacion;
            id_statusAcademico = pId_statusAcademico;


        }
    }

}
