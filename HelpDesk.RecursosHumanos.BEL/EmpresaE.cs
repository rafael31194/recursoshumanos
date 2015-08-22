using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class EmpresaE
    {
        public int    id_empresa { get; set; }
        public string nombre    { get; set; }
        public string direccion { get; set; }
        public string telefono  { get; set; }
        public int    id_pais   { get; set; }

         public  EmpresaE() { }
         public EmpresaE(int pId_empresa, string pNombre, string pDireccion,
                           string pTelefono, int pId_pais)
         { 
          id_empresa = pId_empresa;
          nombre    = pNombre;
          direccion = pDireccion;
          telefono  = pTelefono;
          id_pais = pId_pais;
         }             
    }
}
