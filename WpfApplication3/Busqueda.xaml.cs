﻿using System;
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



namespace WpfApplication3
{

   
    /// <summary>
    /// Lógica de interacción para Busqueda.xaml
    /// </summary>
    public partial  class Busqueda : MetroWindow
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

        
        private void lab_menuCreacionPerf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.ShowDialog();
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
                    recuperarMostrarDatosCandidato(ds, _mt);
                    
                    
                    this.Close();
                    _mt.ShowDialog(); 
                }
               
            }
        }

        public void recuperarMostrarDatosCandidato(DataSet ds,MantoCandidatos mt)
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
                    DataRow[] candiInfoAca =new DataRow[50];
                    DataRow[] candiCeriti = new DataRow[50];
                    DataRow[] candiInfoExpe = new DataRow[50];
                    DataRow[] candiHabili = new DataRow[50];
                    foreach (DataRow datar in tableInfoBasica.Rows)
                    {
                        candidatoInfo = datar;

                    }
                    int i = 0;
                    foreach (DataRow datar in tableInfoAcade.Rows)
                    {
                        candiInfoAca[i] = datar;
                        i++;
                    }
                    i = 0;

                    foreach (DataRow datar in tableInfoAcade.Rows)
                    {
                        candiCeriti[i] = datar;
                        i++;
                    }
                    i = 0;
                    foreach (DataRow datar in tableInfoAcade.Rows)
                    {
                        candiInfoExpe[i] = datar;
                        i++;
                    }
                    i = 0;
                    foreach (DataRow datar in tableInfoAcade.Rows)
                    {
                        candiHabili[i] = datar;
                        i++;
                    }
                    i = 0;
            //**********************************************
            //*******************Setear datos*******************

                    mt.setearCampos(candidatoInfo);

        }

    }
}
