using MahApps.Metro.Controls;
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
using WpfApplication3.Utilerias;

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para NuevoCorreo.xaml
    /// </summary>
    public partial class NuevoCorreo : MetroWindow
    {
        int opcion;
        CurriculumEmpleado ventanaCurriculum;
        public NuevoCorreo(CurriculumEmpleado ventanaCurriculum)
        {
            opcion = 1;
            this.ventanaCurriculum = ventanaCurriculum;
            InitializeComponent();
        }

        Curriculum ventanaCurruculumCandidatos;
        public NuevoCorreo(Curriculum ventanaCurruculumCandidatos)
        {
            opcion = 2;
            this.ventanaCurruculumCandidatos = ventanaCurruculumCandidatos;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sendEmail enviarCorreo = new sendEmail();
            string error = "";

            if (opcion == 1)
            {

                bool result = enviarCorreo.EnviarDatosCorreo(txt_destinatario.Text, txt_subject.Text, txt_message.Text, ventanaCurriculum.ReportViewerCurriculumEmp, ref error);

                if (!result)
                {
                    MessageBox.Show("Ocurrio un error al adjuntar y enviar el correo" + error);
                }
                else
                {
                    MessageBoxResult MsCorreo = MessageBox.Show("EL CURRICULUM DEL EMPLEADO FUE ENVIADO CON EXITO..", "MENSAJE DE CONFIRMACION", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (MsCorreo == MessageBoxResult.OK)
                    {
                        BusquedaEmpleados _menusBusqueda = new BusquedaEmpleados();
                        _menusBusqueda.InitializeComponent();
                        this.Close();
                        _menusBusqueda.Show();
                    }
                }
            }
            else
            {

                bool result = enviarCorreo.EnviarDatosCorreo(txt_destinatario.Text, txt_subject.Text, txt_message.Text, ventanaCurruculumCandidatos.ReportViewerCurriculum, ref error);

                if (!result)
                {
                    MessageBox.Show("Ocurrio un error al adjuntar y enviar el correo" + error);
                }
                else
                {
                    MessageBoxResult MsCorreo = MessageBox.Show("EL CURRICULUM DEL CANDIDATO FUE ENVIADO CON EXITO..", "MENSAJE DE CONFIRMACION", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (MsCorreo == MessageBoxResult.OK)
                    {
                        Busqueda _menusBusqueda = new Busqueda();
                        _menusBusqueda.InitializeComponent();
                        this.Close();
                        _menusBusqueda.Show();
                    }
               }
            }
        }
    }
}
