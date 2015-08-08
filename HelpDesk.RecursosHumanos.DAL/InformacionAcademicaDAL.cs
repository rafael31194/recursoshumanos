using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;


namespace HelpDesk.RecursosHumanos.DAL
{
    public class InformacionAcademicaDAL
    {
        public int GuardarInformacionAcademica(InformacionAcademicaE pinformacionAcademica, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_InformacionAcademica";
                  //  comando.Parameters.AddWithValue("@id_informacionAcademica", pinformacionAcademica.id_informacionAcademica);
                    comando.Parameters.AddWithValue("@titulo", pinformacionAcademica.titulo);
                    comando.Parameters.AddWithValue("@institucion", pinformacionAcademica.institucion);
                    comando.Parameters.AddWithValue("@anio_de_finalizacion", pinformacionAcademica.anio_de_finalizacion);
                    comando.Parameters.AddWithValue("@id_statusAcademico", pinformacionAcademica.id_statusAcademico);
                    comando.Parameters.AddWithValue("@id_tipoEducacion", pinformacionAcademica.id_tipoEducacion);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }

        public int AgregarInformacionAcademica(InformacionAcademicaE pinformacionAcademica, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_InformacionAcademicaConId";
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@titulo", pinformacionAcademica.titulo);
                    comando.Parameters.AddWithValue("@institucion", pinformacionAcademica.institucion);
                    comando.Parameters.AddWithValue("@anio_de_finalizacion", pinformacionAcademica.anio_de_finalizacion);
                    comando.Parameters.AddWithValue("@id_statusAcademico", pinformacionAcademica.id_statusAcademico);
                    comando.Parameters.AddWithValue("@id_tipoEducacion", pinformacionAcademica.id_tipoEducacion);

                    resultado = comando.ExecuteNonQuery();

                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }
    }
}
