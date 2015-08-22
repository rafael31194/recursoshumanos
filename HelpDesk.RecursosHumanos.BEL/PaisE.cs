using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class PaisE
    {
        public int id_pais { get; set; }
        public string nombre_pais { get; set; }
        public int id_moneda { get; set; }

        public PaisE() { }
        public PaisE(int pId_pais, string pNombre_pais, int pId_moneda)
        {
            id_pais = pId_pais;
            nombre_pais = pNombre_pais;
            id_moneda = pId_moneda;

        }
    }
}
