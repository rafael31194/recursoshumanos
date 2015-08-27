using HelpDesk.RecursosHumanos.BEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk.RecursosHumanos.DAL
{
    public class ProyectoEmpleadoDAL
    {

        public ProyectoEmpleadoDAL()
        {

        }


        public int InsertarProyectoEmpleado(ProyectoEmpleadosE proyecto, ref string oerro)
        {
            try
            {
                using (SqlConnection _conn = CommonDb.ObtenerConnSql())
                {
                    SqlConnection oConn = CommonDb.ObtenerConnSql();
                    SqlCommand oCmd = new SqlCommand("SP_insertar_ProyectoEmpleado", oConn);
                    oCmd.Parameters.AddWithValue("@idEmpleado", proyecto.id_empleado);
                    oCmd.Parameters.AddWithValue("@idProyecto", proyecto.id_proyectos);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    return oCmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al insertar el proyecto del empleado");
                return 0;
                throw (ex);
                

            }

        }
    }
}
