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
    public class PaisDAL
    {
        public DataSet SelectPaisALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_pais", oConn);
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet dsPais = new DataSet();
                da.Fill(dsPais);
                return dsPais;
            }
        }
        public List<PaisE> ObtenerPais()
        {
            throw new NotFiniteNumberException();
        }
    }
}
