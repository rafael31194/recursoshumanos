using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;

namespace HelpDesk.RecursosHumanos.BEL
{
     public class ExperienciaLaboralBLL
    {
         ExperienciaLaboralDAL _experienciaLabDAL = new ExperienciaLaboralDAL();
         public int GuardarexperienciaLab(ExpLaboralE pexpeLaboral, ref string oerro)
         {
             try
             {
                 return _experienciaLabDAL.GuardarExpLaboral(pexpeLaboral, ref oerro);
             }
             catch (Exception)
             {
                 oerro = "Ocurrio un error al ingresar sus datos";
                 throw;
             }
         }
    }
}
