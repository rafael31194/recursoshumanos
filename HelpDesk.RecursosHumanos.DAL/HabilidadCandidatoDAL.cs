using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;

namespace HelpDesk.RecursosHumanos.DAL
{
    public class HabilidadCandidatoDAL
    {
        public int GuardarHabilidadCandidato(HabCandidatoE pHabilidadCandidato, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comado = new SqlCommand();
                    comado.Connection = _conn;
                    comado.CommandType = System.Data.CommandType.StoredProcedure;
                    comado.CommandText = "SP_insertar_HabilidadCandidato";
                    comado.Parameters.AddWithValue("@id_habilidadCandidato", pHabilidadCandidato.id_habilidadCandidato);
                    comado.Parameters.AddWithValue("@id_habilidadTecnica", pHabilidadCandidato.idhabilidadTecnica);
                    comado.Parameters.AddWithValue("@id_nivel", pHabilidadCandidato.id_nivel);
                    comado.Parameters.AddWithValue("@id_habilidadAplicacion", pHabilidadCandidato.id_habilidadAplicacion);

                    resultado = comado.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }


        public int AgregarHabilidadCandidato(HabCandidatoE pHabilidadCandidato, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comado = new SqlCommand();
                    comado.Connection = _conn;
                    comado.CommandType = System.Data.CommandType.StoredProcedure;
                    comado.CommandText = "SP_insertar_HabilidadCandidatoConId";
                    comado.Parameters.AddWithValue("@id", id);
                    comado.Parameters.AddWithValue("@id_habilidadCandidato", pHabilidadCandidato.id_habilidadCandidato);
                    comado.Parameters.AddWithValue("@id_habilidadTecnica", pHabilidadCandidato.idhabilidadTecnica);
                    comado.Parameters.AddWithValue("@id_nivel", pHabilidadCandidato.id_nivel);
                    comado.Parameters.AddWithValue("@id_habilidadAplicacion", pHabilidadCandidato.id_habilidadAplicacion);

                    resultado = comado.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }
    }
}
