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
   public class EmpresaBLL
    {
       EmpresaDAL _empresaDAL = new EmpresaDAL();
       public List<EmpresaE> ObtenerEmpresas()
       {
           return _empresaDAL.ObtenerEmpresa();
       }
       public DataSet SelectEmpresaALL()
       {
           return _empresaDAL.SelectEmpresaALL();
       }
    }
}
