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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow   
    {
        public object SelectItem { get; set; }
        UsuarioBLL usuariobl = new UsuarioBLL();
        
        

        private void btn_nuevo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser ();
             _nu.InitializeComponent();
             this.Close();
             _nu.ShowDialog();
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

       

        private void btn_nuevoUsuario_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser();
            _nu.InitializeComponent();
            this.Close();
            _nu.ShowDialog();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser();
            _nu.InitializeComponent();
            this.Close();
            _nu.ShowDialog();
        }

        private void btn_buscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            string oError = "";
            DataSet ds = usuariobl.Selecusuarios(txt_busquedaUsuario.Text, ref oError);
            DataGrid_Usiarioslogin.ItemsSource = ds.Tables[0].DefaultView;
             
        }

     

        private void DataGrid_Usiarioslogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nombre1="No existe ese candidato";
            foreach (DataRowView dr in DataGrid_Usiarioslogin.Items)
            {
                if (DataGrid_Usiarioslogin.SelectedItem == dr)
                    nombre1 = dr[0].ToString();
            }
            txt_busquedaUsuario.Text = nombre1;
        }

      }
    }
