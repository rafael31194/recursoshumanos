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

        string idProfesion;
        string idMunicipio;
        string idSituProfe;
        string idGenero;
        string idStatusAcad,idTipoEduca,idTipoRef,idHabiTec,idNivel,idHabiApli;

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
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Hidden;
                    btn_ActualizarHabilidades.Visibility = Visibility.Hidden;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Hidden;
                    btn_ActualizarReferencias.Visibility = Visibility.Hidden;
                }
                else if (tcPrincipalModificar.SelectedIndex == 1)
                {
                    btn_ActualizarInfoBasica.Visibility = Visibility.Hidden;
                    btn_ActualizarInfoAcademica.Visibility = Visibility.Visible;
                    btn_ActualizarInfoLaboral.Visibility = Visibility.Hidden;
                    btn_ActualizarHabilidades.Visibility = Visibility.Hidden;
                    btn_ActualizarCertificaciones.Visibility = Visibility.Hidden;
                    btn_ActualizarReferencias.Visibility = Visibility.Hidden;
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

        public void setearCampos(DataRow datos, List<DataRow> candiInfoAca, List<DataRow> candiInfoExpe, List<DataRow> candiHabili, List<DataRow> candiCeriti, List<DataRow> candiRefe)
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
            DataTable tableInfoAcad = new DataTable();


//            tableInfoAcad.Columns.Add("IDTipoEduacion", typeof(Int32));
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




                tableInfoAcad.Rows.Add(tipoEduca, dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), statusName, Convert.ToInt32(dr.ItemArray[4].ToString()));

                
            }

            DataGrid_InfAcademica.ItemsSource = tableInfoAcad.DefaultView;

            
            //Seteando Info experiencia laboral Tab*******************************

            DataTable tablaExperiencia = new DataTable();

            tablaExperiencia.Columns.Add("Nombre de la empresa", typeof(string));
            tablaExperiencia.Columns.Add("Cargo Desempeñado", typeof(string));
            tablaExperiencia.Columns.Add("Descripcion del puesto", typeof(string));
            tablaExperiencia.Columns.Add("Fecha Inicio", typeof(string));
            tablaExperiencia.Columns.Add("Fecha Fin", typeof(string));
            foreach (DataRow dr in candiInfoExpe)
            {
                tablaExperiencia.Rows.Add(dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), dr.ItemArray[5].ToString());
            }

            DataGrid_Inf_Laboral.ItemsSource = tablaExperiencia.DefaultView;
            //Seteando Info Habilidades Tab*******************************

            DataTable tablaReference = new DataTable();

            tablaReference.Columns.Add("IDTIPOREF", typeof(Int32));
            tablaReference.Columns.Add("TIPO DE REFERENCIA", typeof(string));
            tablaReference.Columns.Add("NOMBRE", typeof(string));
            tablaReference.Columns.Add("TELEFONO", typeof(string));
            tablaReference.Columns.Add("DESCRIPCION", typeof(string));

            string tipoRef = "";

            foreach (DataRow dr in candiRefe)
            {
                if (dr.ItemArray[2].ToString() == "1") tipoRef = "PERSONAL";
                else tipoRef = "LABORAL";

                tablaReference.Rows.Add(dr.ItemArray[0].ToString(), tipoRef, dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString(), dr.ItemArray[5].ToString());
                
            }

            DataGrid_Referencias.ItemsSource = tablaReference.DefaultView;
            //Seteando Info Certificaciones Tab*******************************
            DataTable tablaCerti = new DataTable();

            tablaCerti.Columns.Add("CERTIFICACION", typeof(string));
            tablaCerti.Columns.Add("INSTITUCION DE CERTIFICACION", typeof(string));
            tablaCerti.Columns.Add("AÑO DE FINALIZACION", typeof(Int32));

            foreach (DataRow dr in candiCeriti)
            {
                tablaCerti.Rows.Add(dr.ItemArray[2].ToString(), dr.ItemArray[3].ToString(), dr.ItemArray[4].ToString()); //puede dar error por la columna int y el dato string
            }
            DataGrid_Certificaciones.ItemsSource = tablaCerti.DefaultView;
        }


        public void setearComboBox()
        {

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
    }
}
