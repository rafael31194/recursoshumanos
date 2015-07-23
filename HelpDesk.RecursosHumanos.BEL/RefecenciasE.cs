using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class RefecenciasE
    {
       public int id_referencias { get; set; }
       public int id_tipoReferencias { get; set; }
       public string nombre { get; set; }
       public string telefono { get; set; }
       public string descripcion { get; set; }

       public RefecenciasE() { }
       public RefecenciasE(int pId_referencia, int pId_tipoReferencia,
                            string pNombre, string pTelefono, string pDescripcion)
       {
           id_referencias = pId_referencia;
           id_tipoReferencias = pId_tipoReferencia;
           nombre = pNombre;
           telefono = pTelefono;
           descripcion = pDescripcion;

       }

    }
}
