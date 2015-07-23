using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class NivelBLL
    {
       NivelDAL _nivelDAL = new NivelDAL();
       public List<NivelE> ObtenerNivel()
       {
           return _nivelDAL.ObtenerNivel();
       }
       public DataSet SelectnivelALL()
       {
           return _nivelDAL.SelectnivelALL();
       }
    }
}


