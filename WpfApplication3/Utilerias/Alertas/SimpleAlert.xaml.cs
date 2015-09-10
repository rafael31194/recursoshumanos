using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesktopAlert;
using System.ComponentModel;

namespace HelpDesk.RecursosHumanos.Presentacion.Utilerias.Alertas
{
    /// <summary>
    /// Interaction logic for SimpleAlert.xaml
    /// </summary>
    public partial class SimpleAlert : DesktopAlertBase
    {
        public static DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(SimpleAlert));
        public static DependencyProperty NamePeopleProperty = DependencyProperty.Register("NamePeople", typeof(string), typeof(SimpleAlert));
        public static DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(string), typeof(SimpleAlert));

        [Bindable(true)]
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        [Bindable(true)]
        public string NamePeople
        {
            get { return (string)GetValue(NamePeopleProperty); }
            set { SetValue(NamePeopleProperty, value); }
        }
        [Bindable(true)]
        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public SimpleAlert()
        {
            InitializeComponent();
        }
    }
}
