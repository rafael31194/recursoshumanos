﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.BLL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;
using System.Data.SqlClient;
using MahApps.Metro.Controls;
namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para MantoEmpresa.xaml
    /// </summary>
    public partial class MantoEmpresa : Window
    {
        EmpresaBLL empresabl = new EmpresaBLL();
        public int id_empresa;
        public DataSet dsBuscarEmpresa = new DataSet();

        public MantoEmpresa()
        {
            InitializeComponent();
        }

        private void btn_buscarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            string oErro = "";
            DataSet dsBuscarEmpresa = empresabl.BuscarEmpresas(txt_busquedaEmpresa.Text, ref oErro);
            DataGrid_Empresas.ItemsSource = dsBuscarEmpresa.Tables[0].DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string oErro = "";
            DataSet dsBuscarEmpresa = empresabl.BuscarEmpresas("", ref oErro);
            DataGrid_Empresas.ItemsSource = dsBuscarEmpresa.Tables[0].DefaultView;
        }

        private void DataGrid_Empresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DataGrid_Empresas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //se guardan en listas los campos para editar el usuario al dar doble click en la fila 
            int dataRowEmpresa = DataGrid_Empresas.SelectedIndex;

            List<string> listData = new List<string>();
            string[] nombreEmpresa = { "0", "No existe ese candidato" };
            foreach (DataRowView us in DataGrid_Empresas.SelectedItems)
            {
                if (us == DataGrid_Empresas.SelectedItems)
                {
                    nombreEmpresa[0] = us[0].ToString();
                    nombreEmpresa[1] = us[1].ToString();
                    int id = Int32.Parse(nombreEmpresa[0]);
                    string oErro = "";
                }

                listData.Add(us[0].ToString());
                listData.Add(us[1].ToString());
                listData.Add(us[2].ToString());
                listData.Add(us[3].ToString());
                listData.Add(us[4].ToString());
                

                ModificarEmpresa modEmpre = new ModificarEmpresa();

                modEmpre.listaData = listData;
                this.Close();
                modEmpre.Show();
            }
        }
        //**BOTON PARA ELIMINAR EMPRESA EN EL MANTENIMIENTO DE EMPRESA**/

        private void btn_eliminarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            DataRowView currentRow = (DataRowView)DataGrid_Empresas.SelectedItem;

            EmpresaE _deleteEmpresa = new EmpresaE();

            //entro a la linea que le di doble click 

            MessageBoxResult resultMB = MessageBox.Show("Esta seguro de eliminar esta empresa: " + currentRow[1].ToString(), "ELIMINAR USUARIO", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultMB == MessageBoxResult.Yes)
            {
                id_empresa = int.Parse(currentRow.Row.ItemArray[0].ToString());
                string oError = "";

                _deleteEmpresa.id_empresa = id_empresa;
                if (empresabl.DeleteEmpresa(_deleteEmpresa, ref oError) > 0)
                {
                    MessageBox.Show("El usuario fue eliminado con exito");
                }

                //actualizar la grid una vez que la empresa fue eliminada 
                dsBuscarEmpresa = empresabl.BuscarEmpresas("", ref oError);
                DataGrid_Empresas.ItemsSource = dsBuscarEmpresa.Tables[0].DefaultView;

            }
        }

    }
}