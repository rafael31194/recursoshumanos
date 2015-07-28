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
    public class tipoReferenciaBELL
    {
        tipoReferenciaDAL _tipoRefDAL = new tipoReferenciaDAL();
        public List<TipoReferenciaE> ObtenerTipoReferencia()
        {
            return _tipoRefDAL.ObtenerTipoReferencia();
        }
        public DataSet SelecttipoReferenciaALL()
        {
            return _tipoRefDAL.SelecttipoReferenciaALL();
        }
    }
}
