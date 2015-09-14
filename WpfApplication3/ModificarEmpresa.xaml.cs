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
    /// Lógica de interacción para ModificarEmpresa.xaml
    /// </summary>
    public partial class ModificarEmpresa : Window
    {
        PaisBLL _paisBL = new PaisBLL();
        EmpresaBLL _CorreoEmpresa = new EmpresaBLL();
        
        bool updateEmpresa = true;
        EmpresaBLL _empresaActualizarBL = new EmpresaBLL();

        //***TABLA DE EMPRESA***//
        DataTable tableUsuario = new DataTable();

        public List<string> listaData  { get; set; }
        public ModificarEmpresa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar el comboBox de pais 
            try
            {
                DataSet dsPaisUpdate = new DataSet();
                dsPaisUpdate = _paisBL.SelectpaisALL();
                cb_UPDATEpais.ItemsSource = dsPaisUpdate.Tables[0].DefaultView;
                cb_UPDATEpais.DisplayMemberPath = dsPaisUpdate.Tables[0].Columns[1].ToString();
                cb_UPDATEpais.SelectedValuePath = dsPaisUpdate.Tables[0].Columns[0].ToString();
                cb_UPDATEpais.SelectedIndex = 0;


            }
            catch (Exception)
            {
                
                throw;
            }


            // 0 - ID, 1 - NOMBRE EMPRESA, 2 - DIRECION, 3 - TELEFONO , 4 - PAIS 
            txt_UPDATEnombreEmpresa.Text = listaData[1].ToString(); 
            txt_UPDATEdireccion.Text = listaData[2].ToString();          
            txt_UPDATEtelefono.Text = listaData[3].ToString();
            cb_UPDATEpais.Text = listaData[4].ToString();
            txt_UPDATEcorreo.Text = listaData[5].ToString();
        }

        private void btn_UPDATE_Empresa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_UPDATEnombreEmpresa.Text)| string.IsNullOrEmpty(txt_UPDATEdireccion.Text))
            {
                MessageBox.Show("Complete Todos los campos", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //PARAMETROS PARA ACTUALIZAR 

                EmpresaE _ActualizarEmpresaE = new EmpresaE();
                _ActualizarEmpresaE.id_empresa = Convert.ToInt32(listaData[0]);
                _ActualizarEmpresaE.nombre = txt_UPDATEnombreEmpresa.Text.ToUpper();
                _ActualizarEmpresaE.direccion = txt_UPDATEdireccion.Text.ToUpper();
                _ActualizarEmpresaE.correoEmpresa = txt_UPDATEcorreo.Text;
                _ActualizarEmpresaE.telefono = txt_UPDATEtelefono.Text.ToUpper();
                _ActualizarEmpresaE.id_pais = new PaisE();
                _ActualizarEmpresaE.id_pais.id_pais = Convert.ToInt32(cb_UPDATEpais.SelectedValue);

                string oerro = "";

                int returupdateEmpresa = 0;
                returupdateEmpresa = _empresaActualizarBL.updateEmpresas(_ActualizarEmpresaE, ref oerro);
                if (returupdateEmpresa > 0)
                {
                    MessageBox.Show("Registro fue actualziado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                
                    
                    BusquedaEmpleados _bw = new BusquedaEmpleados();
                    _bw.InitializeComponent();
                    this.Close();
                    _bw.ShowDialog();
                }
            }
           
        }

        private void UsuariosLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
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

        private void btn_regresarUsuario(object sender, RoutedEventArgs e)
        {
            MantoEmpresa _menuEmpresa = new MantoEmpresa();
            _menuEmpresa.InitializeComponent();
            this.Close();
            _menuEmpresa.ShowDialog();
        }
    }
}
