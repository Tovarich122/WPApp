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
    public partial class Estigma_main : PhoneApplicationPage
    {
        public Estigma_main()
        {
            InitializeComponent();
        }

        private void ShowInBrowser(string url)
        {
            Microsoft.Phone.Tasks.WebBrowserTask wbt = new Microsoft.Phone.Tasks.WebBrowserTask();
            wbt.Uri = new Uri(url);
            wbt.Show();
        }
        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://ipasmexico.org", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_1.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            ShowInBrowser("https://www.youtube.com/watch?v=smYW7l-7SUI");
        }
    }
}