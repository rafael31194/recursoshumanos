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
using WpfApplication3.Utilerias;

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para LoginInicio.xaml
    /// </summary>
    public partial class LoginInicio : MetroWindow
    {
        public LoginInicio()
        {

            InitializeComponent();
        }

        private void txt_usuarioInicio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txt_usuarioInicio_GotFocus(object sender, RoutedEventArgs e)
        {



        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txt_usuarioInicio.Focus();
        }

        private void btn_EntrarLogin_Click(object sender, RoutedEventArgs e)
        {
            /*iniciar sesion*/ //**************BOTON DE INGRESAR****//
            try
            {
                usuariosE _administrador = new usuariosE();
                _administrador.userName = txt_usuarioInicio.Text;
                _administrador.contrasena = txt_contraña.Password.ToString();

                UsuarioBLL _administradorBL = new UsuarioBLL();

                usuariosE _administradorL = new usuariosE();
                System.Windows.SplashScreen hola = new System.Windows.SplashScreen("Cargando.jpg");
                hola.Show(true);
                _administradorL = _administradorBL.AutentificacionUser(_administrador);
                hola.Close(new TimeSpan(0, 0, 1));


                if (_administradorL.userName == "")
                {

                }
                else if (_administradorL.userName == _administrador.userName)
                {
                    UserLogin.Id = _administradorL.id_usuario;
                    UserLogin.Nombre = _administradorL.name;
                    UserLogin.RolID = _administradorL.id_rol.id_rol;
                    UserLogin.NRol = _administradorL.id_rol.descripcion;
                    Busqueda ver = new Busqueda();
                    ver.InitializeComponent();
                    this.Close();
                    ver.Show();
                }
                else
                {
                    MessageBox.Show("Sus Credenciales son Incorrectas", "Credenciales Incorrectas", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    txt_usuarioInicio.Text = string.Empty;
                    txt_contraña.Password = string.Empty;
                    txt_usuarioInicio.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha generado un error" + ex, "Ocurrio un Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txt_contraña_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
