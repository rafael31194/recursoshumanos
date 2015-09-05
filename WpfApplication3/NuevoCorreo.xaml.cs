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

namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para NuevoCorreo.xaml
    /// </summary>
    public partial class NuevoCorreo : MetroWindow
    {

        CurriculumEmpleado ventanaCurriculum;
        public NuevoCorreo(CurriculumEmpleado ventanaCurriculum)
        {
            this.ventanaCurriculum = ventanaCurriculum;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ventanaCurriculum.EnviarDatosCorreo(txt_destinatario.Text, txt_subject.Text, txt_message.Text);
            this.Close();
        }
    }
}
