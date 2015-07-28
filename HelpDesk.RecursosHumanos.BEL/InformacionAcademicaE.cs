using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class InformacionAcademicaE
    {
        public int id_informacionAcademica { get; set; }
        public string titulo { get; set; }
        public string institucion { get; set; }
        public int anio_de_finalizacion { get; set; }
        public int id_statusAcademico { get; set; }
        public int id_tipoEducacion { get; set; }
        public int candidato { get; set; }

        public InformacionAcademicaE() { }
        public InformacionAcademicaE(int pId_informacionAcademica, string pTitulo, string PInstitucion, int pAnio_de_finalizacion,
                                      int pId_statusAcademico, int pId_tipoEducacion, int pCandidato)
        {
            id_informacionAcademica = pId_informacionAcademica;
            titulo = pTitulo;
            institucion = PInstitucion;
            anio_de_finalizacion = pAnio_de_finalizacion;
            id_statusAcademico = pId_statusAcademico;
            id_tipoEducacion = pId_tipoEducacion;
            candidato = pCandidato;
        }
    }
}
