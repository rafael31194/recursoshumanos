﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class TipoContratoE
    {
        public int id_tipoContrato { get; set; }
        public string descripcion_contrato { get; set; }

        public TipoContratoE() { }
        public TipoContratoE(int pId_tipoContrato, string pDescripcion_contrato)
        {
            id_tipoContrato = pId_tipoContrato;
            descripcion_contrato = pDescripcion_contrato;
        }
    }
}
