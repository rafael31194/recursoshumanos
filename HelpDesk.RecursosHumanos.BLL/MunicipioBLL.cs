using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class MunicipioBLL
    {
       MunicipioDAL _municDAL = new MunicipioDAL();

       public DataSet SelectmunicipioALL(int id_departamento)
       {
           return _municDAL.SelectmunicipioALL(id_departamento);
       }
    }
}
