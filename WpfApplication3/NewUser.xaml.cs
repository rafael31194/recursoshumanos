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
using MahApps.Metro.Controls;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.BLL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;
using System.Data.SqlClient;

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para NewUser.xaml
    /// </summary>
    public partial class NewUser : MetroWindow
    {
        usuariosE _usuarioRegistro = new usuariosE();
        public NewUser()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();

        }

        private void lab_menuCreacionPerf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.ShowDialog();
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }

        private void btn_guardarNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            usuariosE _usuarioRegistro = new usuariosE();
           _usuarioRegistro.nombre = txt_NombreUsuario.Text;
            _usuarioRegistro.contrasena = txt_ConstrasenaUsuario.Text;

            string oerro = "";

            int returusuario = 0;
            returusuario = _usuarioRegistro.GuardarUsuarios(_usuarioRegistro, ref oerro);
            if (returusuario > 0)
            {
                MessageBox.Show("Registro fue guardado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }
    }
}
