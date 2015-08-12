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

        public int AgregarInfomacionAcademica(InformacionAcademicaE pinformacionAcademica,int id, ref string oerro)
        {
            try
            {
                return _informacionAcademicaDALL.AgregarInformacionAcademica(pinformacionAcademica, id, ref oerro);
            }
            catch (Exception)
            {
                oerro = "ocurrio un problema al guardar los datos";
                throw;
            }
        }

        public int ActualizarInfomacionAcademica(InformacionAcademicaE pinformacionAcademica, int id, ref string oerro)
        {
            try
            {
                return _informacionAcademicaDALL.ActualizarInformacionAcademica(pinformacionAcademica, id, ref oerro);
            }
            catch (Exception)
            {
                oerro = "ocurrio un problema al guardar los datos";
                throw;
            }
        }

        public int BorrarInfoAcade(int p, ref string oerro)
        {
            try
            {
                return _informacionAcademicaDALL.BorrarInfoAcade(p, ref oerro);
            }
            catch (Exception)
            {
                oerro = "ocurrio un problema al guardar los datos";
                throw;
            }
        }
    }
}
