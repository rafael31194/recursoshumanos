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
    public class EmpresaDAL
    {
        public DataSet SelectEmpresaALL()
        { //SP PARA CARGAR EL COMBOBOX DE EMPRESAS
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {

                SqlConnection _oConn = CommonDb.ObtenerConnSql();
                SqlConnection oConn = CommonDb.ObtenerConnSql();
                SqlCommand oCmd = new SqlCommand("SP_select_empresas", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet dsEmpresa = new DataSet();
                da.Fill(dsEmpresa);
                return dsEmpresa;
            }
        }
        public List<EmpresaE> ObtenerEmpresa()
        {
            throw new NotImplementedException();
        }

        public DataSet BuscarEmpresas (string valorFiltro, ref string oErro)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            { 
            SqlConnection oConn = CommonDb.ObtenerConnSql();
            SqlCommand oCmd = new SqlCommand("sp_buscar_empresas", oConn);
            oCmd.Parameters.AddWithValue("@busquedaEmpresa", valorFiltro);
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(oCmd);
            DataSet dsBusquedaEmpresa = new DataSet();
            da.Fill(dsBusquedaEmpresa);
            return dsBusquedaEmpresa;
            }
        }
        //METODO PARA UPDATE EMPRESAS 
        public int updateEmpresas(EmpresaE pEmpresa, ref string oErro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_UPDATE_EMPRESAS";
                    comando.Parameters.AddWithValue("@ID", pEmpresa.id_empresa);
                    comando.Parameters.AddWithValue("@nombreEmpresa", pEmpresa.nombre);
                    comando.Parameters.AddWithValue("@direccionEmpresa", pEmpresa.direccion);
                    comando.Parameters.AddWithValue("@telefonoEmpresa", pEmpresa.telefono);
                    comando.Parameters.AddWithValue("@idPais", pEmpresa.id_pais.id_pais);

                    //0-@nombreEmpresa

                    resultado = comando.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oErro= "";
            }
            return resultado;
        }
        //METODO PARA ELIMINAR UNA EMPRESA//

        public int DeleteEmpresa(EmpresaE pEmpresa, ref string oErro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_delete_Empresa";
                    comando.Parameters.AddWithValue("@IDEmpresa", pEmpresa.id_empresa);

                    resultado = comando.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oErro = ""; 
            }
            return resultado;
        }

        //METODO PARA GUARDAR EN EMPRESA//
        public int GuardarEmpresa(EmpresaE pempresa, ref string oError)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand Comando = new SqlCommand();
                    Comando.Connection = _conn;
                    Comando.CommandType = System.Data.CommandType.StoredProcedure;
                    Comando.CommandText = "SP_insertar_empresas";
                    Comando.Parameters.AddWithValue("@nombre", pempresa.nombre);
                    Comando.Parameters.AddWithValue("@direccion", pempresa.direccion);
                    Comando.Parameters.AddWithValue("@telefono", pempresa.telefono);
                    Comando.Parameters.AddWithValue("@id_pais", pempresa.id_pais.id_pais);
                    resultado = Comando.ExecuteNonQuery();
                }
                else
                    resultado = 0;
                oError = "";
            }
            return resultado;
        }

    }
} 
