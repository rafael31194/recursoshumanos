using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class GeneroE
    {
       public int id_genero { get; set; }
       public string descripcion { get; set; }

       public GeneroE() { }
       public GeneroE(int pId_genero, string pDescripcion)
       {
           id_genero = pId_genero;
           descripcion = pDescripcion;
       
       }
    }
}
