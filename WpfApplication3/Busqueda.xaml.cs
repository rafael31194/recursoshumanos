using System;
using System.Collections.Generic;
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
using HelpDesk.RecursosHumanos.BLL;
using System.Data;
using MahApps.Metro.Controls;



namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para Busqueda.xaml
    /// </summary>
    public partial  class Busqueda : MetroWindow
    {
        InfoBasicaBLL infoBl = new InfoBasicaBLL();

        //public Busqueda()
        //{
        //    string oError = "";
        //    DataSet ds = infoBl.SelectInfoBusqueda(txtBusqueda.Text, ref oError);
        //    data_gridBusqueda.ItemsSource = ds.Tables[0].DefaultView;
        //}


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_buscarInfb_1Click(object sender, RoutedEventArgs e)
        {
            string oError = "";
            DataSet ds =  infoBl.SelectInfoBusqueda(txtBusqueda.Text, ref oError);
            data_gridBusqueda.ItemsSource = ds.Tables[0].DefaultView;
          
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            string oError = "";
            DataSet ds = infoBl.SelectInfoBusqueda("", ref oError);
            data_gridBusqueda.ItemsSource = ds.Tables[0].DefaultView;
            
        }

        private void data_gridBusqueda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.Show();
        }

        
        private void lab_menuCreacionPerf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.ShowDialog();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MantoCandidatos _mt = new MantoCandidatos();
            this.Close();
            _mt.ShowDialog(); 
        }

        private void Image_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
