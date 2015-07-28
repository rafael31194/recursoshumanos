using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;
namespace HelpDesk.RecursosHumanos.BEL
{
   public class CertificacionesBLL
    {
       CertificacionesDAL _certificacionesDAL = new CertificacionesDAL();
       public int GuardarCertificacionesLAB(CertificacionesE pCertificaciones, ref string oerro)
       {
           try
           {
               return _certificacionesDAL.GuardarCertificaciones(pCertificaciones, ref oerro);

           }
           catch (Exception)
           {
               oerro = "ocurrio un error al ingresar sus datos";
               throw;
           }
       }
   }
}
