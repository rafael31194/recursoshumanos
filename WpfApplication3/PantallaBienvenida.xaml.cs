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

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para PantallaBienvenida.xaml
    /// </summary>
    public partial class PantallaBienvenida : Window
    {
        public PantallaBienvenida()
        {
            InitializeComponent();
        }


        private void MenuPerfilesCandidato_Click(object sender, RoutedEventArgs e)
        {
            Busqueda _menusBusqueda = new Busqueda();
            _menusBusqueda.InitializeComponent();
            this.Close();
            _menusBusqueda.Show();
        }

        private void MenuPerfilesEmpleados_Click(object sender, RoutedEventArgs e)
        {

            BusquedaEmpleados _busEmple = new BusquedaEmpleados();
            _busEmple.InitializeComponent();
            this.Close();
            _busEmple.Show();
        }

        private void MenuBuscarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            MantoEmpresa _menuEmpresa = new MantoEmpresa();
            _menuEmpresa.InitializeComponent();
            this.Close();
            _menuEmpresa.ShowDialog();
        }

        private void MenuBuscarEmpresa_Click_1(object sender, RoutedEventArgs e)
        {
            MantoEmpresa _menuEmpresa = new MantoEmpresa();
            _menuEmpresa.InitializeComponent();
            this.Close();
            _menuEmpresa.ShowDialog();
        }

        private void menuNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.Show();
        }


        private void MenuCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Login Mcerrar = new Login();
            Mcerrar.InitializeComponent();
            this.Close();
            Mcerrar.ShowDialog();
        }
    }
}
