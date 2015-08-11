using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;


namespace HelpDesk.RecursosHumanos.BEL
{
  public class HabilidadCandidatoBLL
    {
      HabilidadCandidatoDAL _habilidadCanidatoDAL = new HabilidadCandidatoDAL();
      public int GuardarHabilidadCandidato(HabCandidatoE pHabilidadCandidato, ref string oerro)
      {
          try
          {
              return _habilidadCanidatoDAL.GuardarHabilidadCandidato(pHabilidadCandidato, ref oerro);

          }
          catch (Exception)
          {
              oerro = "Ocurrio un problema al ingresar los datos";
              throw;
          }
      }

      public int AgregarHabilidadCandidato(HabCandidatoE refHabCandidato, int id, ref string oerro)
      {
          try
          {
              return _habilidadCanidatoDAL.AgregarHabilidadCandidato(refHabCandidato, id,ref oerro);

          }
          catch (Exception)
          {
              oerro = "Ocurrio un problema al ingresar los datos";
              throw;
          }
      }

      public int ActualizarHabilidadCandidato(HabCandidatoE refHabCandidato, int id, ref string oerro)
      {
          try
          {
              return _habilidadCanidatoDAL.ActualizarHabilidadCandidato(refHabCandidato, id, ref oerro);

          }
          catch (Exception)
          {
              oerro = "Ocurrio un problema al ingresar los datos";
              throw;
          }
      }
    }
}
