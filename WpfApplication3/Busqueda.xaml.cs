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
using System.Collections;
using WpfApplication3.Class;

namespace WpfApplication3
{

   
    /// <summary>
    /// Lógica de interacción para Busqueda.xaml
    /// </summary>
    public partial class Busqueda : MetroWindow
    {
        
        public Object SelectedItem { get; set; }
        InfoBasicaBLL infoBl = new InfoBasicaBLL();
        //public DataRow dataRow = new DataRow();

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
            DataSet ds = infoBl.SelectInfoBusqueda(txtBusqueda.Text, ref oError);
            data_gridBusqueda.ItemsSource = ds.Tables[0].DefaultView;
          
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            string oError = "";
            DataSet ds = infoBl.SelectInfoBusqueda("", ref oError);
            data_gridBusqueda.ItemsSource = ds.Tables[0].DefaultView;

            Title = Title + " Usuario: " + UserLogin.Nombre;
            
           //***IF PARA LOS ROLES DE USUARIO, USUARIOS VISITANTE***//
            if (UserLogin.RolID == 3)
            {
                
                btn_CrearCandidato.Visibility = Visibility.Collapsed;
                data_gridBusqueda.BringIntoView();
                txt_UsuarioMenus.IsEnabled = false;
                btnConfiguracion.IsEnabled = false;
                lab_menuCreacionPerf.IsEnabled = false;
                data_gridBusqueda.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            }
                
            
        }

        private void data_gridBusqueda_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string[] nombre={"0","No existe ese candidato"};
            //foreach(DataRowView dr in data_gridBusqueda.Items)
            //    {
            //        if(data_gridBusqueda.SelectedItem==dr)
            //        nombre[0] = dr[0].ToString();
            //        nombre[1] = dr[1].ToString();
            //    }

            
            //object candidato = (object)data_gridBusqueda.Name;
            //if(candidato!=null)
            //txtBusqueda.Text = candidato.ToString();
            //else txtBusqueda.Text = data_gridBusqueda.SelectedValue.ToString();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.Show();
        }

        //**direccionar al formulario de busqueda empledo**//
        private void lab_menuCreacionPerf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BusquedaEmpleados _busEmple = new BusquedaEmpleados();
            _busEmple.InitializeComponent();
            this.Close();
            _busEmple.Show();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
           //int dataRow = data_gridBusqueda.SelectedIndex;
           // string[] nombre = { "0", "No existe ese candidato" };
           // foreach (DataRowView dr in  data_gridBusqueda.Items)
           // {
           //     if (true)
           //     {
           //         nombre[0] = dr[0].ToString();
           //         nombre[1] = dr[1].ToString();
           //     }
           // }
            
           // MantoCandidatos _mt = new MantoCandidatos();
           // _mt.setearCampos(nombre);
           // this.Close();
           // _mt.ShowDialog(); 

            
        }

        private void Image_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int dataRow = data_gridBusqueda.SelectedIndex;
        }


        //mostrar la ventana de modificar al darle doble click a la fila
        private void data_gridBusqueda_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int dataRow = data_gridBusqueda.SelectedIndex;
            string[] nombre = { "0", "No existe ese candidato" };
            foreach (DataRowView dr in data_gridBusqueda.Items)
            {
                //entro a la linea que le di doble click
                if (dr==data_gridBusqueda.SelectedItem)
                {
                    nombre[0] = dr[0].ToString();
                    nombre[1] = dr[1].ToString();
                    int id=Int32.Parse(nombre[0]);
                    String oError = "";
                    DataSet ds = infoBl.SelectInfoBusquedaLLenar(id, ref oError);
                    //DataTables recuperados

                    MantoCandidatos _mt = new MantoCandidatos();
                    recuperarMostrarDatosCandidato(id.ToString(),-1,ds, _mt);
                    
                    
                    this.Close();
                    _mt.ShowDialog(); 
                }
               
            }
        }

        public void recuperarMostrarDatosCandidato(string id,int idEmpleado,DataSet ds,object mt)
        {

            //***************Recuperar Datos********************************
                    DataTable tableInfoBasica = ds.Tables[0];
                    DataTable tableInfoAcade = ds.Tables[1];
                    DataTable tableCertifi = ds.Tables[2];
                    DataTable tableInfoExpeLab = ds.Tables[3];
                    DataTable tableRefe = ds.Tables[4];
                    DataTable tableHabiliId = ds.Tables[5];
                    


                    String[] infoBasica = new string[12];
                    DataRow candidatoInfo=null;//voy a guardar toda la info del candidato
                        //the next array are instantiated with 50 element to dont will have a exception 
                    List<DataRow>candiInfoAca = new List<DataRow>();//new DataRow[50];
                    List<DataRow> candiCeriti = new List<DataRow>();
                    List<DataRow> candiInfoExpe = new List<DataRow>();
                    List<DataRow> candiHabili = new List<DataRow>();
                    List<DataRow> candiRefe = new List<DataRow>();
            
                    foreach (DataRow datar in tableInfoBasica.Rows)
                    {
                        candidatoInfo = datar;

                    }
                    
                    foreach (DataRow datar in tableInfoAcade.Rows)
                    {
                        candiInfoAca.Add(datar);
                        
                    }
                    

                    foreach (DataRow datar in tableCertifi.Rows)
                    {
                        candiCeriti.Add(datar);
                        
                    }
                    
                    foreach (DataRow datar in tableInfoExpeLab.Rows)
                    {
                        candiInfoExpe.Add(datar);
                    
                    }
                    
                    foreach (DataRow datar in tableHabiliId.Rows)
                    {
                        candiHabili.Add(datar);
                        
                    }

                    foreach (DataRow datar in tableRefe.Rows)
                    {
                        candiRefe.Add(datar);

                    }
            
                    
            //**********************************************
            //*******************Setear datos*******************

                    if (mt is MantoCandidatos)
                    {
                        ((MantoCandidatos)mt).setearCampos(id, candidatoInfo, candiInfoAca, candiInfoExpe, candiHabili, candiCeriti, candiRefe);
                    }
                    else
                    {
                        ((MantoEmpleados)mt).setearCampos(id,idEmpleado, candidatoInfo, candiInfoAca, candiInfoExpe, candiHabili, candiCeriti, candiRefe);
                    }

        }

        private void CerrarSesion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginInicio _Li = new LoginInicio();
            _Li.InitializeComponent();
            this.Close();
            _Li.ShowDialog();
        }

       

        private void Button_ClickVerCandidato(object sender, RoutedEventArgs e)
        {

            DataRowView dr =(DataRowView) data_gridBusqueda.SelectedItem;

            Curriculum curri = new Curriculum(Int32.Parse(dr[0].ToString()));
            
            this.Close();
            curri.Show();
        }

    }
}
