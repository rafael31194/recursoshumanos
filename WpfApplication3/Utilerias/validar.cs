using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApplication3
{
   public class TypeRexvalidar
    {
        public static readonly string nombre = @"^[A-Za-z]*$";
        public static readonly string correo = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public static readonly string numero = @"^[0-9]*$";
        public bool validar(string valor,string regex) { 
        
        //valor a validadr
        // @"^[A-Za-z]*$"
            return Regex.IsMatch(valor, regex);

        }
   }
     
}
