using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class AnioBLL
    {
        AnioDAL anios = new AnioDAL();
        public DataSet getAnios()
        {
            
            return anios.getAnios();
        }
    }
}
