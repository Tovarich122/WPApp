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
    public partial class Criterios_Medicos : PhoneApplicationPage
    {
        public Criterios_Medicos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Main_Metodos_Anticonceptivos.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void PopCloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            blackGrid.Visibility = Visibility.Collapsed;
            whiteGrid.Visibility = Visibility.Collapsed;
            PopScrollIntro.Visibility = Visibility.Collapsed;
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopTitulo.Text = "Categoría 1";
            PopSubtitulo.Text = "Una condición para la que no hay restricción para el uso del método.";
            showPopUp();
        }
		
		 private void button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopTitulo.Text = "Categoría 2";
            PopSubtitulo.Text = "Una condición donde las ventajas del uso del método generalmente superan los riesgos teóricos o probados.";
            showPopUp();
        }
		
		 private void button3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopTitulo.Text = "Categoría 3";
            PopSubtitulo.Text = "Una condición donde los riesgos teóricos o provados generalmente superan las ventajas del uso del método.";
            showPopUp();
        }
		
		 private void button4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PopTitulo.Text = "Categoría 4";
            PopSubtitulo.Text = "Una condición que representa un reisgo de salud inadmisible si se utiliza el método anticonceptivo.";
            showPopUp();
        }
		
		private void showPopUp() 
		{
			blackGrid.Visibility = Visibility.Visible;
            whiteGrid.Visibility = Visibility.Visible;
		}

        private void HyperlinkButton_Click2(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://apps.who.int/iris/bitstream/10665/44710/1/9789243563886_spa.pdf", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void HyperlinkButton_Click3(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.who.int/reproductivehealth/publications/family_planning/Ex-Summ-MEC-5/en/", UriKind.Absolute);
            webBrowserTask.Show();
        }
        
    }
}