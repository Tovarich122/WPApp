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

namespace IPAS_App
{
    public partial class Metodos_Recomendados : PhoneApplicationPage
    {
        public Metodos_Recomendados()
        {
            InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://ipasmexico.org", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("/Tec_Recomendadas/Principal_Tec_Recomendadas.xaml", UriKind.RelativeOrAbsolute));
        }

        private void HyperlinkButton_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
			WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.who.int/reproductivehealth/publications/unsafe_abortion/abortion-task-shifting/en/", UriKind.Absolute);
            webBrowserTask.Show();
        }
		
		private void HyperlinkButton_Click3(object sender, System.Windows.RoutedEventArgs e)
        {
			WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://ipasmexico.org/act-clinicas.html", UriKind.Absolute);
            webBrowserTask.Show();
        }
	
    }
}