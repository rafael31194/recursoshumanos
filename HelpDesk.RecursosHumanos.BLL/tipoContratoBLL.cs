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
   public class tipoContratoBEL
    {
       TipoContratoDAL _tipoContratoDAL = new TipoContratoDAL();
       public List<TipoContratoE> ObtenerTipoContrato()
       {
           return _tipoContratoDAL.ObtenerTipoContrato();
       }
       public DataSet selectTipoContratoALL()
       {
           return _tipoContratoDAL.selectTipoContratoALL();
       }
    }
}
