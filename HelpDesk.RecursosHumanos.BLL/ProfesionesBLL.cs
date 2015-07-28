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
    public class ProfesionesBLL
    {
        ProfesionesDAL _profesionesDAL = new ProfesionesDAL();
        public List<ProfesionesE> ObtenerProfesiones()
        {
            return _profesionesDAL.ObtenerProfesiones();
        }
        public DataSet SelectdepartamentoALL()
        {
            return _profesionesDAL.SelectdepartamentoALL();
        }
     
    }
}
