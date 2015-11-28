using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Controls.Primitives;
using Telerik.Windows.Controls;
using System.Windows.Media;
using System.Text;

namespace IPAS_App
{
    public partial class Quiz_Metodos_Anticonceptivos : PhoneApplicationPage
    {
        public Quiz_Metodos_Anticonceptivos()
        {
            InitializeComponent();
            PopAnswersGrid.Visibility = Visibility.Collapsed;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Popup popup = new Popup();
        //    popup.Height = 300;
        //    popup.Width = 400;
        //    popup.VerticalOffset = 100;
        //    OverlayMenu control = new OverlayMenu();
        //    popup.Child = control;
        //    popup.IsOpen = true;

        //    //control.btnOK.Click += (s, args) =>
        //    //{
        //    //    popup.IsOpen = false;
        //    //};

        //    control.btnCancel.Click += (s, args) =>
        //    {
        //        popup.IsOpen = false;
        //    };

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Main_Metodos_Anticonceptivos.xaml", UriKind.RelativeOrAbsolute));
        }

        private void PopCloseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            blackGrid.Visibility = Visibility.Collapsed;
            whiteGrid.Visibility = Visibility.Collapsed;
            PopAnswersGrid.Visibility = Visibility.Collapsed;
            PopIntro.Visibility = Visibility.Collapsed;
        }

        private void showPopUp()
        {
            PopAnswersGrid.Visibility = Visibility.Visible;
            blackGrid.Visibility = Visibility.Visible;
            whiteGrid.Visibility = Visibility.Visible;
        }

        private void caso1Buttons(object sender, System.Windows.RoutedEventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("- Las pastillas (anticonceptivo oral combinado) es categoría 4.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- Cuando una mujer tiene múltiples factores de riesgo mayores ( edad mayor a 40 años, antecedente de valvulopatía, uso de anticoagulantes), cualquiera de los cuales individualmente aumentaría considerablemente el riesgo de enfermedad cardiovascular, por lo que  el uso de hormonales combinados (pastillas, parches, anillos vaginales o inyectable combinado) puede aumentar el riesgo a un nivel inadmisible.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- No olvidar reforzar sobre el uso de preservativo para la prevención de infecciones de transmisión sexual.");
            sb.AppendLine();
            sb.AppendLine();
            
            AnswersContent.Text = sb.ToString();
            showPopUp();
        }

        private void caso2Buttons(object sender, System.Windows.RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("- El Enantato de Noretisterona es categoría 1 para la condición de edad, paridad, IMC y post aborto . Es seguro y recomendable la administración de EN-NET inmediatamente después de un aborto.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- Al momento no existe contraindicación absoluta, ni relativa para el uso de anticonceptivos de progestina sola  con antecedente de tabaquismo.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- No olvidar reforzar sobre  el uso de preservativo para la prevención de infecciones de transmisión sexual.");
            sb.AppendLine();
            sb.AppendLine();

            AnswersContent.Text = sb.ToString();
            showPopUp();
        }

        private void caso3Buttons(object sender, System.Windows.RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("- Los DIU, de cobre y medicado, son categoría 2 para la condición de edad, paridad y  antecedente de NIC.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- La inserción del DIU de cobre o medicado puede hacerse cuando se tenga la certeza razonable de que no hay embarazo, tan pronto como 7 días después de la ultima  toma de tabletas del régimen combinado.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- La información de opciones sobre los  métodos anticonceptivos  puede conducir a una mayor satisfacción, aceptación y prevalencia del uso de anticonceptivos.");
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("- No olvidar reforzar sobre el uso de preservativo para la prevención de infecciones de transmisión sexual.");
            sb.AppendLine();
            sb.AppendLine();

            AnswersContent.Text = sb.ToString();
            showPopUp();
        }

    }
}