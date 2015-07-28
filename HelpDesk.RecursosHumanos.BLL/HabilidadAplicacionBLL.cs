using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class HabilidadAplicacionBLL
    {
        HabilidadAplicacionDAL _HabilidadApliDAL = new HabilidadAplicacionDAL();

        public DataSet SelecthabilidadApliALL(int id_habilidadTecnica)
        {
            return _HabilidadApliDAL.SelecthabilidadApliALL(id_habilidadTecnica);
        }
    }
}
