using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;


namespace HelpDesk.RecursosHumanos.BEL
{
    public class InformacionAcademicaBLL
    {
        InformacionAcademicaDAL _informacionAcademicaDALL = new InformacionAcademicaDAL();
        public int GuardarInfomacionAcademica(InformacionAcademicaE pinformacionAcademica, ref string oerro)
        {
            try  
            {
                return _informacionAcademicaDALL.GuardarInformacionAcademica(pinformacionAcademica, ref oerro); 
            }
            catch (Exception)
            {
                oerro = "ocurrio un problema al guardar los datos";
                throw;
            }
        }
    }
}
