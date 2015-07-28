using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BLL
{

    public class InfoBasicaBLL
    {

        InfomacionBasicaDAL _infBasDal = new InfomacionBasicaDAL();


        public int GudarInfBasica(InfoBasicaE pinfobasica, ref string oerro)
        {

            try
            {

                return _infBasDal.GudarInfBasica(pinfobasica, ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al ingresar sus los datos. ";
                throw;


            }
        }

        public DataSet SelectInfoBusqueda(  string valorFiltro, ref string oError)
        {
            return _infBasDal.BusquedaInfoBasica(valorFiltro, ref oError);

           
        }
    }
}
