using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication3;
using HelpDesk.RecursosHumanos.BEL;
using HelpDesk.RecursosHumanos.BLL;
using HelpDesk.RecursosHumanos.DAL;
using System.Data;
using System.Data.SqlClient;
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
        public int id_Usuario;
        public DataSet dsUsuarioLogin = new DataSet();



        private void btn_nuevo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser();
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

        private void DataGrid_Usiarioslogin_Loaded(object sender, RoutedEventArgs e)
        {
            string oError = "";
             dsUsuarioLogin = usuariobl.Selecusuarios("", ref oError);
            DataGrid_Usiarioslogin.ItemsSource = dsUsuarioLogin.Tables[0].DefaultView;
        }

        private void DataGrid_Usiarioslogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string nombre1 = "No existe ese candidato";
            foreach (DataRowView dr in DataGrid_Usiarioslogin.Items)
            {
                if (DataGrid_Usiarioslogin.SelectedItem == dr)
                    nombre1 = dr[0].ToString();
            }
            txt_busquedaUsuario.Text = nombre1;
        }

        private void DataGrid_Usiarioslogin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Se guarda en lista los campos para editar el usuario al dar doble click en la fila 
            int dataRowUsuario = DataGrid_Usiarioslogin.SelectedIndex;
            List<string> listData = new List<string>();
            string[] nombreUsuario = { "0", "No Existe ese candidato" };
            foreach (DataRowView us in DataGrid_Usiarioslogin.SelectedItems)
            {
                if (us == DataGrid_Usiarioslogin.SelectedItem)
                {
                    nombreUsuario[0] = us[0].ToString();
                    nombreUsuario[1] = us[1].ToString();
                    int id = Int32.Parse(nombreUsuario[0]);
                    string oErro = "";
                }

                listData.Add(us[0].ToString());
                listData.Add(us[1].ToString());
                listData.Add(us[3].ToString());
                listData.Add(us[4].ToString());

                ModificarUsuario modUser = new ModificarUsuario();
                
                modUser.listData = listData;
                this.Close();
                modUser.Show();

            }
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Login _lo = new Login();
            _lo.InitializeComponent();
            this.Close();
            _lo.ShowDialog();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            DataRowView currentRow = (DataRowView)DataGrid_Usiarioslogin.SelectedItem;

            usuariosE _deleteUsuario = new usuariosE();

            //entro a la linea que le di doble click

            MessageBoxResult resultMB = MessageBox.Show("Esta seguro de eliminar el usuario: " + currentRow[2].ToString(), "ELIMINAR UN USUARIO", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (resultMB == MessageBoxResult.Yes)

            {
                id_Usuario = int.Parse(currentRow.Row.ItemArray[0].ToString());
                string oError = "";



                _deleteUsuario.id_usuario = id_Usuario;
                if (usuariobl.DeleteUsuario(_deleteUsuario, ref oError) > 0)
                {
                    MessageBox.Show("El usuario fue eliminado con exito"); 
                }
             

                //actualiza la grid
                dsUsuarioLogin = usuariobl.Selecusuarios("", ref oError);
                DataGrid_Usiarioslogin.ItemsSource = dsUsuarioLogin.Tables[0].DefaultView;

                
            }
           
        }
    }
}
