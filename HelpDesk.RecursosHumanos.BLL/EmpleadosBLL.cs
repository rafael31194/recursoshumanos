using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;
using HelpDesk.RecursosHumanos.DAL;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class EmpleadosBLL
    {
        EmpleadosDAL _empleadosDAL = new EmpleadosDAL();

        //*****MOSTRAR DATOS EN LA GRID DE EMPLEADOS***///
        public DataSet SeleccionarInfoBusquedaEmpledosLLenar(string valorFiltro, ref string oErro)
        {
            return _empleadosDAL.BusquedaInfoEmpleados(valorFiltro, ref oErro);
        }

    }
}
