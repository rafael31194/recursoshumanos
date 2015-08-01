using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    class AnioE
    {
        public string Id_anio { get; set; }
        public string Anio { get; set; }
        public AnioE()
        {

        }
        public AnioE(string id_anio, string anio)
        {
            Id_anio = id_anio;
            Anio = anio;

        }
    }
}
