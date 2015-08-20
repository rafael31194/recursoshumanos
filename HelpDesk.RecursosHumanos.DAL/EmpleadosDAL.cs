using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HelpDesk.RecursosHumanos.DAL
{
   public class EmpleadosDAL
    {
        //***Dataset para mostrar info del empleado en la grid del empleado****//
        public DataSet BusquedaInfoEmpleados(string valorFiltro, ref string oError)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_SelectBusqueEmpleado", oConn);
                oCmd.Parameters.AddWithValue("@IDempBusqueda", valorFiltro);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}
