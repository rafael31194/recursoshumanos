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
   public  class HabilidadTecnicaBLL
    {
       HabilidadTecnicaDAL _habilidadTecDAL = new HabilidadTecnicaDAL();
       public List<HabilidadTecnicaE> ObtenerHablidadTecnicas()
       {
           return _habilidadTecDAL.ObtenerHablidadTecnicas();
       }
       public DataSet SelectHabilidadTecnicaALL()
       {
           return _habilidadTecDAL.SelectHabilidadTecnicaALL();
       }
    }
}
