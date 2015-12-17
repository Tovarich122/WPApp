using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.IO;
using System.Xml.Serialization;
using IPAS_App.Model;
using System.Linq.Expressions;

namespace IPAS_App.Views
{
    public partial class MarcoN_2 : PhoneApplicationPage
    {
        List<Estado> listaEstados;
        Estado p;
        public MarcoN_2()
        {
            InitializeComponent();
            popup.Visibility = Visibility.Collapsed;
            listaEstados = obtenerLista().Estados.ToList();
        }
        public StateCollection obtenerLista()
        {
            using (TextReader reader = new StreamReader("Model/states.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StateCollection));
                return (StateCollection)serializer.Deserialize(reader);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MarcoN_main.xaml", UriKind.RelativeOrAbsolute));
        }
        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://ipasmexico.org", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void tap1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            System.Windows.Shapes.Path a = (System.Windows.Shapes.Path)sender;
            this.scroll_1.ScrollToVerticalOffset(0);
            
            p = listaEstados.Find(k => k.n_boton == a.Name);
            if (p.n_boton == "e_df")
            {
                texto_descripcion.Text = "Causas Consideradas en el Codigo Penal de la Entidad Federativa:";
            }
            else
            {
                texto_descripcion.Text = "Causas Consideradas en el Codigo Penal del Estado:";
            }
            popup.Visibility = Visibility.Visible;
            mapa_completo.Visibility = Visibility.Collapsed;
            n_estado.Text = p.name;
            text_content.Text = p.content;
        }

        private void close_popup(object sender, System.Windows.Input.GestureEventArgs e)
        {
            popup.Visibility = Visibility.Collapsed;
            mapa_completo.Visibility = Visibility.Visible;
            
        }

    }
}