using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class ProyectoEmpleadoBLL
    {

        ProyectoEmpleadoDAL _proEmple = new ProyectoEmpleadoDAL();

        public int insertarProyectoEmpleado(ProyectoEmpleadosE proyecto, ref string oerro)
        {
            return _proEmple.InsertarProyectoEmpleado(proyecto, ref oerro);
        }
        


    }
}
