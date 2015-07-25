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

        public void setearCampos(DataRow datos)
        {
            txtNombreInfBasica.Text = datos.ItemArray[1].ToString();
            txtNacionalidadInfBasica.Text = datos.ItemArray[2].ToString();
            if (datos.ItemArray[3].ToString() == "1")
            {
                rbsexoM.IsChecked = true;
            }
            else {
                rbsexoF.IsChecked = false;
            }

            txtTeNocelularInfBasica.Text = datos.ItemArray[3].ToString();
            txtTelefonoCasaInfBasica.Text = datos.ItemArray[4].ToString();

            

        }
    }
}
