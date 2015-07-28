using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class TipoEducacionE
    {
        public int id_tipoEducacion { get; set; }
        public string descripcion { get; set; }

        public TipoEducacionE() { }
        public TipoEducacionE(int pId_tipoEducacion, string pDescripcion)
        {
            id_tipoEducacion = pId_tipoEducacion;
            descripcion = pDescripcion;
        
        }
    }
}
