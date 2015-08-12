using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;


namespace HelpDesk.RecursosHumanos.BEL
{
    public class ReferenciasBLL
    {
        RefereciasDAL _referenciasDAL = new RefereciasDAL();
        public int GuardarReferencias(RefecenciasE preferencias, ref string oerro)
        {
            try
            {
                return _referenciasDAL.GuardarReferencias(preferencias, ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al ingresar  los datos";
                throw;
            }
        }


        public int AgregarReferencias(RefecenciasE refE, int id, ref string oerro)
        {
            try
            {
                return _referenciasDAL.AgregarReferencias(refE, id,ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al ingresar  los datos";
                throw;
            }
        }

        public int ActualizarReferencias(RefecenciasE refE, int id, ref string oerro)
        {
            try
            {
                return _referenciasDAL.ActualizarReferencias(refE, id, ref oerro);
            }
            catch (Exception)
            {
                oerro = "Ocurrio un error al ingresar  los datos";
                throw;
            }
        }

        public void BorrarReferencia(int p, ref string oerro)
        {
            try
            {
                _referenciasDAL.BorrarReferencia(p, ref oerro);

            }
            catch (Exception)
            {
                oerro = "Ocurrio un problema al ingresar los datos";
                throw;
            }
        }
    }
}
