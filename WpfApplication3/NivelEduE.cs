using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
   public class NivelEduE
    {
       public int id_nivel { get; set; }
       public string descripcion { get; set; }

       public NivelEduE() { }
       public NivelEduE(int pId_nivel, string pDescripcion)
       {
           id_nivel = pId_nivel;
           descripcion = pDescripcion;
       }
    }
}
