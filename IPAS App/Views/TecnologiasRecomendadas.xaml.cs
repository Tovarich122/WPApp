using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IPAS
{
    public partial class MetodosAnticonceptivos : PhoneApplicationPage
    {
        public MetodosAnticonceptivos()
        {
            InitializeComponent();
        }

        private void Panorama_Loaded(object sender, RoutedEventArgs e)
        {
            // Inicio de codigo de la AppBar //
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.IsMenuEnabled = false;

            //ApplicationBarIconButton bAbout = new ApplicationBarIconButton();
            ApplicationBarIconButton bInicio = new ApplicationBarIconButton();

            //bAbout.IconUri = new Uri("/Images/iconos/appbar.question.png", UriKind.Relative);
            //bAbout.Text = "About";
            bInicio.IconUri = new Uri("/Assets/iconos/appbar.home.png", UriKind.Relative);
            bInicio.Text = "Inicio";

            ApplicationBar.Buttons.Add(bInicio);
           // ApplicationBar.Buttons.Add(bAbout);

            bInicio.Click += new EventHandler(GoToHome);
            //bAbout.Click += new EventHandler(GoToAbout);
            // Fin del codigo de la AppBar //
        }

        private void GoToHome(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}