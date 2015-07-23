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
    public class DepartamentoDAL
    {

        //public stDataatic List<DepartamentoE> ObtenerDeptos()
        //{
        //    List<DepartamentoE> _departamento = new List<DepartamentoE>();
        //    SqlConnection oConn = CommonDb.ObtenerConnSql();
        //    SqlCommand oCmd = new SqlCommand("SP_select_Departamento", oConn);
        //    oCmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(oCmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        DepartamentoE _Departamento = new DepartamentoE();

        //        _Departamento.id_departamento = Convert.ToInt32(row[0]);
        //        _Departamento.descripcion = Convert.ToString(row[1]);

        //        _Departamento.Add(_departamento);
        //    }

        //    return _departamento;
        //}
        public  List<DepartamentoE> ObtenerDeptos()
        {
            List<DepartamentoE> ListaDepto = new List<DepartamentoE>();
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlConnection oConn = CommonDb.ObtenerConnSql();
                    SqlCommand oCmd = new SqlCommand("SP_select_Departamento", oConn);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader _reader = oCmd.ExecuteReader();

                    while (_reader.Read())
                    {
                        DepartamentoE _depto = new DepartamentoE();
                        _depto.id_departamento = _reader.GetInt32(0);
                        _depto.descripcion = _reader.GetString(1);
                        ListaDepto.Add(_depto);
                    }
                }
            }
            return ListaDepto;
          
        }

        public DataSet SelectdepartamentoALL()
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {

                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_Departamento", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }

}
