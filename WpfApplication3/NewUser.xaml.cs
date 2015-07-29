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

//Codigo de la pantalla de MainWindow

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para NewUser.xaml
    /// </summary>
    public partial class NewUser : MetroWindow
    {
        public object selectItem { get; set; }

        UsuarioBLL _usuarioBLL = new UsuarioBLL();
        RolUsuarioBLL _RolusuarioBL = new RolUsuarioBLL();
        public NewUser()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {

            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE BUSQUEDA
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();

        }

        private void lab_menuCreacionPerf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE CREACION DE PERFIL
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
            //EVENTO PARA REGISTRAR UN NUEVO USUARIO

            usuariosE _usuarioRegistro = new usuariosE();
            _usuarioRegistro.userName = txt_NombreUsuario.Text;
            _usuarioRegistro.contrasena = txt_constrasenaUsuario.Password.ToString();
            _usuarioRegistro.name = txt_nombreDelUsuario.Text.ToUpper();
            _usuarioRegistro.id_rol = Convert.ToInt32(cb_tipoRol.SelectedValue);

            string oerro = "";

           

            int returusuario = 0;
            returusuario = _usuarioBLL.GuardarUsuarios(_usuarioRegistro, ref oerro);
            if (returusuario > 0)
            {
                

                MessageBox.Show("Registro fue guardado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);

                txt_NombreUsuario.Text = "";
                txt_constrasenaUsuario.Password = "";
                txt_nombreDelUsuario.Text = "";
                cb_tipoRol.Text = "";

            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        { 
            //EVENTO PARA LLENAR EL COMBOBOX
            try
            {
                DataSet ds11 = new DataSet();
                ds11 = _RolusuarioBL.SelectRolUsuarioALL();
                cb_tipoRol.ItemsSource = ds11.Tables[0].DefaultView;
                cb_tipoRol.DisplayMemberPath = ds11.Tables[0].Columns[1].ToString();
                cb_tipoRol.SelectedValuePath = ds11.Tables[0].Columns[0].ToString();
                cb_tipoRol.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void cb_tipoRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
