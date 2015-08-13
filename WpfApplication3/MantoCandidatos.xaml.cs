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
    /// Lógica de interacción para MantoCandidatos.xaml
    /// </summary>
    public partial class MantoCandidatos : MetroWindow
    {
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
        AnioBLL _anios = new AnioBLL();
        
        //***************TABLAS DE INFORMACION DEL CANDIDATO*****************

        DataTable tablaReference = new DataTable();
        DataTable tableInfoAcad = new DataTable();
        DataTable tablaExperiencia = new DataTable();
        DataTable tablaCerti = new DataTable();
        DataTable tablaHabilidades = new DataTable();




        //**************Pivotes tables for tabs

        DataRow RowPivotInfoAca = null;

        string idCandidato;
        string idProfesion;
        string idMunicipio;
        string idSituProfe;
        string idGenero;
        string idStatusAcad,idTipoEduca,idTipoRef,idHabiTec,idNivel,idHabiApli;
        string oerro = "";

        //****************id for updates in the database

        string idUpdateInfoAca, idUpdateCertifi, idUpdateExpe, idUpdateRefe, idUpdateHabi;

        bool nuevoInfoAca = true, nuevoExpe = true, nuevoRefe = true, nuevoCerti = true, nuevoHabi = true;

        public MantoCandidatos()
        {
            InitializeComponent();
            
        }

        private void btn_Referencias_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void tcPrincipalModificar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
               if (tcPrincipalModificar.SelectedIndex == 0)
                {

                    btn_ActualizarInfoBasica.Visibility = Visibility.Visible;
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Collapsed;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Collapsed;
                    btn_ActualizarHabilidades.Visibility = Visibility.Collapsed;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Collapsed;
                    btn_ActualizarReferencias.Visibility = Visibility.Collapsed;
                }
                else if (tcPrincipalModificar.SelectedIndex == 1)
                {
                    btn_ActualizarInfoBasica.Visibility = Visibility.Collapsed; 
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Visible;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Collapsed;
                    btn_ActualizarHabilidades.Visibility = Visibility.Collapsed;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Collapsed;
                    btn_ActualizarReferencias.Visibility = Visibility.Collapsed; 
                }

                else if (tcPrincipalModificar.SelectedIndex == 2)
                {
                    btn_ActualizarInfoBasica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Visible;
                    btn_ActualizarHabilidades.Visibility = Visibility.Hidden;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Hidden;
                    btn_ActualizarReferencias.Visibility = Visibility.Hidden;
                }

                else if (tcPrincipalModificar.SelectedIndex == 3)
                {
                    btn_ActualizarInfoBasica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Hidden;
                    btn_ActualizarHabilidades.Visibility = Visibility.Visible;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Hidden;
                    btn_ActualizarReferencias.Visibility = Visibility.Hidden;
                }
                else if (tcPrincipalModificar.SelectedIndex == 4)
                {
                    btn_ActualizarInfoBasica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Hidden;
                    btn_ActualizarHabilidades.Visibility = Visibility.Hidden;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Visible;
                    btn_ActualizarReferencias.Visibility = Visibility.Hidden;

                }
                else if (tcPrincipalModificar.SelectedIndex == 5)
                {
                    btn_ActualizarInfoBasica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Hidden;
                    btn_ActualizarHabilidades.Visibility = Visibility.Hidden;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Hidden;
                    btn_ActualizarReferencias.Visibility = Visibility.Visible;
                }
            }
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.ShowDialog();

        }

        private void lab_buscarPerfil_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();
        }

        public void setearCampos(string idCandi,DataRow datos, List<DataRow> candiInfoAca, List<DataRow> candiInfoExpe, List<DataRow> candiHabili, List<DataRow> candiCeriti, List<DataRow> candiRefe)
        {

            //Seteando Info Basica Tab*******************************
            txtNombreInfBasica.Text = datos.ItemArray[1].ToString();
            txtNacionalidadInfBasica.Text = datos.ItemArray[2].ToString();
            if (datos.ItemArray[3].ToString() == "1")
            {
                rbsexoM.IsChecked = true;
            }
            else {
                rbsexoF.IsChecked = false;
            }

            txtTeNocelularInfBasica.Text = datos.ItemArray[4].ToString();
            txtTelefonoCasaInfBasica.Text = datos.ItemArray[5].ToString();
            idProfesion = datos.ItemArray[6].ToString();
            txtCorreoInfBasica.Text = datos.ItemArray[7].ToString();
            DateFechNacInfoBasica.Text = datos.ItemArray[8].ToString();
            idMunicipio = datos.ItemArray[9].ToString();
            txtLugarResidenciaInfBasica.Text = datos.ItemArray[10].ToString();
            txtNoduiInfBasica.Text = datos.ItemArray[11].ToString();
            txtNnitInfBasica.Text = datos.ItemArray[12].ToString();
            txtNafpInfBasica.Text = datos.ItemArray[13].ToString();
            txtNiss.Text = datos.ItemArray[14].ToString();
            idSituProfe = datos.ItemArray[15].ToString();

            
            //Seteando Info Academica Tab*******************************


            tableInfoAcad.Columns.Add("ID InfoAcade", typeof(Int32));
            tableInfoAcad.Columns.Add("IDTipoEduacion cs", typeof(Int32));
            
            tableInfoAcad.Columns.Add("Tipo Educacion", typeof(string));
            tableInfoAcad.Columns.Add("Titulo", typeof(string));
            tableInfoAcad.Columns.Add("Institucion", typeof(string));
            tableInfoAcad.Columns.Add("Año finalizacion", typeof(Int32));
            tableInfoAcad.Columns.Add("Nombre status", typeof(string));
            tableInfoAcad.Columns.Add("status", typeof(Int32));

            
            string tipoEduca="";
            string statusName="";
            foreach(DataRow dr in candiInfoAca){

                idTipoEduca = dr.ItemArray[5].ToString();
                statusName=dr.ItemArray[4].ToString();
                if (idTipoEduca == "1")
                {
                    tipoEduca = "SECUNDARIA";
                }
                else
                {
                    if (idTipoEduca == "2")
                    {
                        tipoEduca = "SUPERIOR";
                    }
                    else
                    {
                        tipoEduca = "POSTGRADOS";
                    }
                }
                if (statusName == "1")
                {
                    statusName = "COMPLETO";

                }
                else statusName = "INCOMPLETO";




                tableInfoAcad.Rows.Add(dr.ItemArray[0],idTipoEduca,tipoEduca, dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), statusName, Convert.ToInt32(dr.ItemArray[4].ToString()));

                
            }

            
            DataGrid_InfAcademica.ItemsSource = tableInfoAcad.DefaultView;
            
            

            
            //Seteando Info experiencia laboral Tab*******************************


            tablaExperiencia.Columns.Add("Id ExpeLab", typeof(Int32));
            tablaExperiencia.Columns.Add("Nombre de la empresa", typeof(string));
            tablaExperiencia.Columns.Add("Cargo Desempeñado", typeof(string));
            tablaExperiencia.Columns.Add("Descripcion del puesto", typeof(string));
            tablaExperiencia.Columns.Add("Fecha Inicio", typeof(string));
            tablaExperiencia.Columns.Add("Fecha Fin", typeof(string));
            foreach (DataRow dr in candiInfoExpe)
            {
                tablaExperiencia.Rows.Add(dr.ItemArray[0],dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), dr.ItemArray[5].ToString(), dr.ItemArray[6].ToString());
            }

            DataGrid_Inf_Laboral.ItemsSource = tablaExperiencia.DefaultView;
            //Seteando Info Habilidades Tab*******************************


            tablaReference.Columns.Add("ID REF", typeof(Int32));
            tablaReference.Columns.Add("IDTIPOREF", typeof(Int32));
            tablaReference.Columns.Add("TIPO DE REFERENCIA", typeof(string));
            tablaReference.Columns.Add("NOMBRE", typeof(string));
            tablaReference.Columns.Add("TELEFONO", typeof(string));
            tablaReference.Columns.Add("DESCRIPCION", typeof(string));

            string tipoRef = "";

            foreach (DataRow dr in candiRefe)
            {
                if (dr.ItemArray[1].ToString() == "1") tipoRef = "PERSONAL";
                else tipoRef = "LABORAL";

                tablaReference.Rows.Add(dr.ItemArray[0],dr.ItemArray[1].ToString(), tipoRef, dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), dr.ItemArray[5].ToString());
                
            }
            

            DataGrid_Referencias.ItemsSource = tablaReference.DefaultView;
            //Seteando Info Certificaciones Tab*******************************

            tablaCerti.Columns.Add("ID Certi", typeof(Int32));
            tablaCerti.Columns.Add("CERTIFICACION", typeof(string));
            tablaCerti.Columns.Add("INSTITUCION DE CERTIFICACION", typeof(string));
            tablaCerti.Columns.Add("AÑO DE FINALIZACION", typeof(Int32));

            foreach (DataRow dr in candiCeriti)
            {
                tablaCerti.Rows.Add(dr.ItemArray[0],dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString()); //puede dar error por la columna int y el dato string
            }
            DataGrid_Certificaciones.ItemsSource = tablaCerti.DefaultView;

            setearComboBox(idMunicipio, idProfesion,idSituProfe);



            //**********************************************************************

            try
            {
                tablaHabilidades.Columns.Add("ID HAB Candidato", typeof(Int32));
                tablaHabilidades.Columns.Add("ID HAB TECNICA", typeof(Int32));
                tablaHabilidades.Columns.Add("HABILIDAD TECNICA", typeof(string));
                tablaHabilidades.Columns.Add("ID NIVELHABTEC", typeof(Int32));
                tablaHabilidades.Columns.Add("NIVEL", typeof(string));
                tablaHabilidades.Columns.Add("ID HAB APP", typeof(Int32));
                tablaHabilidades.Columns.Add("HABILIDAD APLICACION", typeof(string));

                foreach (DataRow dr in candiHabili)
                {
                    tablaHabilidades.Rows.Add(dr.ItemArray[0],dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), dr.ItemArray[5].ToString(), dr.ItemArray[6].ToString(), dr.ItemArray[7].ToString());  //puede dar error por la columna int y el dato string
                }
              


                DataG_Habilidades.ItemsSource = tablaHabilidades.DefaultView;
            }
            catch(Exception ex){
                MessageBox.Show("Hubo un error al setear los datos de habilidad");
                throw ex;
               
            }


            idCandidato = idCandi;

        }


        public void setearComboBox(string idMuni, string idProfesion,string idSituacion)
        {



            DataSet dsIdDpto = new DataSet();
            dsIdDpto = _MunicBL.SelectDptoPorMunicipio(Int32.Parse(idMuni));

            string id_departamentoGet=(dsIdDpto.Tables[0].Rows[0][0].ToString());
            int id_departamento = Convert.ToInt32(id_departamentoGet);
            DataSet ds = new DataSet();
            ds = _DeptoBL.SelectdepSelectAll();

            cbDeptos.ItemsSource = ds.Tables[0].DefaultView;
            cbDeptos.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
            cbDeptos.SelectedValuePath = ds.Tables[0].Columns[0].ToString();
            cbDeptos.SelectedValue=id_departamento.ToString(); 

            DataSet dsMuni = new DataSet();
            dsMuni = _MunicBL.SelectmunicipioALL();


            //cbMunic.Items.Clear();
            cbMunic.ItemsSource = dsMuni.Tables[0].DefaultView;
            cbMunic.DisplayMemberPath = dsMuni.Tables[0].Columns[1].ToString();
            cbMunic.SelectedValuePath = dsMuni.Tables[0].Columns[0].ToString();
            cbMunic.SelectedValue = idMuni.ToString();


            DataSet ds3 = new DataSet();
            ds3 = _TipoEducacion.SelectTipoEducacionALL();

            cb_tipoeducacion.ItemsSource = ds3.Tables[0].DefaultView;
            cb_tipoeducacion.DisplayMemberPath = ds3.Tables[0].Columns[1].ToString();
            cb_tipoeducacion.SelectedValuePath = ds3.Tables[0].Columns[0].ToString();
            cb_tipoeducacion.SelectedIndex = 0;



            DataSet ds10 = new DataSet();
            ds10 = _profesionesBL.SelectdepartamentoALL();

            cb_profesionesIB.ItemsSource = ds10.Tables[0].DefaultView;
            cb_profesionesIB.DisplayMemberPath = ds10.Tables[0].Columns[1].ToString();
            cb_profesionesIB.SelectedValuePath = ds10.Tables[0].Columns[0].ToString();
            cb_profesionesIB.SelectedIndex = Int32.Parse(idProfesion)-1;

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


            DataSet dss = new DataSet();
            dss = _SituacionpBL.SelectSituacionProfeALL();

            cbSitLab.ItemsSource = dss.Tables[0].DefaultView;
            cbSitLab.DisplayMemberPath = dss.Tables[0].Columns[1].ToString();
            cbSitLab.SelectedValuePath = dss.Tables[0].Columns[0].ToString();
            cbSitLab.SelectedIndex = Int32.Parse(idSituacion)-1;

            DataSet ds8 = new DataSet();
            ds8 = _TipoRefereniaBL.SelecttipoReferenciaALL();

            cb_tipoRef.ItemsSource = ds8.Tables[0].DefaultView;
            cb_tipoRef.DisplayMemberPath = ds8.Tables[0].Columns[1].ToString();
            cb_tipoRef.SelectedValuePath = ds8.Tables[0].Columns[0].ToString();
            cb_tipoRef.SelectedIndex = 0;

            DataSet dsAnio = new DataSet();
            dsAnio = _anios.getAnios();
            cb_añofinalizacionedu.ItemsSource = dsAnio.Tables[0].DefaultView;
            cb_añofinalizacionedu.DisplayMemberPath = dsAnio.Tables[0].Columns[1].ToString();
            cb_añofinalizacionedu.SelectedValuePath = dsAnio.Tables[0].Columns[0].ToString();
            cb_añofinalizacionedu.SelectedIndex = 0;

            cb_añoFinCertificacion.ItemsSource = dsAnio.Tables[0].DefaultView;
            cb_añoFinCertificacion.DisplayMemberPath = dsAnio.Tables[0].Columns[1].ToString();
            cb_añoFinCertificacion.SelectedValuePath = dsAnio.Tables[0].Columns[0].ToString();
            cb_añoFinCertificacion.SelectedIndex = 0;



        }

        //**************************************************************************************************

        //************************************INFORMACION ACADEMICA*************************************

        //ERROR a CORREGIR: al insertar una actualizacion (agregar) debo de retornar el id de la nueva fila generada y eso mandarselo en el metodo Add a la datatable.

        private void DataGrid_InfAcademica_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            nuevoInfoAca = false;
            
            
            
            foreach (DataRowView dr in DataGrid_InfAcademica.Items)
            {
                
                //entro a la linea que le di doble click
                if (dr == DataGrid_InfAcademica.SelectedItem)
                {
                    idUpdateInfoAca = dr[0].ToString();
                    cb_tipoeducacion.SelectedValue = dr[1].ToString();
                    txt_Tituloedu.Text = dr[3].ToString();
                    txt_institucionedu.Text = dr[4].ToString();
                    cb_añofinalizacionedu.SelectedValue = dr[5].ToString(); ;
                    if (dr[7].ToString() == "1") rb_InfoAcompleto.IsChecked = true;
                    else rb_InfoIncompleto.IsChecked = true;

                    
                    RowPivotInfoAca = dr.Row;
                           
                   
                }

            }
            
            //tableInfoAcad.Rows.Remove(RowPivot);
            //DataGrid_InfAcademica.ItemsSource = tableInfoAcad.DefaultView;
