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
   public  class TipoEducacionBLL
    {
       TipoEducacionDAL _tipoEduDAL = new TipoEducacionDAL();
       public List<TipoEducacionE> ObtenerTipoeducacion()
       {
           return _tipoEduDAL.ObtenerTipoeducacion();
       }
       public DataSet SelectTipoEducacionALL()
       {
           return _tipoEduDAL.SelectTipoEducacionALL();  
       }
    }
}



