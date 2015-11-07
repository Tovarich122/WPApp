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
    public partial class Disco_Criterios : PhoneApplicationPage
    {
        public Disco_Criterios()
        {
            InitializeComponent();

            WebBrowserControl.IsScriptEnabled = true;
            WebBrowserControl.Source = new Uri("http://fmmx.net/giro", UriKind.Absolute);
        }

        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://ipasmexico.org", UriKind.Absolute);
            webBrowserTask.Show();
        }
    }
}