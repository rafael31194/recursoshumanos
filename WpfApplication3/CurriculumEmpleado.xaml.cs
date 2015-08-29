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
        public CurriculumEmpleado()
        {
            InitializeComponent();
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            ReportDataSource dsempleado = new ReportDataSource("DataSetCurriculum");

            ReportViewerCurriculumEmp.LocalReport.DataSources.Add(dsempleado);

            ReportViewerCurriculumEmp.LocalReport.ReportEmbeddedResource = "WpfApplication3.ReporteEmpleado.rdlc";
            
            ReportViewerCurriculumEmp.RefreshReport();

        }
           
    }
}
