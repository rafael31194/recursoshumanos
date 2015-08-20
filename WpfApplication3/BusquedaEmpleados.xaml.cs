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

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para BusquedaEmpleados.xaml
    /// </summary>
    public partial class BusquedaEmpleados : MetroWindow 
    {

        InfoBasicaBLL infoBl = new InfoBasicaBLL();
        public BusquedaEmpleados()
        {
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            string oError = "";
            DataSet ds = infoBl.SelectInfoBusqueda("", ref oError);
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


        private void btn_buscarEmpleado_1Click(object sender, RoutedEventArgs e)
        {

        }

        private void data_gridBusquedaEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void data_gridBusquedaEmpleado_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_ClickVerEmpleado(object sender, RoutedEventArgs e)
        {

        }
        
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void lab_menuEmpleados_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LabelUsuarios_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lab_menuCandidatos_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
