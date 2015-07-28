using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
   public class TipoReferenciaE
    {
       public int id_tipoReferncias;
       public string descripcion;

       public TipoReferenciaE() { }
       public TipoReferenciaE(int pId_tipoReferencias, string pDescripcion)
       {
           id_tipoReferncias = pId_tipoReferencias;
           descripcion = pDescripcion;
       }
    }
}
