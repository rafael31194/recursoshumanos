﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
     public class ExperienciaLaboralBLL
    {
         ExperienciaLaboralDAL _experienciaLabDAL = new ExperienciaLaboralDAL();
         public int GuardarexperienciaLab(ExpLaboralE pexpeLaboral, ref string oerro)
         {
             try
             {
                 return _experienciaLabDAL.GuardarExpLaboral(pexpeLaboral, ref oerro);
             }
             catch (Exception)
             {
                 oerro = "Ocurrio un error al ingresar sus datos";
                 throw;
             }
         }

         public int AgregarexperienciaLab(ExpLaboralE refExpL,int id, ref string oerro)
         {
             try
             {
                 return _experienciaLabDAL.AgregarExpLaboral(refExpL,id, ref oerro);
             }
             catch (Exception)
             {
                 oerro = "Ocurrio un error al ingresar sus datos";
                 throw;
             }
         }

         public int ActualizarExperienciaLab(ExpLaboralE refExpL, int id, ref string oerro)
         {
             try
             {
                 return _experienciaLabDAL.ActualizarExpLaboral(refExpL, id, ref oerro);
             }
             catch (Exception)
             {
                 oerro = "Ocurrio un error al ingresar sus datos";
                 throw;
             }
         }



         public int BorrarExpLab(int p, ref string oerro)
         {
             try
             {
                 return _experienciaLabDAL.BorrarExpLab(p, ref oerro);
             }
             catch (Exception)
             {
                 oerro = "ocurrio un problema al guardar los datos";
                 throw;
             }
         }

         public DataTable selectExpeLab(int id, ref string oerro)
         {
             try
             {
                 return _experienciaLabDAL.selectExpeLab(id, ref oerro);
             }
             catch (Exception)
             {
                 oerro = "ocurrio un problema al recuperar los datos de la Experiencia laboral";
                 throw;
             }
         }
    }
}
