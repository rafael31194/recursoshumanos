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
   public class DepartamentosBL
    {
       DepartamentoDAL _deptoDAL = new DepartamentoDAL();
       public List<DepartamentoE> ObtenerDeptos()
       {
           return _deptoDAL.ObtenerDeptos();
       }
       public DataSet SelectdepSelectAll()
       {
           return _deptoDAL.SelectdepartamentoALL();
       }
    }
}
