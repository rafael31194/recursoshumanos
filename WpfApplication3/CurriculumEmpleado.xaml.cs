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

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para CurriculumEmpleado.xaml
    /// </summary>
    public partial class CurriculumEmpleado :  MetroWindow
    {
        string oerro = "";
        int idCandidato;
        private int idEmpleado;
        public CurriculumEmpleado(int id)
        {
            InitializeComponent();
            idCandidato = id;
        }

        public CurriculumEmpleado(int p1, int p2)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.idCandidato = p1;
            this.idEmpleado = p2;
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dtAcademicos = datosAcademicos(idCandidato);
            DataTable dtInfoB = datosInfoBasica(idCandidato);
            DataTable dtExpe = datosExperiencia(idCandidato);
            DataTable dtHabil = datosHabilidades(idCandidato);
            DataTable dtCerti = datosCertificaciones(idCandidato);
            DataTable dtRefe = datosRefe(idCandidato);
            DataTable dtProyect = datosProyectos(idEmpleado);


            ReportDataSource dsInfoAcade = new ReportDataSource("DataSetCurriculum", dtAcademicos);
            ReportDataSource dsExpeLab = new ReportDataSource("DataSetExpeLab", dtExpe);
            ReportDataSource dsInfoBasic = new ReportDataSource("DataSetInfoBasic", dtInfoB);
            ReportDataSource dsHabi = new ReportDataSource("DataSetHabili", dtHabil);
            ReportDataSource dsCerti = new ReportDataSource("DataSetCertifi", dtCerti);
            ReportDataSource dsRefe = new ReportDataSource("DataSetRefe", dtRefe);
            ReportDataSource dsProyectos = new ReportDataSource("DataSetProyectos", dtProyect);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsInfoAcade);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsExpeLab);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsInfoBasic);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsHabi);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsCerti);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsRefe);
            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsProyectos);


            ReportViewerCurriculumEmp.LocalReport.ReportEmbeddedResource = "WpfApplication3.ReporteEmpleado.rdlc";



            ReportViewerCurriculumEmp.RefreshReport();
        }



        public DataTable datosProyectos(int id)
        {

            ProyectoBLL proyect = new ProyectoBLL();
            DataTable dt = proyect.selectProyectosDataTable(id, ref oerro);

            return dt;

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
         
        }

        private void WindowsFormsHost_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

      
    }
}