//            DataGrid_InfAcademica.Items.RemoveAt(dataRow);


        }

        private void BTOAgregarInfAcademica_Click(object sender, RoutedEventArgs e)
        {


                        if ( !(string.IsNullOrEmpty(cb_tipoeducacion.Text) | string.IsNullOrEmpty(txt_Tituloedu.Text) |
                        string.IsNullOrEmpty(txt_institucionedu.Text) | string.IsNullOrEmpty(cb_añofinalizacionedu.Text)))
                        {
                            if (nuevoInfoAca == false)
                            {
                                tableInfoAcad.Rows.Remove(RowPivotInfoAca);
                                RowPivotInfoAca = null;
                                string tipoEducacion, titulo, institucion, StatusName;
                                int id_tipoEducacion, status, finalizacion;

                                id_tipoEducacion = Convert.ToInt32(cb_tipoeducacion.SelectedValue);
                                tipoEducacion = cb_tipoeducacion.Text.ToString();
                                titulo = txt_Tituloedu.Text;
                                institucion = txt_institucionedu.Text;
                                finalizacion = Convert.ToInt32(cb_añofinalizacionedu.SelectedValue);
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

                                InformacionAcademicaE infoObjeto = new InformacionAcademicaE();
                                infoObjeto.id_informacionAcademica = (int.Parse(idUpdateInfoAca));
                                infoObjeto.id_statusAcademico = status;
                                infoObjeto.id_tipoEducacion = id_tipoEducacion;
                                infoObjeto.institucion = institucion;
                                infoObjeto.titulo = titulo;
                                infoObjeto.anio_de_finalizacion = finalizacion;

                                InformacionAcademicaBLL infoBll = new InformacionAcademicaBLL();
                                infoBll.ActualizarInfomacionAcademica(infoObjeto, int.Parse(idCandidato), ref oerro);



                                tableInfoAcad.Rows.Add(infoObjeto.id_informacionAcademica, id_tipoEducacion, tipoEducacion, titulo, institucion, finalizacion, StatusName, status);

                                //DataGrid_InfAcademica.ItemsSource = dt2.DefaultView;
                                cb_tipoeducacion.Text = string.Empty;
                                txt_Tituloedu.Text = string.Empty;
                                txt_institucionedu.Text = string.Empty;
                                cb_añofinalizacionedu.Text = string.Empty;
                                nuevoInfoAca = true;
                            }
                            else
                            {
                                agregarInfoAcade();
                            }
                            
                        }

                        else
                        {
                            MessageBox.Show("Inserte todos los datos solicitados");
                        }

        }

        private void BTOCancelarIngresoInfAcademica_Click(object sender, RoutedEventArgs e)
        {
//            tableInfoAcad.Rows.Add(RowPivotInfoAca);
            RowPivotInfoAca = null;
            nuevoInfoAca = true;
            cb_tipoeducacion.SelectedValue = 0;
            txt_Tituloedu.Text = "";
            txt_institucionedu.Text = "";
            cb_añofinalizacionedu.SelectedValue = 0;
            rb_InfoAcompleto.IsChecked = false;
            rb_InfoIncompleto.IsChecked = false;
        }


        //**************************************************************************************************

        //**************************INFORMACION LABORAL O EXPERIENCIA*************************************

        private void DataGrid_Inf_Laboral_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            nuevoExpe = false;

                foreach (DataRowView dr in DataGrid_Inf_Laboral.Items)
                {



                    //entro a la linea que le di doble click
                    if (dr == DataGrid_Inf_Laboral.SelectedItem)
                    {
                        idUpdateExpe = dr[0].ToString();
                        txt_NombreEmpresaLab.Text = dr[1].ToString();
                        txt_CargoDespeLab.Text = dr[2].ToString();
                        txt_DescripPuestoLab.Text = dr[3].ToString();
                        txt_FechaInicioLab.Text = dr[4].ToString();
                        txt_FechaFinLab.Text = dr[5].ToString();
                        //txt_FechaFinLab.Text = dr[5].ToString();


                        RowPivotInfoAca = dr.Row;


                    }
                }
            
              
           
        }

        private void BTOAgregarInfLaboral_Click(object sender, RoutedEventArgs e)
        {
            if(!( string.IsNullOrEmpty(txt_NombreEmpresaLab.Text)|string.IsNullOrEmpty(txt_CargoDespeLab.Text)|
                    string.IsNullOrEmpty(txt_DescripPuestoLab.Text)| string.IsNullOrEmpty(  txt_FechaInicioLab.Text )|
                    string.IsNullOrEmpty(txt_FechaFinLab.Text)))

            {
                    if (nuevoExpe == false)
                    {
                                tablaExperiencia.Rows.Remove(RowPivotInfoAca);
                                RowPivotInfoAca = null;

                                

                                string NombreEmpesa, CargoDesempeñado, DescripcionPuesto, FechaInicio, fechaFin;
                                NombreEmpesa = txt_NombreEmpresaLab.Text;
                                CargoDesempeñado = txt_CargoDespeLab.Text;
                                DescripcionPuesto = txt_DescripPuestoLab.Text;
                                FechaInicio = txt_FechaInicioLab.Text;
                                fechaFin = txt_FechaFinLab.Text;

                                //ds.Tables.Add(dt);

                                ExpLaboralE expeObj = new ExpLaboralE();
                                expeObj.id_experienciaLaboral =Int32.Parse( idUpdateExpe);
                                expeObj.nombreEmpresa = NombreEmpesa;
                                expeObj.cargoDesp = CargoDesempeñado;
                                expeObj.descripPuesto = DescripcionPuesto;
                                expeObj.fechaInicio = FechaInicio;
                                expeObj.fechaFin = fechaFin;

                                ExperienciaLaboralBLL expeBll = new ExperienciaLaboralBLL();
                                expeBll.ActualizarExperienciaLab(expeObj, Int32.Parse(idCandidato), ref oerro);



                                tablaExperiencia.Rows.Add(idUpdateExpe,NombreEmpesa, CargoDesempeñado, DescripcionPuesto, FechaInicio, fechaFin);

            

                                txt_NombreEmpresaLab.Text = string.Empty;
                                txt_CargoDespeLab.Text = string.Empty;
                                txt_DescripPuestoLab.Text = string.Empty;
                                txt_FechaInicioLab.Text = string.Empty;
                                txt_FechaFinLab.Text = string.Empty;

                                //DataGrid_InfAcademica.ItemsSource = dt;

                                nuevoExpe = true;
            
                    }
                    else
                    {
                        agregarExperiencia();
                    }


            }
            else
            {
                MessageBox.Show("Debe llenar todos los datos solicitados");
            }
        }

        private void BTOCancelarIngresoInfLaboral_Click(object sender, RoutedEventArgs e)
        {
            nuevoExpe = true;

            txt_NombreEmpresaLab.Text = string.Empty;
            txt_CargoDespeLab.Text = string.Empty;
            txt_DescripPuestoLab.Text = string.Empty;
            txt_FechaInicioLab.Text = string.Empty;
            txt_FechaFinLab.Text = string.Empty;
        }
        //**************************************************************************************************
        //*****************************************CERTIFICACIONES******************************************
        private void DataGrid_Certificaciones_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            nuevoCerti = false;
            
            foreach (DataRowView dr in DataGrid_Certificaciones.Items)
            {

                //error con la tabla inconsistencia de columnas

                //entro a la linea que le di doble click
                if (dr == DataGrid_Certificaciones.SelectedItem)
                {
                    idUpdateCertifi = dr[0].ToString();
                    txt_TitutloCertificacion.Text = dr[1].ToString();
                    txt_InstCertiicacion.Text = dr[2].ToString();
                    cb_añoFinCertificacion.SelectedValue = dr[3].ToString();
                    


                    RowPivotInfoAca = dr.Row;


                }
            }
        }
        private void btn_agragarcertificaciones_Click(object sender, RoutedEventArgs e)
        {

            if (!(string.IsNullOrEmpty(txt_TitutloCertificacion.Text) | string.IsNullOrEmpty(txt_InstCertiicacion.Text) | cb_añoFinCertificacion.SelectedIndex == -1))
            {
                if (nuevoCerti == false)
                {

                    tablaCerti.Rows.Remove(RowPivotInfoAca);
                    RowPivotInfoAca = null;
                    string nombre, institutucion;
                    int anio;
                    nombre = txt_TitutloCertificacion.Text;
                    institutucion = txt_InstCertiicacion.Text;
                    anio = Convert.ToInt32(cb_añoFinCertificacion.Text);

                    
                    CertificacionesE certiObj = new CertificacionesE();
                    certiObj.id_candidato = (int.Parse(idCandidato));
                    certiObj.id_certificaciones = int.Parse(idUpdateCertifi);
                    certiObj.institucion = institutucion;
                    certiObj.nombre = nombre;
                    certiObj.anio = anio;

                    CertificacionesBLL certiBll = new CertificacionesBLL();
                    certiBll.ActualizarCertificacionesLAB(certiObj, certiObj.id_candidato, ref oerro);



                    tablaCerti.Rows.Add(certiObj.id_certificaciones,nombre, institutucion, anio);

                    txt_TitutloCertificacion.Text = string.Empty;
                    txt_InstCertiicacion.Text = string.Empty;
                    cb_añoFinCertificacion.SelectedIndex = 0;
                    nuevoCerti = true;
                }
                else
                {
                    //falta metodo agregar certificacion
                    agregarCertificacion();
                    
                }
            }
            else
            {
                MessageBox.Show("Inserte todos los datos solicitados");
            }
        }

        private void bt_cancerAcertificaciones_Click(object sender, RoutedEventArgs e)
        {

            nuevoCerti = true;
            txt_TitutloCertificacion.Text = string.Empty;
            txt_InstCertiicacion.Text = string.Empty;
            cb_añoFinCertificacion.SelectedIndex = 0;
        }

        
        //**************************************************************************************************
        //*****************************************REFERENCIAS******************************************


        private void DataGrid_Referencias_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            nuevoRefe = false;
            foreach (DataRowView dr in DataGrid_Referencias.Items)
            {

  
              
                //entro a la linea que le di doble click
                if (dr == DataGrid_Referencias.SelectedItem)
                {
                    idUpdateRefe = dr[0].ToString();
                    cb_tipoRef.SelectedValue = dr[1].ToString();
                    txt_nombreRef.Text = dr[3].ToString();
                    txt_telefonoRef.Text = dr[4].ToString();
                    txt_descripcionREF.Text = dr[5].ToString();
                    


                    RowPivotInfoAca = dr.Row;


                }
            }
        }

        private void BTOAgregarTipoReferencia_Click(object sender, RoutedEventArgs e)
        {

            if (!(string.IsNullOrEmpty(cb_tipoRef.Text) | string.IsNullOrEmpty(txt_nombreRef.Text) | string.IsNullOrEmpty(txt_telefonoRef.Text) |
                string.IsNullOrEmpty(txt_descripcionREF.Text)))
            {
                if (nuevoRefe == false)
                {
                    tablaReference.Rows.Remove(RowPivotInfoAca);

                    RowPivotInfoAca = null;
                    string TipoReferencia, Nombre, Telefono, Descripcion;
                    int idReferencia;

                    idReferencia = Convert.ToInt32(cb_tipoRef.SelectedValue);
                    TipoReferencia = cb_tipoRef.Text.ToString();
                    Nombre = txt_nombreRef.Text;
                    Telefono = txt_telefonoRef.Text;
                    Descripcion = txt_descripcionREF.Text;

                    RefecenciasE refeObj = new RefecenciasE();
                    refeObj.id_referencias = int.Parse(idUpdateRefe);
                    refeObj.id_tipoReferencias = idReferencia;
                    refeObj.nombre = Nombre;
                    refeObj.telefono = Telefono;
                    refeObj.descripcion = Descripcion;

                    ReferenciasBLL refeBll = new ReferenciasBLL();
                    refeBll.ActualizarReferencias(refeObj, int.Parse(idCandidato), ref oerro);


                    tablaReference.Rows.Add(refeObj.id_referencias,idReferencia, TipoReferencia, Nombre, Telefono, Descripcion);

                    cb_tipoRef.Text = string.Empty;
                    txt_nombreRef.Text = string.Empty;
                    txt_telefonoRef.Text = string.Empty;
                    txt_descripcionREF.Text = string.Empty;
                    nuevoRefe = true;
                }
                else
                {
                    agregarReferencia();
                }
            }
            else
            {
                MessageBox.Show("Inserte todos los datos solicitados");
            }
        }

        private void BTOCancelaringreTipoReferencia_Click(object sender, RoutedEventArgs e)
        {
            nuevoRefe = true;
            cb_tipoRef.Text = string.Empty;
            txt_nombreRef.Text = string.Empty;
            txt_telefonoRef.Text = string.Empty;
            txt_descripcionREF.Text = string.Empty;
        }

        //*******************************************************************************************


        private void DataG_Habilidades_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {


            nuevoHabi = false;
            foreach (DataRowView dr in DataG_Habilidades.Items)
            {



                //entro a la linea que le di doble click
                if (dr == DataG_Habilidades.SelectedItem)
                {
                    idUpdateHabi = dr[0].ToString();
                    cb_habtecnica.SelectedValue = dr[1].ToString();
                    cb_nivelhabapp.SelectedValue= dr[3].ToString();
                    llenarHabilidadApp();
                    cb_habilidadApp.SelectedValue = dr[5].ToString();
                    



                    RowPivotInfoAca = dr.Row;


                }
            }

        }

        private void BTOagregarHabTec_Click(object sender, RoutedEventArgs e)
        {

            if (!(string.IsNullOrEmpty(cb_habtecnica.Text) | string.IsNullOrEmpty(cb_nivelhabapp.Text) | string.IsNullOrEmpty(cb_habilidadApp.Text)))
            {

                if (nuevoHabi == false)
                {
                    tablaHabilidades.Rows.Remove(RowPivotInfoAca);

                    RowPivotInfoAca = null;

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


                        HabCandidatoE habObj = new HabCandidatoE();
                        habObj.id_candidato = int.Parse(idCandidato);
                        habObj.id_habilidadAplicacion = id_habilidadAplicacion;
                        habObj.id_habilidadCandidato = int.Parse(idUpdateHabi);
                        habObj.id_nivel = id_nivel;
                        habObj.idhabilidadTecnica = id_habilidadTecnica;

                        HabilidadCandidatoBLL habiBll = new HabilidadCandidatoBLL();
                        habiBll.ActualizarHabilidadCandidato(habObj, habObj.id_candidato, ref oerro);


                        tablaHabilidades.Rows.Add(habObj.id_habilidadCandidato,id_habilidadTecnica, HabilidadTecnica, id_nivel, Nivel, id_habilidadAplicacion, HabilidadAplicacion);


                        cb_habtecnica.Text = string.Empty;
                        cb_nivelhabapp.Text = string.Empty;
                        cb_habilidadApp.Text = string.Empty;
                        nuevoHabi = true;
                    }
                }
                else
                {
                    agregarHabilidad();
                }
            }
            else
            {
                MessageBox.Show("Inserte todos los datos solicitados");
            }

        }

        private void BTOcancelarHabTec_Click(object sender, RoutedEventArgs e)
        {
            nuevoHabi = true;
            cb_habilidadApp.SelectedIndex = -1;
            cb_habtecnica.SelectedIndex = -1;
            cb_nivelhabapp.SelectedIndex = -1;
        }

