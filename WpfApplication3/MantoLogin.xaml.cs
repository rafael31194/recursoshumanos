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
using MahApps.Metro.Controls;


namespace WpfApplication3
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_nuevo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser ();
             _nu.InitializeComponent();
             this.Close();
             _nu.ShowDialog();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Busqueda _bw = new Busqueda();
            _bw.InitializeComponent();
            this.Close();
            _bw.ShowDialog();
        }

        private void lab_menuCreacionPerf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow _mw = new MainWindow();
            _mw.InitializeComponent();
            this.Close();
            _mw.ShowDialog();
        }

       

        private void btn_nuevoUsuario_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser();
            _nu.InitializeComponent();
            this.Close();
            _nu.ShowDialog();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NewUser _nu = new NewUser();
            _nu.InitializeComponent();
            this.Close();
            _nu.ShowDialog();
        }

       
      }
    }
