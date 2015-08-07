
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HelpDesk.RecursosHumanos.DAL
{
    class CommonDb
    {
        public const string _stringDeConexion = @"Data Source=EDUARDO_HP\SQLEXPRESS;Initial Catalog=RecursosHumanos;Integrated Security=True";

        public static SqlConnection obtenerConexion()
        {
            SqlConnection _conn = new SqlConnection(_stringDeConexion);
            _conn.Open();
            return _conn;

        }
        public static int obtenerComando(string pComando, IDbConnection pConection)
        {
            return new SqlCommand(pComando, pConection as SqlConnection).ExecuteNonQuery();

        }
        public static SqlConnection ObtenerConnSql()
        {
            SqlConnection oConn = new SqlConnection(_stringDeConexion);
            oConn.Open();
            return oConn;

        }
        public static IDbConnection ObtenerConexion()
        {
            IDbConnection _Conn = new SqlConnection(_stringDeConexion);
            _Conn.Open();
            return _Conn;
        }
    }
}
