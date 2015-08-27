using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;

namespace HelpDesk.RecursosHumanos.BEL
{
   public class EmpresaBLL
       //METODO PARA SELECIONAR EMPRESA Y CARGAR COMBOBOX 
    {
       EmpresaDAL _empresaDAL = new EmpresaDAL();
       public List<EmpresaE> ObtenerEmpresas()
       {
           return _empresaDAL.ObtenerEmpresa();
       }
       public DataSet SelectEmpresaALL()
       {
           return _empresaDAL.SelectEmpresaALL();
       }
       //METODO PARA GUARDAR CAMPOS DE  EMPRESA
    
       public int Guardarempresa(EmpresaE pempresa, ref string oerro)
       {
           try
           {
               return _empresaDAL.GuardarEmpresa(pempresa, ref oerro);
           }
           catch (Exception)
           {
               oerro = "Problemas al ingresar sus datos";
               throw;
           }
       }
       //METODO PARA SELECCIONAR EMPRESA 
       public DataSet BuscarEmpresas(string valorFiltro, ref string oErro)
       {
           return _empresaDAL.BuscarEmpresas(valorFiltro, ref oErro);
       }

       //METODO PARA ELIMINAR EMPRESA 

       public int DeleteEmpresa(EmpresaE pEmpresa, ref string oerro)
       {
           try
           {
               return _empresaDAL.DeleteEmpresa(pEmpresa, ref oerro);
           }
           catch (Exception)
           {
               oerro = "Ocurrio un error al eliminar sus datos";
               throw;
           }
       }

       //METODO PARA MODIFICAR EMPRESA 
       public int updateEmpresas(EmpresaE pEmpresa, ref string oerro)
       {
           try
           {
               return _empresaDAL.updateEmpresas(pEmpresa, ref oerro);
           }
           catch (Exception)
           {
               oerro = "Ocurrio un error al actualizar sus datos";
               throw;
           }
       }

    }
}
