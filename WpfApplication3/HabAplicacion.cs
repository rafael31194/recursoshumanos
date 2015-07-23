using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Recursos.entities
{
   public class HabAplicacion
    {
       public int id_habilidadAplicacion { get; set; }
       public string descripcion { get; set; }
       public int id_habilidad { get; set; }

       public HabAplicacion() { }
       public HabAplicacion(int pId_habilidadAplicacion, string pDescripcion, int pId_habilidad)
       {
           id_habilidadAplicacion = pId_habilidadAplicacion;
           descripcion = pDescripcion;
           id_habilidad = pId_habilidad;
       }
    }
}
