﻿using System;
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

    }
}