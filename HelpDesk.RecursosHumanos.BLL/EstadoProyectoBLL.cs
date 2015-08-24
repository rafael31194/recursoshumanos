using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;
namespace HelpDesk.RecursosHumanos.BEL
{
    public class EstadoProyectoBLL
    {
        EstadoProyectoDAL _estadoProyectoDAL = new EstadoProyectoDAL();
        public List<EstadoProyectoE> ObtenerEstadoProyecto()
        {
            return _estadoProyectoDAL.obtenerEstadoProyecto();
        }
        public DataSet SelectEstadoProyectoALL()
        {
            return _estadoProyectoDAL.SeleccioneEstadoProyectoALL();
        }
    }
}
