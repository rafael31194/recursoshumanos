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
    /// Lógica de interacción para ModificarUsuario.xaml
    /// </summary>
    public partial class ModificarUsuario : Window
    {
          RolUsuarioBLL _RolUpdateusuarioBL = new RolUsuarioBLL();
          bool updateUsuario = true;
        UsuarioBLL _usuariosActulaizarBL = new UsuarioBLL();

          //*****************TABLA DE USUARIO***********//
        DataTable tableUsuario = new DataTable();
       
        public List<string> listData { get; set; }   
        public ModificarUsuario()
        {
            InitializeComponent();
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Cargando el combBox 

            try
            {
                DataSet dsUsuario = new DataSet();
                dsUsuario = _RolUpdateusuarioBL.SelectRolUsuarioALL();
                cb_update_tipoRol.ItemsSource = dsUsuario.Tables[0].DefaultView;
                cb_update_tipoRol.DisplayMemberPath = dsUsuario.Tables[0].Columns[1].ToString();
                cb_update_tipoRol.SelectedValuePath = dsUsuario.Tables[0].Columns[0].ToString();
                cb_update_tipoRol.SelectedIndex = 0;
            }
            catch (Exception)
            {
                
                throw;
            }
            
            
            
            //0 - ID, 1 - NombreUsuario, 2-Rol, 3-Password 
            txt_update_constrasenaUsuario.Password = listData[3].ToString();
            txt_update_nombreDelUsuario.Text = listData[1].ToString();
            cb_update_tipoRol.Text = listData[2].ToString();
        }

        private void btn_UPDATE_Usuario_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_update_constrasenaUsuario.Password)| string.IsNullOrEmpty(txt_update_nombreDelUsuario.Text))
            {
                MessageBox.Show("Complete todos los campos", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //PARAMETROS PARA ACUTUALIZAR 


                usuariosE _ActualizarUsuarioE = new usuariosE();
                _ActualizarUsuarioE.id_usuario = Convert.ToInt32(listData[0]);
                _ActualizarUsuarioE.contrasena = txt_update_constrasenaUsuario.Password.ToString();
                _ActualizarUsuarioE.name = txt_update_nombreDelUsuario.Text.ToUpper();
                _ActualizarUsuarioE.id_rol = new RolUsuarioE();
                _ActualizarUsuarioE.id_rol.id_rol = Convert.ToInt32(cb_update_tipoRol.SelectedValue);

                string oerro = "";

                int returiupdateUsuario = 0;
                returiupdateUsuario = _usuariosActulaizarBL.UpdateUsuarios(_ActualizarUsuarioE, ref oerro);
                if (returiupdateUsuario > 0)
                {
                    MessageBox.Show("Registro fue actualizado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);

                    BusquedaEmpleados _bw = new BusquedaEmpleados();
                    _bw.InitializeComponent();
                    this.Close();
                    _bw.ShowDialog();
                }

            }
          

        }

       

        private void MenusCandidato_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Busqueda _menusBusqueda = new Busqueda();
            _menusBusqueda.InitializeComponent();
            this.Close();
            _menusBusqueda.Show();
        }

        private void MenusEmpreado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BusquedaEmpleados _busEmple = new BusquedaEmpleados();
            _busEmple.InitializeComponent();
            this.Close();
            _busEmple.Show();

        }

        private void menusUsuario_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }

        private void MenusEmpresa_MouseDown(object sender, MouseButtonEventArgs e)
        {

            MantoEmpresa _menuEmpresa = new MantoEmpresa();
            _menuEmpresa.InitializeComponent();
            this.Close();
            _menuEmpresa.ShowDialog();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Busqueda _menusBusqueda = new Busqueda();
            _menusBusqueda.InitializeComponent();
            this.Close();
            _menusBusqueda.Show();
        }

        private void btn_regresarUsuario(object sender, RoutedEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }
    }
}
