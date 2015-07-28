using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
   public class RefecenciasE
    {
       public int id_referencias { get; set; }
       public int id_tipoReferencias { get; set; }
       public int id_candidato { get; set; }
       public string nombre { get; set; }
       public string telefono { get; set; }
       public string descripcion { get; set; }

       public RefecenciasE() { }
       public RefecenciasE(int pId_referencia, int pId_tipoReferencia, int pId_Candidato,
                            string pNombre, string pTelefono, string pDescripcion)
       {
           id_referencias = pId_referencia;
           id_tipoReferencias = pId_tipoReferencia;
           id_candidato = pId_Candidato;
           nombre = pNombre;
           telefono = pTelefono;
           descripcion = pDescripcion;

       }

    }
}
