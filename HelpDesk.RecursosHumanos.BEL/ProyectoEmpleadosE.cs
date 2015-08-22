using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.RecursosHumanos.BEL
{
    public class ProyectoEmpleadosE
    {
        public int id_proyectoEmpleados  { get; set; }
        public int id_proyectos          { get; set; }
        public int id_empleado           { get; set; }
        public ProyectoEmpleadosE () {}
        public ProyectoEmpleadosE(int Pid_proyectoEmpleados,
                                  int pId_proyectos, int pId_empleado)
        { 
        id_proyectoEmpleados = Pid_proyectoEmpleados;
        id_proyectos = pId_proyectos;
        id_empleado = pId_empleado;
        }
        }                             
}
