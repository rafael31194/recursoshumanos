using HelpDesk.RecursosHumanos.BLL;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication3.Class;
using HelpDesk.RecursosHumanos.DAL;
using HelpDesk.RecursosHumanos.BEL;
using Microsoft.Reporting.WinForms;

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para BusquedaEmpleados.xaml
    /// </summary>
    public partial class BusquedaEmpleados : MetroWindow 
    {

        EmpleadosBLL pEmpleadoBLL = new EmpleadosBLL();
        InfoBasicaBLL infoBl = new InfoBasicaBLL();

        public BusquedaEmpleados()
        {
            
        }

         private void btn_buscarEmpleado_1Click(object sender, RoutedEventArgs e)
        {

            BusuqedaEmpleado();

        }

         public void BusuqedaEmpleado()
         {

             string oError = "";
             DataSet ds = pEmpleadoBLL.SeleccionarInfoBusquedaEmpledosLLenar(txtBusquedaEmpleado.Text, ref oError);
             data_gridBusquedaEmpleado.ItemsSource = ds.Tables[0].DefaultView;

         }

        private void data_gridBusquedaEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void data_gridBusquedaEmpleado_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int dataRow = data_gridBusquedaEmpleado.SelectedIndex;
            string[] nombre = { "0", "No existe ese candidato" };
            foreach (DataRowView dr in data_gridBusquedaEmpleado.Items)
            {
                //entro a la linea que le di doble click
                if (dr == data_gridBusquedaEmpleado.SelectedItem)
                {
                    nombre[0] = dr[0].ToString();
                    nombre[1] = dr[1].ToString();
                    int id = Int32.Parse(nombre[0]);
                    int idEmpleado = Int32.Parse(nombre[1]);
                    String oError = "";
                    DataSet ds = infoBl.SelectInfoBusquedaLLenar(id, ref oError);
                    //DataTables recuperados

                    MantoEmpleados _mt = new MantoEmpleados();

                    _mt.txt_fechaDeContratacion.Text = dr[4].ToString();
                    _mt.txt_EstadoEmpleado.Text = dr[5].ToString();
                    Busqueda bus = new Busqueda();
                    bus.recuperarMostrarDatosCandidato(id.ToString(),idEmpleado, ds, _mt);
                    //recuperarMostrarDatosCandidato(id.ToString(), ds, _mt);


                    this.Close();
                    _mt.ShowDialog();
                }

            }
        
        }

        

        private void Button_ClickVerEmpleado(object sender, RoutedEventArgs e)
        {
            DataRowView dr = (DataRowView)data_gridBusquedaEmpleado.SelectedItem;

            CurriculumEmpleado curri = new CurriculumEmpleado (Int32.Parse(dr[0].ToString()));

            this.Close();
            curri.Show();


        }
        
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void lab_menuEmpleados_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BusquedaEmpleados _busEmple = new BusquedaEmpleados();
            _busEmple.InitializeComponent();
            this.Close();
            _busEmple.Show();

        }

        private void LabelUsuarios_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lab_menuCandidatos_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Busqueda _menusBusqueda = new Busqueda();
            _menusBusqueda.InitializeComponent();
            this.Close();
            _menusBusqueda.Show();
        }

        private void Window_Loaded_empleados(object sender, RoutedEventArgs e)
        {

            string oError = "";
            DataSet ds = pEmpleadoBLL.SeleccionarInfoBusquedaEmpledosLLenar(txtBusquedaEmpleado.Text, ref oError);
            data_gridBusquedaEmpleado.ItemsSource = ds.Tables[0].DefaultView;

            Title = Title + " Usuario: " + UserLogin.Nombre;

            //***IF PARA LOS ROLES DE USUARIO, USUARIOS VISITANTE***//
            if (UserLogin.RolID == 3)
            {


                data_gridBusquedaEmpleado.BringIntoView();
                txt_UsuarioMenus.IsEnabled = false;
                btnConfiguracion.IsEnabled = false;

                data_gridBusquedaEmpleado.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            }
        }

        private void txtBusquedaEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            BusuqedaEmpleado();
        }

        private void UsuariosLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }

        private void paisesLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void menu_MantoEmpresa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MantoEmpresa _menuEmpresa = new MantoEmpresa();
            _menuEmpresa.InitializeComponent();
            this.Close();
            _menuEmpresa.ShowDialog();
        }

        private void labelPaises_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
