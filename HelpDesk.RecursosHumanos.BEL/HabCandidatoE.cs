using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class HabCandidatoE
    {
        public int id_habilidadCandidato { get; set; }
        public int id_candidato { get; set; }
        public int idhabilidadTecnica { get; set; }
        public int id_nivel { get; set; }
        public int id_habilidadAplicacion { get; set; }

        public HabCandidatoE() { }
        public HabCandidatoE(int pId_habilidadCandidato, int pId_candidato, int pIdhabilidadTecnica, int pId_nivel,
                            int pId_habilidadAplicacion)

        {
            id_habilidadCandidato = pId_habilidadCandidato;
            id_candidato = pId_candidato;
            idhabilidadTecnica = pIdhabilidadTecnica;
            id_nivel = pId_nivel;
            id_habilidadAplicacion = pId_habilidadAplicacion;
        
        }

    }
}
