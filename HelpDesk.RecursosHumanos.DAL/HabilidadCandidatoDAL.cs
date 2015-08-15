using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

                    resultado =(int) comado.ExecuteScalar();
                }
                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }

        public int ActualizarHabilidadCandidato(HabCandidatoE pHabilidadCandidato, int id, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comado = new SqlCommand();
                    comado.Connection = _conn;
                    comado.CommandType = System.Data.CommandType.StoredProcedure;
                    comado.CommandText = "SP_update_HabilidadCandidatoConId";
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

        public int BorrarHabilidad(int p, ref string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {

                    try
                    {

                        //Write Query For Delete Data From the Table using Creating Object Of SqlCommand...
                        SqlCommand comm = new SqlCommand("DELETE FROM [HabilidadCandidato] WHERE [id_habilidadCandidato]=" +
                       p + "", _conn);
                        return comm.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        //If Any Exception Will Occur then It Will Display That Message...
                        MessageBox.Show("Ocurrion un error al eliminar la habilidad del candidato.");
                        return resultado;
                        throw ex;
                    }
                    finally
                    {
                        //Finally Close the Connection...
                        _conn.Close();


                    }
                }
                else
                {
                    return resultado;
                }
            }
        }

        public DataTable selectHabili(int idCandidato, ref string oerro)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    string query = "SELECT        HabilidadTecnica.descripcion as habilidadTecnica, Nivel.descripcion AS nivel, HabilidadAplicacion.descripcion AS habilidadAplicacion"+
                                    " FROM            HabilidadAplicacion INNER JOIN "+
                         "HabilidadCandidato ON HabilidadAplicacion.id_habilidadAplicacion = HabilidadCandidato.id_habilidadAplicacion INNER JOIN "+
                         "HabilidadTecnica ON HabilidadAplicacion.id_habilidadTecnica = HabilidadTecnica.id_habilidadTecnica AND HabilidadCandidato.id_habilidadTecnica = HabilidadTecnica.id_habilidadTecnica INNER JOIN"+
                         " Nivel ON HabilidadCandidato.id_nivel = Nivel.id_nivel where id_candidato="+idCandidato;
                    try
                    {
                        SqlCommand comm = new SqlCommand(query, _conn);

                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                    catch (SqlException ex)
                    {
                        //If Any Exception Will Occur then It Will Display That Message...
                        MessageBox.Show("Ocurrion un error al recuperar los datos de las habilidades.");
                        return null;
                        throw ex;
                    }
                    finally
                    {
                        //Finally Close the Connection...
                        _conn.Close();


                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
