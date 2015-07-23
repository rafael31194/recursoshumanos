﻿using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;
namespace HelpDesk.RecursosHumanos.DAL
{
    public class CertificacionesDAL
    {
        public int GuardarCertificaciones(CertificacionesE pCertificaciones, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_Certificaciones";
                    comando.Parameters.AddWithValue("@id_certificaciones", pCertificaciones.id_candidato);
                    comando.Parameters.AddWithValue("@nombre", pCertificaciones.nombre);
                    comando.Parameters.AddWithValue("@insititucion", pCertificaciones.institucion);
                    comando.Parameters.AddWithValue("@anio", pCertificaciones.anio);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }
             
    }
}