//        **********************************************************************************************
        private void DataGrid_InfAcademica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login _mt = new Login();
            _mt.InitializeComponent();
            this.Close();
            _mt.ShowDialog();
        }

        private void buscarPerfil_MouseDown(object sender, MouseButtonEventArgs e)
        {  
            //EVENTO PARA REDIRECCIONAR AL FORMULARIO DE BUSQUEDA
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();

        }





        //**************************************************************************************************



        //********************************METHODS TO ADD NEW ROWS TO THE TABLES******************************

        public void agregarInfoAcade()
        {
            string tipoEducacion, titulo, institucion, StatusName;
            int id_tipoEducacion, status, finalizacion;

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
            try
            {
                
                InformacionAcademicaE refinfoAcademica = new InformacionAcademicaE();
                refinfoAcademica.id_tipoEducacion = id_tipoEducacion;
                refinfoAcademica.titulo = titulo;
                refinfoAcademica.institucion = institucion;
                refinfoAcademica.anio_de_finalizacion = finalizacion;
                refinfoAcademica.id_statusAcademico = status;
                int returinfoacademica = 0;

                int id = Int32.Parse(idCandidato);
                returinfoacademica = _informacionAcademicaBL.AgregarInfomacionAcademica(refinfoAcademica, int.Parse(idCandidato),ref oerro);

                tableInfoAcad.Rows.Add(returinfoacademica,id_tipoEducacion, tipoEducacion, titulo, institucion, finalizacion, StatusName, status);
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrio un error al momento de actualizar la información.!","Error al Actualizar",MessageBoxButton.OK,MessageBoxImage.Error);
                throw ex;
            }

            
            cb_tipoeducacion.Text = string.Empty;
            txt_Tituloedu.Text = string.Empty;
            txt_institucionedu.Text = string.Empty;
            cb_añofinalizacionedu.Text = string.Empty;             

        }

        //**************************//**************************//**************************
        protected void agregarExperiencia()
        {
            string NombreEmpesa, CargoDesempeñado, DescripcionPuesto, FechaInicio, fechaFin;
            NombreEmpesa = txt_NombreEmpresaLab.Text;
            CargoDesempeñado = txt_CargoDespeLab.Text;
            DescripcionPuesto = txt_DescripPuestoLab.Text;
            FechaInicio = txt_FechaInicioLab.Text;
            fechaFin = txt_FechaFinLab.Text;

            //procedimiento para agregar una nueva experiencia a la base

            ExpLaboralE refExpL = new ExpLaboralE();
            int returinfoLaboral = 0;
            refExpL.nombreEmpresa = NombreEmpesa;
            refExpL.cargoDesp = CargoDesempeñado;
            refExpL.descripPuesto = DescripcionPuesto;
            refExpL.fechaInicio = FechaInicio;
            refExpL.fechaFin = fechaFin;

            returinfoLaboral = _experienciaLabBL.AgregarexperienciaLab(refExpL,int.Parse(idCandidato), ref oerro); 
            
            //************************************************

            tablaExperiencia.Rows.Add(returinfoLaboral, NombreEmpesa, CargoDesempeñado, DescripcionPuesto, FechaInicio, fechaFin);

            
            txt_NombreEmpresaLab.Text = string.Empty;
            txt_CargoDespeLab.Text = string.Empty;
            txt_DescripPuestoLab.Text = string.Empty;
            txt_FechaInicioLab.Text = string.Empty;
            txt_FechaFinLab.Text = string.Empty;


            
        }

        //************************************************************************
        protected void agregarReferencia()
        {
            string TipoReferencia, Nombre, Telefono, Descripcion;
            int idReferencia;

            idReferencia = Convert.ToInt32(cb_tipoRef.SelectedValue);
            TipoReferencia = cb_tipoRef.Text.ToString();
            Nombre = txt_nombreRef.Text;
            Telefono = txt_telefonoRef.Text;
            Descripcion = txt_descripcionREF.Text;

            //Procedimiento para agregar referencia a la base

             RefecenciasE refE = new RefecenciasE();
                int returReferencias = 0;

                refE.id_tipoReferencias = idReferencia;
                refE.nombre = Nombre;
                refE.telefono = Telefono;
                refE.descripcion = Descripcion;

                    returReferencias = _referenciasBL.AgregarReferencias(refE,Int32.Parse(idCandidato), ref oerro);


            //************************************************************************

                    tablaReference.Rows.Add(returReferencias,idReferencia, TipoReferencia, Nombre, Telefono, Descripcion);
            
            cb_tipoRef.Text = string.Empty;
            txt_nombreRef.Text = string.Empty;
            txt_telefonoRef.Text = string.Empty;
            txt_descripcionREF.Text = string.Empty;
        }


        //**************************//**************************//**************************

        protected void agregarHabilidad()
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


                //Procedimiento para agregar las habilidades a la base

                 HabCandidatoE refHabCandidato = new HabCandidatoE();
                int returnHabilidades = 0;



                refHabCandidato.idhabilidadTecnica = id_habilidadTecnica;
                    refHabCandidato.id_nivel = id_nivel;
                    refHabCandidato.id_habilidadAplicacion = id_habilidadAplicacion;

                    returnHabilidades = _habilidadCandidatoBL.AgregarHabilidadCandidato(refHabCandidato,int.Parse(idCandidato), ref oerro);


                //********************************************************


                    tablaHabilidades.Rows.Add(returnHabilidades,id_habilidadTecnica, HabilidadTecnica, id_nivel, Nivel, id_habilidadAplicacion, HabilidadAplicacion);
                DataG_Habilidades.ItemsSource = tablaHabilidades.DefaultView;

                cb_habtecnica.Text = string.Empty;
                cb_nivelhabapp.Text = string.Empty;
                cb_habilidadApp.Text = string.Empty;
            }

           
        }

        //*****************************************************************************************


        public void agregarCertificacion(){

            string nombre, institutucion;
            int anio;
            nombre = txt_TitutloCertificacion.Text;
            institutucion = txt_InstCertiicacion.Text;
            anio = Convert.ToInt32(cb_añoFinCertificacion.Text);
            

            //Procedimiento para agregar Certificacion a la base

              CertificacionesE certifi = new CertificacionesE();
                int returnCertificaciones = 0;

                    certifi.nombre = nombre;
                    certifi.institucion =institutucion;
                    certifi.anio =anio;

                    returnCertificaciones = _certificanesBL.AgregarCertificacionesLAB(certifi, int.Parse(idCandidato),ref oerro); 

            //*****************************************************
                    tablaCerti.Rows.Add(returnCertificaciones,nombre, institutucion, anio);

            cb_añofinalizacionedu.SelectedIndex = -1;
            txt_InstCertiicacion.Text=string.Empty;
            txt_TitutloCertificacion.Text=string.Empty;
            
        }
        //*****************************************************************************************

        private void cb_habtecnica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            llenarHabilidadApp();
        }

        protected void llenarHabilidadApp()
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

        private void CerrarSesion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginInicio _Li = new LoginInicio ();
            _Li.InitializeComponent();
            this.Close();
            _Li.ShowDialog();
        }

        private void btn_ActualizarInfoBasica_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR A ESTE CANDIDATO?\n \n Una vez eliminado no se podrá recuperar...\n \n", "MENSAJE DE CONFIRMACION", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                InfomacionBasicaDAL infoEliminar = new InfomacionBasicaDAL();
                infoEliminar.borrarCandidato(Convert.ToInt16(idCandidato));
                Busqueda busqueda = new Busqueda();
                busqueda.InitializeComponent();
                busqueda.Show();
                this.Close();
            }

        }

     

       
       

        private void Button_Click_DeleteInfoAcad(object sender, RoutedEventArgs e)
        {

            DataRowView currentRow = (DataRowView)DataGrid_InfAcademica.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar el registro de " + currentRow[3].ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _informacionAcademicaBL.BorrarInfoAcade(int.Parse(currentRow[0].ToString()), ref oerro);
                //DataGrid_Certificaciones.Items.Remove(currentRow);
                tableInfoAcad.Rows.Remove(((DataRowView)DataGrid_InfAcademica.SelectedItem).Row);
            }
        }

        private void Button_Click_DeleteExpeLab(object sender, RoutedEventArgs e)
        {

            DataRowView currentRow = (DataRowView)DataGrid_Inf_Laboral.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar la informacion Laboral de " + currentRow[2].ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _experienciaLabBL.BorrarExpLab(int.Parse(currentRow[0].ToString()), ref oerro);
                //DataGrid_Certificaciones.Items.Remove(currentRow);
                tablaExperiencia.Rows.Remove(((DataRowView)DataGrid_Inf_Laboral.SelectedItem).Row);
            }
        }

        private void Button_Click_DeleteCertificaciones(object sender, RoutedEventArgs e)
        {
            
            DataRowView currentRow = (DataRowView)DataGrid_Certificaciones.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar la Certificacion " + currentRow[1].ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _certificanesBL.BorrarCertificacion(int.Parse(currentRow[0].ToString()), ref oerro);
                //DataGrid_Certificaciones.Items.Remove(currentRow);
                tablaCerti.Rows.Remove(((DataRowView)DataGrid_Certificaciones.SelectedItem).Row);
            }
        }

        private void Button_Click_DeleteHabili(object sender, RoutedEventArgs e)
        {

            DataRowView currentRow = (DataRowView)DataG_Habilidades.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar la Habilidad de " + currentRow[6].ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _habilidadCandidatoBL.BorrarHabilidad(int.Parse(currentRow[0].ToString()), ref oerro);
                //DataGrid_Certificaciones.Items.Remove(currentRow);
                tablaHabilidades.Rows.Remove(((DataRowView)DataG_Habilidades.SelectedItem).Row);
            }
        }

        private void Button_Click_DeleteReferencia(object sender, RoutedEventArgs e)
        {

            DataRowView currentRow = (DataRowView)DataGrid_Referencias.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Esta seguro de Eliminar la referencia de " + currentRow[3].ToString(), "Mensaje de Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _referenciasBL.BorrarReferencia(int.Parse(currentRow[0].ToString()), ref oerro);
                //DataGrid_Certificaciones.Items.Remove(currentRow);
                tablaReference.Rows.Remove(((DataRowView)DataGrid_Referencias.SelectedItem).Row);
            }
        }

        private void btn_ActualizarInfoBasica_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNombreInfBasica.Text) || string.IsNullOrEmpty(DateFechNacInfoBasica.Text) || string.IsNullOrEmpty(txtNombreInfBasica.Text) || (string.IsNullOrEmpty(cbDeptos.Text)) ||
                   (string.IsNullOrEmpty(cbMunic.Text)) || (string.IsNullOrEmpty(cb_profesionesIB.Text)) || (string.IsNullOrEmpty(cbSitLab.Text)) || (string.IsNullOrEmpty(txtTeNocelularInfBasica.Text)) ||
                   (string.IsNullOrEmpty(txtCorreoInfBasica.Text)) || (string.IsNullOrEmpty(txtNoduiInfBasica.Text)) || (string.IsNullOrEmpty(txtNnitInfBasica.Text))
                   ))
            {
                InfoBasicaE _InfoBasicaE = new InfoBasicaE();
                DateTime edad = DateFechNacInfoBasica.SelectedDate.Value;
                _InfoBasicaE.id_candidato = int.Parse(idCandidato);
                _InfoBasicaE.nombre = txtNombreInfBasica.Text.ToUpper();
                _InfoBasicaE.nacionalidad = txtNacionalidadInfBasica.Text.ToUpper();
                _InfoBasicaE.telefono_celular = txtTeNocelularInfBasica.Text.ToUpper();
                _InfoBasicaE.telefono_fijo = txtTelefonoCasaInfBasica.Text.ToUpper();
                //_InfoBasicaE.profesiones = cb_profesionesIB.Text.ToUpper();
                _InfoBasicaE.id_profesiones = Convert.ToInt32(cb_profesionesIB.SelectedValue);
                _InfoBasicaE.correo = txtCorreoInfBasica.Text.ToUpper();
                _InfoBasicaE.fecha_nacimiento = DateFechNacInfoBasica.SelectedDate.Value;
                _InfoBasicaE.direccion = txtLugarResidenciaInfBasica.Text.ToUpper();

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
                returinfobasica = _InfobasicaBL.ActualizarInfBasica(_InfoBasicaE,_InfoBasicaE.id_candidato, ref oerro);
                if (returinfobasica <= 0)
                {
                    MessageBox.Show("Ocurrio un error y no se pudo actualizar al candidato", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("El candidato "+_InfoBasicaE.nombre+ " fue actualizado", "Exito", MessageBoxButton.OK, MessageBoxImage.None);
            }
            else
            {
                MessageBox.Show("Asegurese de que los campos obligatorios no esten vacíos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        



       
      
       
    }
}
