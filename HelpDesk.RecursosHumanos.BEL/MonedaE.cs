using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class MonedaE
    {
        public int id_moneda { get; set; }
        public string descripcion_moneda { get; set; }
        public string iso { get; set; }

        public MonedaE() { }

        public MonedaE(int pId_moneda, string pDescripcion_moneda, string pIso)
        {
            id_moneda = pId_moneda;
            descripcion_moneda = pDescripcion_moneda;
            iso = pIso;
        }

    }
}
