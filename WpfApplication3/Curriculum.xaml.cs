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
using Microsoft.Reporting.WinForms;
using MahApps.Metro.Controls;
using HelpDesk.RecursosHumanos.BEL;
using System.Collections;
using WpfApplication3.Utilerias;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para Curriculum.xaml
    /// </summary>
    public partial class Curriculum : MetroWindow
    {
        static Imagenes _Imagen = new Imagenes();
        ReportViewer reportControl;
        string oerro = "";
        int idCandidato;
        public Curriculum(int id)
        {
            InitializeComponent();
            idCandidato = id;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            DataTable dtAcademicos = datosAcademicos(idCandidato);
            DataTable dtInfoB = datosInfoBasica(idCandidato);
            DataTable dtExpe = datosExperiencia(idCandidato);
            DataTable dtHabil = datosHabilidades(idCandidato);
            DataTable dtCerti = datosCertificaciones(idCandidato);
            DataTable dtRefe = datosRefe(idCandidato);

            ReportDataSource dsInfoAcade = new ReportDataSource("DataSetCurriculum", dtAcademicos);
            ReportDataSource dsExpeLab = new ReportDataSource("DataSetExpeLab", dtExpe);
            ReportDataSource dsInfoBasic = new ReportDataSource("DataSetInfoBasic", dtInfoB);
            ReportDataSource dsHabi = new ReportDataSource("DataSetHabili", dtHabil);
            ReportDataSource dsCerti = new ReportDataSource("DataSetCertifi", dtCerti);
            ReportDataSource dsRefe = new ReportDataSource("DataSetRefe", dtRefe);
            ReportViewerCurriculum.LocalReport.DataSources.Add(dsInfoAcade);
            ReportViewerCurriculum.LocalReport.DataSources.Add(dsExpeLab);
            ReportViewerCurriculum.LocalReport.DataSources.Add(dsInfoBasic);
            ReportViewerCurriculum.LocalReport.DataSources.Add(dsHabi);
            ReportViewerCurriculum.LocalReport.DataSources.Add(dsCerti);
            ReportViewerCurriculum.LocalReport.DataSources.Add(dsRefe);
            ReportViewerCurriculum.LocalReport.EnableExternalImages = true;
           
            ReportViewerCurriculum.LocalReport.ReportEmbeddedResource = "WpfApplication3.ReportCurriculum.rdlc";

          

            ReportViewerCurriculum.RefreshReport();
        }

        private DataTable datosRefe(int idCandidato)
        {
            ReferenciasBLL refe = new ReferenciasBLL();
            return refe.selectReferencia(idCandidato, ref oerro);
        }

        private DataTable datosCertificaciones(int idCandidato)
        {
            CertificacionesBLL certi = new CertificacionesBLL();
            return certi.selectCertifi(idCandidato, ref oerro);
        }

        private DataTable datosHabilidades(int idCandidato)
        {
            HabilidadCandidatoBLL habi = new HabilidadCandidatoBLL();
            return habi.selectHabili(idCandidato, ref oerro);
        }
        
        public DataTable datosAcademicos(int id)
        {
            
            InformacionAcademicaBLL info = new InformacionAcademicaBLL();


            try { return info.selectInfoAca(id, ref oerro); }
            catch { return null; }          
        }

        public DataTable datosExperiencia(int id)
        {
            ExperienciaLaboralBLL expe = new ExperienciaLaboralBLL();

            try { return expe.selectExpeLab(id, ref  oerro); }
            catch { return null; }           
            
        }

        public DataTable datosInfoBasica(int id) 
        {

            InfoBasicaBLL infoBa = new InfoBasicaBLL();
            return infoBa.selectInfBasic(id, ref oerro);
        }       

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Busqueda bus = new Busqueda();
            bus.InitializeComponent();
            bus.Show();
            this.Close();
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void CORREO_Click(object sender, RoutedEventArgs e)
       {
            NuevoCorreo nuevoEmail = new NuevoCorreo(this);
            nuevoEmail.Show();
            this.Close();
        }



      
    }
}
