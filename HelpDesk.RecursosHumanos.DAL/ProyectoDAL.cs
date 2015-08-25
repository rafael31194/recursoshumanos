﻿using System;
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
    public class ProyectoDAL
    {
        //para insertar proyecto
        public int AgregarProyecto(ProyectoE pProyecto, int idEmpleado, string oerro)
        {
            int resultado = 0;
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                if (!(_conn == null))
                {
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = _conn;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.CommandText = "SP_insertar_ExperienciaLaboral";
                    comando.Parameters.AddWithValue("@id_empresa", pProyecto.id_empresa);
                    comando.Parameters.AddWithValue("@nombreProyecto", pProyecto.nombre_proyecto);
                    comando.Parameters.AddWithValue("@fecha Date", pProyecto.fecha_inicio);
                    comando.Parameters.AddWithValue("@idPais int", pProyecto.id_pais);
                    comando.Parameters.AddWithValue("@idEstadoProyecto", pProyecto.id_estadoProyecto);
                    comando.Parameters.AddWithValue("@idTipoContrato", pProyecto.id_tipoContrato);
                    comando.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    resultado = comando.ExecuteNonQuery();

                }

                else
                    resultado = 0;
                oerro = "";
            }
            return resultado;
        }
        //para seleccionar proyecto 
        public DataSet SelectProyectoALL(int idEmpleado)
        {
            using (SqlConnection _conn = CommonDb.ObtenerConnSql())
            {
                SqlConnection oConn = CommonDb.ObtenerConnSql();

                SqlCommand oCmd = new SqlCommand("SP_select_ProyectosPorEmpleado", oConn);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@empleado", idEmpleado);
                SqlDataAdapter da = new SqlDataAdapter(oCmd);
                DataSet dsProyecto = new DataSet();
                da.Fill(dsProyecto);
                return dsProyecto;

            }
        }
        public List<ProyectoE> obtenerProyecto()
        {
            throw new NotImplementedException();
        }
    }
}
