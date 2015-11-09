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

namespace IPAS_App.Views
{
    public partial class MarcoN_2 : PhoneApplicationPage
    {
        public MarcoN_2()
        {
            InitializeComponent();
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

    }
}