﻿using System;
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
using WpfApplication3.Utilerias;
using DesktopAlert;
using HelpDesk.RecursosHumanos.Presentacion.Utilerias.Alertas;

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // Instancias de eventos 

        DepartamentosBL _DeptoBL = new DepartamentosBL();
        MunicipioBLL _MunicBL = new MunicipioBLL();
        SituacionProfesionalBLL _SituacionpBL = new SituacionProfesionalBLL();
        TipoEducacionBLL _TipoEducacion = new TipoEducacionBLL();
        InfoBasicaBLL _InfobasicaBL = new InfoBasicaBLL();
        NivelBLL _NivelBL = new NivelBLL();
        HabilidadTecnicaBLL _HabilidadTec = new HabilidadTecnicaBLL();
        tipoReferenciaBELL _TipoRefereniaBL = new tipoReferenciaBELL();
        HabilidadAplicacionBLL _HabilidadApliBL = new HabilidadAplicacionBLL();
        ReferenciasBLL _referenciasBL = new ReferenciasBLL();
        ExperienciaLaboralBLL _experienciaLabBL = new ExperienciaLaboralBLL();
        HabilidadCandidatoBLL _habilidadCandidatoBL = new HabilidadCandidatoBLL();
        InformacionAcademicaBLL _informacionAcademicaBL = new InformacionAcademicaBLL();
        ProfesionesBLL _profesionesBL = new ProfesionesBLL();
        CertificacionesBLL _certificanesBL = new CertificacionesBLL();
        RolUsuarioBLL _RolusuarioBL = new RolUsuarioBLL();
        bool Elijiomagen = false;

        static Imagenes _Imagen = new Imagenes();

        //datatables de cada grid
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }


        private void cmboSearchField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgsample_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {



        }

        private void Label_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void Label_MouseEnter_1(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show("Cambio");
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            
           
            


            try
            {


                dt1.Columns.Add("Nombre de la empresa", typeof(string));
                dt1.Columns.Add("Cargo Desempeñado", typeof(string));
                dt1.Columns.Add("Descripcion del puesto", typeof(string));
                dt1.Columns.Add("Fecha Inicio", typeof(string));
                dt1.Columns.Add("Fecha Fin", typeof(string));
                
                dt2.Columns.Add("IDTipoEduacion", typeof(Int32));
                dt2.Columns.Add("Tipo Educacion", typeof(string));
                dt2.Columns.Add("Titulo", typeof(string));
                dt2.Columns.Add("Institucion", typeof(string));
                dt2.Columns.Add("Año finalizacion", typeof(Int32));
                dt2.Columns.Add("Nombre status", typeof(string));
                dt2.Columns.Add("status", typeof(Int32));

                dt3.Columns.Add("ID HAB TECNICA", typeof(Int32));
                dt3.Columns.Add("HABILIDAD TECNICA", typeof(string));
                dt3.Columns.Add("ID NIVELHABTEC", typeof(Int32));
                dt3.Columns.Add("NIVEL", typeof(string));
                dt3.Columns.Add("ID HAB APP", typeof(Int32));
                dt3.Columns.Add("HABILIDAD APLICACION", typeof(string));

                dt4.Columns.Add("IDTIPOREF", typeof(Int32));
                dt4.Columns.Add("TIPO DE REFERENCIA", typeof(string));
                dt4.Columns.Add("NOMBRE", typeof(string));
                dt4.Columns.Add("TELEFONO", typeof(string));
                dt4.Columns.Add("DESCRIPCION", typeof(string));

                //id_habilidadAplicacion = Convert.ToInt32(cb_habilidadApp.SelectedValue);
                //HabilidadAplicacion = cb_habilidadApp.Text.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al crear las tablas de informacion.");
            }
            try
            {
                //***Esta linea de codigo es para que en el formulario en la parte superiro se vea que usuario esta en el sistema***///
                Title = Title + " Usuario: " + UserLogin.Nombre + "ROL: " + UserLogin.RolID + " " + UserLogin.NRol;


                //DATASET  PARA LLENAR LOS COMBOBOX 
                DataSet ds = new DataSet();
                ds = _DeptoBL.SelectdepSelectAll();

                cbDeptos.ItemsSource = ds.Tables[0].DefaultView;
                cbDeptos.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
                cbDeptos.SelectedValuePath = ds.Tables[0].Columns[0].ToString();
                cbDeptos.SelectedIndex = 0;

                DataSet ds3 = new DataSet();
                ds3 = _TipoEducacion.SelectTipoEducacionALL();

                cb_tipoeducacion.ItemsSource = ds3.Tables[0].DefaultView;
                cb_tipoeducacion.DisplayMemberPath = ds3.Tables[0].Columns[1].ToString();
                cb_tipoeducacion.SelectedValuePath = ds3.Tables[0].Columns[0].ToString();
                cb_tipoeducacion.SelectedIndex = 0;


                DataSet ds4 = new DataSet();
                ds4 = _NivelBL.SelectnivelALL();

                cb_nivelhabapp.ItemsSource = ds4.Tables[0].DefaultView;
                cb_nivelhabapp.DisplayMemberPath = ds4.Tables[0].Columns[1].ToString();
                cb_nivelhabapp.SelectedValuePath = ds4.Tables[0].Columns[0].ToString();
                cb_nivelhabapp.SelectedIndex = 0;

                DataSet ds5 = new DataSet();
                ds5 = _HabilidadTec.SelectHabilidadTecnicaALL();

                cb_habtecnica.ItemsSource = ds5.Tables[0].DefaultView;
                cb_habtecnica.DisplayMemberPath = ds5.Tables[0].Columns[1].ToString();
                cb_habtecnica.SelectedValuePath = ds5.Tables[0].Columns[0].ToString();


                DataSet ds8 = new DataSet();
                ds8 = _TipoRefereniaBL.SelecttipoReferenciaALL();

                cb_tipoRef.ItemsSource = ds8.Tables[0].DefaultView;
                cb_tipoRef.DisplayMemberPath = ds8.Tables[0].Columns[1].ToString();
                cb_tipoRef.SelectedValuePath = ds8.Tables[0].Columns[0].ToString();
                cb_tipoRef.SelectedIndex = 0;

                DataSet ds10 = new DataSet();
                ds10 = _profesionesBL.SelectdepartamentoALL();

                cb_profesionesIB.ItemsSource = ds10.Tables[0].DefaultView;
                cb_profesionesIB.DisplayMemberPath = ds10.Tables[0].Columns[1].ToString();
                cb_profesionesIB.SelectedValuePath = ds10.Tables[0].Columns[0].ToString();
                cb_profesionesIB.SelectedIndex = 0;


                DataSet dss = new DataSet();
                dss = _SituacionpBL.SelectSituacionProfeALL();

                cbSitLab.ItemsSource = dss.Tables[0].DefaultView;
                cbSitLab.DisplayMemberPath = dss.Tables[0].Columns[1].ToString();
                cbSitLab.SelectedValuePath = dss.Tables[0].Columns[0].ToString();
                cbSitLab.SelectedIndex = 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cbDeptos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id_departamento = Convert.ToInt32(cbDeptos.SelectedValue);
            DataSet ds = new DataSet();
            ds = _MunicBL.SelectmunicipioALL(id_departamento);


            //cbMunic.Items.Clear();
            cbMunic.ItemsSource = ds.Tables[0].DefaultView;
            cbMunic.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
            cbMunic.SelectedValuePath = ds.Tables[0].Columns[0].ToString();
            cbMunic.SelectedIndex = 0;
        }

        private void cbMunic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbSitLab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }


        //OTRAS VALIDACIONES SOLO LESTRAS SOLO NUMEROS EN LOS EVENTOS
        private void txtNombreInfBasica_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtNombreInfBasica_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else e.Handled = true;
        }


        private void txtProfesioInfBasica_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
                e.Handled = false;
            else e.Handled = true;

        }

        private void txtProfesioInfBasica_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private void txtNacionalidadInfBasica_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cb_tipoeducacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_RequestBringIntoView_1(object sender, RequestBringIntoViewEventArgs e)
        {

        }


        
        private void BTOAgregarInfAcademica_Click(object sender, RoutedEventArgs e)
        {
            string tipoEducacion, titulo, institucion, StatusName;
            int id_tipoEducacion, status, finalizacion;
            if (!(string.IsNullOrEmpty(cb_tipoeducacion.SelectedValue.ToString()) | string.IsNullOrEmpty(cb_tipoeducacion.Text.ToString()) |
                string.IsNullOrEmpty(txt_Tituloedu.Text) | rb_InfoAcompleto.IsChecked == false))
            {
                id_tipoEducacion = Convert.ToInt32(cb_tipoeducacion.SelectedValue);
                tipoEducacion = cb_tipoeducacion.Text.ToString();
                titulo = txt_Tituloedu.Text;
                institucion = txt_institucionedu.Text;
                finalizacion = Convert.ToInt32(cb_añofinalizacionedu.Text);
                if (rb_InfoAcompleto.IsChecked == true)
                {
                    status = 1;
                    StatusName = "Completo";
                }
                else
                {
                    status = 2;
                    StatusName = "Incompleto";

                }
                bool agregar = true;
                foreach (DataRowView dr in DataGrid_InfAcademica.Items)
                {
                    if ((dr.Row.ItemArray[0].ToString().ToLower()) == id_tipoEducacion.ToString().ToLower() && dr.Row.ItemArray[1].ToString().ToLower() == tipoEducacion.ToLower() &&
                        dr.Row.ItemArray[2].ToString().ToLower() == titulo.ToLower() && dr.Row.ItemArray[3].ToString().ToLower() == institucion.ToLower() && dr.Row.ItemArray[4].ToString().ToLower() == finalizacion.ToString().ToLower() &&
                        dr.Row.ItemArray[5].ToString().ToLower() == StatusName.ToLower() && dr.Row.ItemArray[6].ToString().ToLower() == status.ToString().ToLower())
                    {
                        agregar = false;
                    }
                }
                if (agregar)
                {

                    dt2.Rows.Add(id_tipoEducacion, tipoEducacion, titulo, institucion, finalizacion, StatusName, status);
                }
                else
                {
                    MessageBox.Show("Esa informacion ya ha sido ingresada, por favor revisar los datos.");
                    agregar = true;
                }

                DataGrid_InfAcademica.ItemsSource = dt2.DefaultView;
                cb_tipoeducacion.Text = string.Empty;
                txt_Tituloedu.Text = string.Empty;
                txt_institucionedu.Text = string.Empty;
                cb_añofinalizacionedu.Text = string.Empty;


            }
            else
            {
                MessageBox.Show("Complete todos los campos antes de agregar la informacion.");
            }
        }

        private void DataGrid_InfAcademica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_habtecnica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //PARA LLENAR COMBOBOX DE HABILIDAD TECNICA

            int id_habilidadTecnica = Convert.ToInt32(cb_habtecnica.SelectedValue);
            DataSet ds5 = new DataSet();
            ds5 = _HabilidadApliBL.SelecthabilidadApliALL(id_habilidadTecnica);


            cb_habilidadApp.ItemsSource = ds5.Tables[0].DefaultView;
            cb_habilidadApp.DisplayMemberPath = ds5.Tables[0].Columns[1].ToString();
            cb_habilidadApp.SelectedValuePath = ds5.Tables[0].Columns[0].ToString();
            cb_habilidadApp.SelectedIndex = 0;

        }


        
        private void BTOAgregarInfLaboral_Click(object sender, RoutedEventArgs e)
        {
            //BOTON PARA AGREGAR COMO TEMPORAL A LA GRID DE INFO.LABORAL 

            string NombreEmpesa, CargoDesempeñado, DescripcionPuesto, FechaInicio, fechaFin;
            NombreEmpesa = txt_NombreEmpresaLab.Text;
            CargoDesempeñado = txt_CargoDespeLab.Text;
            DescripcionPuesto = txt_DescripPuestoLab.Text;
            FechaInicio = txt_FechaInicioLab.Text;
            fechaFin = txt_FechaFinLab.Text;

            //ds.Tables.Add(dt);

            bool agregar = true;
            foreach (DataRowView dr in DataGrid_Inf_Laboral.Items)
            {
                if (dr.Row.ItemArray[0].ToString() == NombreEmpesa.ToString() && dr.Row.ItemArray[1].ToString().ToLower() == CargoDesempeñado.ToLower() &&
                  dr.Row.ItemArray[2].ToString().ToLower() == DescripcionPuesto.ToLower() && dr.Row.ItemArray[3].ToString().ToLower() == FechaInicio.ToLower() &&
                  dr.Row.ItemArray[4].ToString().ToLower() == fechaFin.ToLower())
                {
                    agregar = false;
                }
            }
            if (agregar)
            {

                dt1.Rows.Add(NombreEmpesa, CargoDesempeñado, DescripcionPuesto, FechaInicio, fechaFin);

            }
            else
            {
                MessageBox.Show("Esa informacion ya ha sido ingresada, por favor revisar los datos.");
                agregar = true;
            }
            

            DataGrid_Inf_Laboral.ItemsSource = dt1.DefaultView;

            txt_NombreEmpresaLab.Text = string.Empty;
            txt_CargoDespeLab.Text = string.Empty;
            txt_DescripPuestoLab.Text = string.Empty;
            txt_FechaInicioLab.Text = string.Empty;
            txt_FechaFinLab.Text = string.Empty;

            //DataGrid_InfAcademica.ItemsSource = dt;

        }
        
        private void BTOAgregarTipoReferencia_Click(object sender, RoutedEventArgs e)
        {
            string TipoReferencia, Nombre, Telefono, Descripcion;
            int idReferencia;

            idReferencia = Convert.ToInt32(cb_tipoRef.SelectedValue);
            TipoReferencia = cb_tipoRef.Text.ToString();
            Nombre = txt_nombreRef.Text;
            Telefono = txt_telefonoRef.Text;
            Descripcion = txt_descripcionREF.Text;

            bool agregar = true;
            foreach (DataRowView dr in DataGrid_Referencias.Items)
            {
                if (dr.Row.ItemArray[0].ToString() == idReferencia.ToString() && dr.Row.ItemArray[1].ToString().ToLower() == TipoReferencia.ToLower() &&
                  dr.Row.ItemArray[2].ToString().ToLower() == Nombre.ToLower() && dr.Row.ItemArray[3].ToString().ToLower() == Telefono.ToLower() &&
                  dr.Row.ItemArray[4].ToString().ToLower() == Descripcion.ToLower())
                {
                    agregar = false;
                }
            }
            if (agregar)
            {

                dt4.Rows.Add(idReferencia, TipoReferencia, Nombre, Telefono, Descripcion);

            }
            else
            {
                MessageBox.Show("Esa informacion ya ha sido ingresada, por favor revisar los datos.");
                agregar = true;
            }


            DataGrid_Referencias.ItemsSource = dt4.DefaultView;
            cb_tipoRef.Text = string.Empty;
            txt_nombreRef.Text = string.Empty;
            txt_telefonoRef.Text = string.Empty;
            txt_descripcionREF.Text = string.Empty;
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cb_nivelhabapp.Text))
            {
                MessageBox.Show("SELECCIONE EL NIVEL DE SU HABILIDAD TECNICA");
            }
            else if (string.IsNullOrEmpty(cb_habtecnica.Text))
            {
                MessageBox.Show("EL CAMPO DE HABILIDADA TECNICA NO PUEDE QUEDAR VACIO");
            }


            else
            {
                string HabilidadTecnica, Nivel, HabilidadAplicacion;
                int id_habilidadTecnica, id_nivel, id_habilidadAplicacion;

                id_habilidadTecnica = Convert.ToInt32(cb_habtecnica.SelectedValue);
                HabilidadTecnica = cb_habtecnica.Text.ToString();
                id_nivel = Convert.ToInt32(cb_nivelhabapp.SelectedValue);
                Nivel = cb_nivelhabapp.Text.ToString();
                id_habilidadAplicacion = Convert.ToInt32(cb_habilidadApp.SelectedValue);
                HabilidadAplicacion = cb_habilidadApp.Text.ToString();


                bool agregar = true;
                foreach (DataRowView dr in DataG_Habilidades.Items)
                {
                    if (dr.Row.ItemArray[0].ToString() == id_habilidadTecnica.ToString() && dr.Row.ItemArray[1].ToString().ToLower() == HabilidadTecnica.ToLower() &&
                      dr.Row.ItemArray[2].ToString().ToLower() == id_nivel.ToString().ToLower() && dr.Row.ItemArray[3].ToString().ToLower() == Nivel.ToLower() &&
                      dr.Row.ItemArray[4].ToString().ToLower() == id_habilidadAplicacion.ToString().ToLower() && dr.Row.ItemArray[5].ToString().ToLower() == HabilidadAplicacion.ToString().ToLower())
                    {
                        agregar = false;
                    }
                }
                if (agregar)
                {
                    //este codigo borra la fila y luego inserta la nueva, estaba justo despues del if para comprobar si era actualizacion o una nuevo


                    dt3.Rows.Add(id_habilidadTecnica, HabilidadTecnica, id_nivel, Nivel, id_habilidadAplicacion, HabilidadAplicacion);

                  
                }
                else
                {
                    MessageBox.Show("Esa informacion ya ha sido ingresada, por favor revisar los datos.");
                    agregar = true;
                }
                       
                
                DataG_Habilidades.ItemsSource = dt3.DefaultView;

                //cb_habtecnica.Text = string.Empty;
                //cb_nivelhabapp.Text = string.Empty;
                cb_habilidadApp.Text = string.Empty;
            }


        }

        //private void btn_Habilidades_Click(object sender, RoutedEventArgs e)
        //{
        //    // VARIABLE PARA MESAJE DE GUARDAR DATOS DE HABILIDAD
        //    int returVariable1 = 0;

        //    // BOTON PARA GUARDARRR LOS DATOS HABILIDADES  (METODOS)

        //    string oerror = "";
        //    HabCandidatoE refHabCandidato = new HabCandidatoE();
        //    foreach (DataRowView row in DataG_Habilidades.Items)
        //    {


        //        refHabCandidato.idhabilidadTecnica = Convert.ToInt32(row[0]);
        //        refHabCandidato.id_nivel = Convert.ToInt32(row[2]);
        //        refHabCandidato.id_habilidadAplicacion = Convert.ToInt32(row[4]);

        //        returVariable1 = _habilidadCandidatoBL.GuardarHabilidadCandidato(refHabCandidato, ref oerror);

        //    }
        //    if (returVariable1 > 0)
        //    {
        //        MessageBox.Show("Registro fue guardado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        //        tcPrincipal.SelectedIndex = 4;
        //        tab4.IsEnabled = false;

        //    }

        //}

        //private void btn_Guardar_InfoLaboral_Click(object sender, RoutedEventArgs e)
        //{
        //    // VARIABLE PARA MENSAJE DE GUARDAR INFORMACION LABORAL 
        //    int returVariable2 = 0;

        //    //BOTON PARA GUARDAR INFORMACION LABORAL DE LA GRID 

        //    string oerror = "";
        //    ExpLaboralE refExpL = new ExpLaboralE();
        //    foreach (DataRowView row in DataGrid_Inf_Laboral.Items)
        //    {

        //        refExpL.nombreEmpresa = Convert.ToString(row[0]);
        //        refExpL.cargoDesp = Convert.ToString(row[1]);
        //        refExpL.descripPuesto = Convert.ToString(row[2]);
        //        refExpL.fechaInicio = Convert.ToString(row[3]);
        //        refExpL.fechaFin = Convert.ToString(row[4]);

        //        returVariable2 = _experienciaLabBL.GuardarexperienciaLab(refExpL, ref oerror);

        //    }
        //    if (returVariable2 > 0)
        //    {
        //        MessageBox.Show("Registro fue guardado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        //        tcPrincipal.SelectedIndex = 3;
        //        tab3.IsEnabled = false;
        //    }
        //}
        DataTable dt9 = new DataTable();
        private void btn_agragarcertificaciones_Click(object sender, RoutedEventArgs e)
        {
            string nombre, institutucion;
            int anio;
            nombre = txt_TitutloCertificacion.Text;
            institutucion = txt_InstCertiicacion.Text;
            anio = Convert.ToInt32(cb_añoFinCertificacion.Text);

            try
            {
                dt9.Columns.Add("CERTIFICACION", typeof(string));
                dt9.Columns.Add("INSTITUCION DE CERTIFICACION", typeof(string));
                dt9.Columns.Add("AÑO DE FINALIZACION", typeof(Int32));


            }
            catch (Exception)
            {

            }



            bool agregar = true;
            foreach (DataRowView dr in DataGrid_Certificaciones.Items)
            {
                if ((dr.Row.ItemArray[0].ToString().ToLower()) == nombre.ToLower() && dr.Row.ItemArray[1].ToString().ToLower() == institutucion.ToLower() &&
                    dr.Row.ItemArray[2].ToString().ToLower() == anio.ToString().ToLower())
                {
                    agregar = false;
                }
            }
            if (agregar)
            {
                dt9.Rows.Add(nombre, institutucion, anio);
            }
            else
            {
                MessageBox.Show("Esa informacion ya ha sido ingresada, por favor revisar los datos.");
                agregar = true;
            }

            //*****************************************************
           
          

            DataGrid_Certificaciones.ItemsSource = dt9.DefaultView;
            txt_TitutloCertificacion.Text = string.Empty;
            txt_InstCertiicacion.Text = string.Empty;
            cb_añoFinCertificacion.SelectedIndex = 0;
        }

        //private void btn_Certificaciones_Click(object sender, RoutedEventArgs e)
        //{
        //    // VARAIABLE DE MESAJE PARA GUARDAR CERTIFCACIONES 
        //    int returVariable = 0;


        //    //BOTON PARA GUARDAR CERTIFICACIONES EN LA BASE (METODOS)
        //    string oerror = "";
        //    CertificacionesE certifi = new CertificacionesE();
        //    foreach (DataRowView row in DataGrid_Certificaciones.Items)
        //    {
        //        certifi.nombre = Convert.ToString(row[0]);
        //        certifi.institucion = Convert.ToString(row[1]);
        //        certifi.anio = Convert.ToInt16(row[2]);

        //        returVariable = _certificanesBL.GuardarCertificacionesLAB(certifi, ref oerror);

        //    }

        //    if (returVariable > 0)
        //    {
        //        MessageBox.Show("Registro fue guardado con exito..", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
        //        tcPrincipal.SelectedIndex = 5;
        //        tab5.IsEnabled = false;
        //    }

        //}

        private void txt_TitutloCertificacion_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BTOCancelarIngresoInfAcademica_Click(object sender, RoutedEventArgs e)
        {
            //***LIMPIA LAS CAJAS DE TEXTO***//
            cb_tipoeducacion.Text = string.Empty;
            txt_Tituloedu.Text = string.Empty;
            txt_institucionedu.Text = string.Empty;
            cb_añofinalizacionedu.Text = string.Empty;
        }
        private void BTOCancelarIngresoInfLaboral_Click(object sender, RoutedEventArgs e)
        {
            //***LIMPIA LAS CAJAS DE TEXTO***//
            txt_NombreEmpresaLab.Text = string.Empty;
            txt_CargoDespeLab.Text = string.Empty;
            txt_DescripPuestoLab.Text = string.Empty;
            txt_FechaInicioLab.Text = string.Empty;
            txt_FechaFinLab.Text = string.Empty;

        }
        private void BTOcancelarHabTec_Click(object sender, RoutedEventArgs e)
        {

        }
        private void bt_cancerAcertificaciones_Click(object sender, RoutedEventArgs e)
        {
            //***LIMPIA LAS CAJAS DE TEXTO***//
            txt_TitutloCertificacion.Text = string.Empty;
            txt_InstCertiicacion.Text = string.Empty;
            cb_añoFinCertificacion.Text = string.Empty;
        }
        private void BTOCancelaringreTipoReferencia_Click(object sender, RoutedEventArgs e)
        {
            cb_tipoRef.Text = string.Empty;
            txt_nombreRef.Text = string.Empty;
            txt_telefonoRef.Text = string.Empty;
            txt_descripcionREF.Text = string.Empty;

        }
        private void buscarPerfil_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE BUSQUEDA
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();

            //MainWindow _mw = new MainWindow();
            //_mw.InitializeComponent();
            //this.Close();
            //_mw.ShowDialog();
        }

        private void Label_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE MAINWINDOW
            BusquedaEmpleados _busEmple = new BusquedaEmpleados();
            _busEmple.InitializeComponent();
            this.Close();
            _busEmple.Show(); ;
        }


        private void UsuarioMenu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }

        //***BOTON PARA GUARDAR TODA LA INFORMACION DE UN NUEVO PERFIL***/// 
        private void GuardarTodo_Click(object sender, RoutedEventArgs e)
        {

            //VARIABLE DE MENSAJE AL GUARDAR INFORMACION ACADEMICA 

            int returVariable3 = 0;
            int variable1 = 2;
            int variable2 = 0;
            if (variable1 != returVariable3 && variable2 != returVariable3)
            { }
            else if (variable1 != returVariable3 || variable2 != returVariable3) { }
            string cadenaFaltanDatos = "";

            ///////////////////////////////***FIN DEL IF*** //////////////////////////////
            //VALIDA LOS CAMPOS OBLIGATORIOS DEL TAB 1
            if (string.IsNullOrEmpty(txtNombreInfBasica.Text) || string.IsNullOrEmpty(DateFechNacInfoBasica.Text) || string.IsNullOrEmpty(txtNombreInfBasica.Text) || (string.IsNullOrEmpty(cbDeptos.Text)) ||
                (string.IsNullOrEmpty(cbMunic.Text)) || (string.IsNullOrEmpty(cb_profesionesIB.Text)) || (string.IsNullOrEmpty(cbSitLab.Text)) || (string.IsNullOrEmpty(txtTeNocelularInfBasica.Text)) ||
                (string.IsNullOrEmpty(txtCorreoInfBasica.Text)) || (string.IsNullOrEmpty(txtNoduiInfBasica.Text)) || (string.IsNullOrEmpty(txtNnitInfBasica.Text))
                )
            {
                MessageBox.Show("Este fomulario tiene campos obligatorios '*' ", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                if (DateTime.Compare(DateTime.Now.Date, DateFechNacInfoBasica.SelectedDate.Value.Date) > 0)
                {
                    //SE VALIDAN QUE LOS DEMAS GRID CONTENGAN DATOS, SE RECOMIENDA AGREGAR AQUELLOS GRID QUE CONSIDEREN SEAN NECESARIOS.
                    if (DataG_Habilidades.Items.Count == 0 || DataGrid_InfAcademica.Items.Count == 0)
                    {
                        cadenaFaltanDatos = ", YA QUE NO A INGRESADO TODA LA INFORMACION NECESARIA.";
                        MessageBox.Show("Ingrese informacion acdemica y habilidades ya que son formularios requeridos", "Infomacion", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        //PARAMETROS QUE INGRESARAN A LA BASE TAB INFOMACION BASICA
                        InfoBasicaE _InfoBasicaE = new InfoBasicaE();
                        DateTime edad = DateFechNacInfoBasica.SelectedDate.Value;
                        _InfoBasicaE.nombre = txtNombreInfBasica.Text.ToUpper();
                        _InfoBasicaE.nacionalidad = txtNacionalidadInfBasica.Text.ToUpper();
                        _InfoBasicaE.telefono_celular = txtTeNocelularInfBasica.Text.ToUpper();
                        _InfoBasicaE.telefono_fijo = txtTelefonoCasaInfBasica.Text.ToUpper();
                        //_InfoBasicaE.profesiones = cb_profesionesIB.Text.ToUpper();
                        _InfoBasicaE.id_profesiones = Convert.ToInt32(cb_profesionesIB.SelectedValue);
                        _InfoBasicaE.correo = txtCorreoInfBasica.Text;
                        _InfoBasicaE.fecha_nacimiento = DateFechNacInfoBasica.SelectedDate.Value;
                        _InfoBasicaE.direccion = txtLugarResidenciaInfBasica.Text.ToUpper();
                        //_Imagen = ControlImagen.ObtenerImagenEnObjecto(_Imagen.RutaImagen);
                        _InfoBasicaE.FotoCandidato = _Imagen.OnlyName;
                        if (rbsexoM.IsChecked == true)
                        {
                            _InfoBasicaE.id_genero = 1;
                        }
                        else if (rbsexoF.IsChecked == true)
                        {
                            _InfoBasicaE.id_genero = 2;
                        }

                        _InfoBasicaE.DUI = txtNoduiInfBasica.Text;
                        _InfoBasicaE.NIT = txtNnitInfBasica.Text;
                        _InfoBasicaE.AFP = txtNafpInfBasica.Text;
                        _InfoBasicaE.ISSS = txtNiss.Text;
                        _InfoBasicaE.id_municipio = Convert.ToInt32(cbMunic.SelectedValue);
                        _InfoBasicaE.id_situacionProfesional = Convert.ToInt32(cbSitLab.SelectedValue);
                        string oerro = "";

                        int returinfobasica = 0;
                        returinfobasica = _InfobasicaBL.GudarInfBasica(_InfoBasicaE, ref oerro);

                        // BOTON PARA GUARDAR INFORMACION ACADEMICA (EVENTO)

                        InformacionAcademicaE refinfoAcademica = new InformacionAcademicaE();
                        int returinfoacademica = 0;
                        foreach (DataRowView row in DataGrid_InfAcademica.Items)
                        {
                            refinfoAcademica.id_tipoEducacion = Convert.ToInt32(row[0]);
                            refinfoAcademica.titulo = Convert.ToString(row[2]);
                            refinfoAcademica.institucion = Convert.ToString(row[3]);
                            refinfoAcademica.anio_de_finalizacion = Convert.ToInt32(row[4]);
                            refinfoAcademica.id_statusAcademico = Convert.ToInt32(row[6]);

                            returinfoacademica = _informacionAcademicaBL.GuardarInfomacionAcademica(refinfoAcademica, ref oerro);
                        }

                        //BOTON PARA GUARDAR INFORMACION LABORAL


                        ExpLaboralE refExpL = new ExpLaboralE();
                        int returinfoLaboral = 0;
                        foreach (DataRowView row1 in DataGrid_Inf_Laboral.Items)
                        {
                            refExpL.nombreEmpresa = Convert.ToString(row1[0]);
                            refExpL.cargoDesp = Convert.ToString(row1[1]);
                            refExpL.descripPuesto = Convert.ToString(row1[2]);
                            refExpL.fechaInicio = Convert.ToString(row1[3]);
                            refExpL.fechaFin = Convert.ToString(row1[4]);

                            returinfoLaboral = _experienciaLabBL.GuardarexperienciaLab(refExpL, ref oerro);

                        }

                        // BOTON PARA GUARDARRR LOS DATOS HABILIDADES  (METODOS)

                        HabCandidatoE refHabCandidato = new HabCandidatoE();
                        int returnHabilidades = 0;
                        foreach (DataRowView row3 in DataG_Habilidades.Items)
                        {


                            refHabCandidato.idhabilidadTecnica = Convert.ToInt32(row3[0]);
                            refHabCandidato.id_nivel = Convert.ToInt32(row3[2]);
                            refHabCandidato.id_habilidadAplicacion = Convert.ToInt32(row3[4]);

                            returnHabilidades = _habilidadCandidatoBL.GuardarHabilidadCandidato(refHabCandidato, ref oerro);

                        }

                        //BOTON PARA GUARDAR CERTIFICACIONES EN LA BASE (METODOS)

                        CertificacionesE certifi = new CertificacionesE();
                        int returnCertificaciones = 0;

                        foreach (DataRowView row2 in DataGrid_Certificaciones.Items)
                        {
                            certifi.nombre = Convert.ToString(row2[0]);
                            certifi.institucion = Convert.ToString(row2[1]);
                            certifi.anio = Convert.ToInt16(row2[2]);

                            returnCertificaciones = _certificanesBL.GuardarCertificacionesLAB(certifi, ref oerro);

                        }

                        //BOTON PARA INGRESAR REFERENCIAS A
                        RefecenciasE refE = new RefecenciasE();
                        int returReferencias = 0;
                        foreach (DataRowView row5 in DataGrid_Referencias.Items)
                        {
                            refE.id_tipoReferencias = Convert.ToInt32(row5[0]);
                            refE.nombre = Convert.ToString(row5[2]);
                            refE.telefono = Convert.ToString(row5[3]);
                            refE.descripcion = Convert.ToString(row5[4]);

                            returReferencias = _referenciasBL.GuardarReferencias(refE, ref oerro);

                        }
                        if (oerro == "")
                        {
                            #region Capturar imgen por genero
                            string pMensaje = "", pURL = "";
                            switch (_InfoBasicaE.id_genero)
                            {
                                case 1:
                                    pMensaje = "candidato";
                                    pURL = string.IsNullOrEmpty(_Imagen.RutaImagen) ? @"C:\Imagenes\Fotos\User_default\Userman.png" : _Imagen.RutaImagen;
                                    break;
                                case 2:
                                    pMensaje = "candidata";
                                    pURL = string.IsNullOrEmpty(_Imagen.RutaImagen) ? @"C:\Imagenes\Fotos\User_default\userwoman.png" : _Imagen.RutaImagen;
                                    break;
                            }
                            #endregion

                            if (Elijiomagen)
                                ControlImagen.GuardarImagenEnRuta(_Imagen);

                            #region Mostrar mensaje personalizado

                            SimpleAlert simpleAlert = new SimpleAlert();
                            simpleAlert.Title = "Nuevo Registro";
                            simpleAlert.NamePeople = txtNombreInfBasica.Text;
                            simpleAlert.Url = pURL;

                            simpleAlert.Message = "Se ha creado el nuevo " + pMensaje;
                            simpleAlert.ShowDialog();

                            #region Redireccionamiento
                            Busqueda _menusBusqueda = new Busqueda();
                            _menusBusqueda.InitializeComponent();
                            this.Close();
                            _menusBusqueda.Show();
                            #endregion
                            #endregion

                        }

                        else
                        {
                            MessageBoxResult mbr = MessageBox.Show("OCURRIO UN ERROR AL GUARDAR SUS DATOS... ERROR: " + oerro, "Infomacion", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de nacimiento debe ser menor a la fecha actual.","Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginInicio _Li = new LoginInicio();
            _Li.InitializeComponent();
            this.Close();
            _Li.ShowDialog();
        }

        private void CerrarSesionNuevoPerfil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginInicio _Li = new LoginInicio();
            _Li.InitializeComponent();
            this.Close();
            _Li.ShowDialog();
        }

        private void txtNoduiInfBasica_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { //VALIDACION PARA QUE SOLO ACEPTE NUMEROS EN EL EVENTO PreviewTextInput 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57) e.Handled = false;
            else e.Handled = true;
        }

        private void txtTelefonoCasaInfBasica_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { //VALIDACION PARA QUE SOLO ACEPTE NUMEROS EN EL EVENTO PreviewTextInput 
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57) e.Handled = false;
            else e.Handled = true;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE BUSQUEDA
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE BUSQUEDA
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _lo = new Login();
            _lo.InitializeComponent();
            this.Close();
            _lo.ShowDialog();
        }
        //*******Elimina la fila de un registro en la grid sin afecta la base*****///
        private void eliminarFilaNewPerfil_Click(object sender, RoutedEventArgs e)
        {
            DataRowView currentRow = (DataRowView)DataGrid_InfAcademica.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar este registro ", "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                dt2.Rows.Remove(((DataRowView)DataGrid_InfAcademica.SelectedItem).Row);
            }


        }

        //*******Elimina la fila de un registro en la grid sin afecta la base*****///
        private void eliminarReferencias_Click(object sender, RoutedEventArgs e)
        {
            DataRowView currentRow = (DataRowView)DataGrid_Referencias.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar este registro ", "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                dt4.Rows.Remove(((DataRowView)DataGrid_Referencias.SelectedItem).Row);
            }


        }
        //*******Elimina la fila de un registro en la grid sin afecta la base*****///
        private void EliminarFilaInfLaboral_Click(object sender, RoutedEventArgs e)
        {
            DataRowView currentRow = (DataRowView)DataGrid_InfAcademica.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar este registro ", "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                dt1.Rows.Remove(((DataRowView)DataGrid_Inf_Laboral.SelectedItem).Row);
            }
        }

        private void eliminarFiladeHabilidades_Click(object sender, RoutedEventArgs e)
        {
            DataRowView currentRow = (DataRowView)DataGrid_InfAcademica.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar este registro ", "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                dt3.Rows.Remove(((DataRowView)DataG_Habilidades.SelectedItem).Row);
            }
        }

        private void eliminarFilaCertifi_Click(object sender, RoutedEventArgs e)
        {
            DataRowView currentRow = (DataRowView)DataGrid_InfAcademica.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar este registro ", "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                dt9.Rows.Remove(((DataRowView)DataGrid_Certificaciones.SelectedItem).Row);
            }
        }
        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }
        private void menuCandidato_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Busqueda _menusBusqueda = new Busqueda();
            _menusBusqueda.InitializeComponent();
            this.Close();
            _menusBusqueda.Show();
        }

        private void menuEmpleado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BusquedaEmpleados _busEmple = new BusquedaEmpleados();
            _busEmple.InitializeComponent();
            this.Close();
            _busEmple.Show();

        }
        private void menuUsuarios_MouseDown(object sender, MouseButtonEventArgs e)
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
        private void btnCargarImagen_Click(object sender, RoutedEventArgs e)
        {
            //_Imagen.OnlyName = imgFoto.Source.ToString();
            _Imagen = ControlImagen.ObtenerImageDesdeUnArchivo(_Imagen);
           
            if (_Imagen.ImagenEnObjeto != null)
            {
                Elijiomagen = true;
                imgFoto.Source = _Imagen.ImagenEnObjeto;
                lbimagen.Content = _Imagen.RutaImagen;
            }
        }
    }

}



