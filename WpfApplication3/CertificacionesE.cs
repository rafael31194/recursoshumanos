using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
    public class CertificacionesE
    {
        public int id_certificaciones { get; set; }
        public int id_candidato { get; set; }
        public string nombre { get; set; }
        public string institucion { get; set; }
        public int anio { get; set; }

        public CertificacionesE() { }
        public CertificacionesE(int pId_certificaciones, int Pid_candidato, string pNombre, string pInstitucion,
                                  int pAnio)
    {

        id_certificaciones = pId_certificaciones;
        id_candidato = Pid_candidato;
        nombre = pNombre;
        institucion = pInstitucion;
        anio = pAnio;

    }
    }

}
