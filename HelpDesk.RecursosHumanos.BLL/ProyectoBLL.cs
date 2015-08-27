using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.DAL;

namespace HelpDesk.RecursosHumanos.BEL
{
    public  class ProyectoBLL
    {

        ProyectoDAL _proyecto = new ProyectoDAL();
        public ProyectoBLL()
        {

        }


        public int agregarProyecto(ProyectoE proyecto, int id,ref string oerro)
        {
            return _proyecto.AgregarProyecto(proyecto, id, ref oerro);
        }

        public int actualizarProyecto(ProyectoE pro, ref string oerro)
        {
            try{
                return _proyecto.actualizarProyecto(pro, ref oerro);

            }
            catch(Exception Exception){
                return 0;
                throw (Exception);
                }
        }


        public void eliminarProyecto(int idProyecDelete, int idEmpleado,ref string oerro)
        {
            _proyecto.eliminarProyecto(idProyecDelete,idEmpleado, ref oerro);
        }
    }
}
