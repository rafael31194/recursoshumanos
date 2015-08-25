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
   public class PaisBLL
    {
       PaisDAL _paisDAL = new PaisDAL();
       public List<PaisE> obtenerPais()
       {
        return _paisDAL.ObtenerPais();
       }
       public DataSet SelectpaisALL()
       {
       return _paisDAL.SelectPaisALL();
       }
    }
}
