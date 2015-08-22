using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;

namespace HelpDesk.RecursosHumanos.DAL
{
    public class EstadoProyectoDAL
    {
        public DataSet SeleccioneEstadoProyectoALL()
        {
        using (SqlConnection _conn = CommonDb.ObtenerConnSql())
        {
        SqlConnection oConn = CommonDb.ObtenerConnSql();
        SqlCommand oCmd = new SqlCommand("SP_select_EstadoProyecto", oConn);
        oCmd.CommandType =CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter (oCmd);
            DataSet dsEstadoProyecto =  new DataSet ();
            da.Fill(dsEstadoProyecto);
            return dsEstadoProyecto;           
        
        }
        }
        public List<EstadoProyectoE> obtenerEstadoProyecto()
        {
            throw new NotImplementedException();
        }

    }
}
