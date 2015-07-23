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
    public class SituacionProfesionalBLL
      {
       SituacionProfesionalDAL _SituacionpDAL = new SituacionProfesionalDAL();
       public List<SituacionProfesionalE> obtenersituacionp()
       {
           return _SituacionpDAL.obtenersituacionp();
       }
       public DataSet SelectSituacionProfeALL()
       {
           return _SituacionpDAL.SelectSituacionProfeALL();
       }
    }
}
