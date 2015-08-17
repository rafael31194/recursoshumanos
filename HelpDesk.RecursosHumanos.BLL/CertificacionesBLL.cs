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

       public int AgregarCertificacionesLAB(CertificacionesE certifi, int id, ref string oerro)
       {
           try
           {
               return _certificacionesDAL.AgregarCertificaciones(certifi,id, ref oerro);

           }
           catch (Exception)
           {
               oerro = "ocurrio un error al ingresar sus datos";
               throw;
           }
       }

       public int ActualizarCertificacionesLAB(CertificacionesE certifi, int id, ref string oerro)
       {
           try
           {
               return _certificacionesDAL.ActualizarCertificaciones(certifi, id, ref oerro);

           }
           catch (Exception)
           {
               oerro = "ocurrio un error al ingresar sus datos";
               throw;
           }
       }

       public int BorrarCertificacion(int certiId,ref string oerro){

           return _certificacionesDAL.BorrarCertificacion(certiId, oerro);
       }

       public System.Data.DataTable selectCertifi(int idCandidato, ref string oerro)
       {
           return _certificacionesDAL.selecCertifi(idCandidato, ref  oerro);
       }
    }
}
