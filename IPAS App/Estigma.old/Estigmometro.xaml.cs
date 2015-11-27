using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IPAS_App
{
    public partial class Estigmometro : PhoneApplicationPage
    {
        private int actual = 0;
        private int seleccion;
        private Quiz estigmometro = new Quiz();

        public Estigmometro()
        {
            InitializeComponent();
            Quiz estigmometro = new Quiz();

            Item_Resultado.Visibility = System.Windows.Visibility.Collapsed;

            // La primera vez que entre la página que se cargue el quiz
            TextBlock_Preguntas.Text = estigmometro.myQuiz[0].question;
            opcionA.Tag = estigmometro.myQuiz[0].answer_a;
            opcionB.Tag = estigmometro.myQuiz[0].answer_b;
            opcionC.Tag = estigmometro.myQuiz[0].answer_c;
          
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                seleccion = (int)radioButton.Tag;
            }

        }

        private void Btn_Anterior_Click(object sender, RoutedEventArgs e)
        {

            if (actual == 0)
            {
                // Es la primera pregunta
            }
            else
            {
                //estigmometro.myQuiz[actual-1].selected = seleccion;
                //actual--;
                //seleccion = 0;
                cambioPregunta(actual-1);
                actual--;
            }

            
        }

        private void Btn_Siguiente_Click(object sender, RoutedEventArgs e)
        {
            if (actual == 10)
            {
                Item_Resultado.Visibility = System.Windows.Visibility.Collapsed;
                reiniciarQuiz();
            }

            if (actual == 8)
            {
                Btn_Siguiente.Content = "Finalizar";
            }

            // Revisar si es la ultima pregunta
            if (actual == 9)
            {

                Item_Resultado.Visibility = System.Windows.Visibility.Visible;
                PanoramaView.DefaultItem = PanoramaView.Items[2];

                //Agregar panel
                int score = estigmometro.calcularQuiz();

                if (score >= 27)
                {
                    TextBlock_Resultado.Text = "Rojo";
                }
                else if (score >= 14 && score <= 26)
                {
                    TextBlock_Resultado.Text = "Amarillo";
                }
                else if (score <= 13)
                {
                    TextBlock_Resultado.Text = "Verde";
                }

                Item_Resultado.Visibility = Visibility.Visible;

                Btn_Siguiente.Content = "Reiniciar";
                actual++;
            }

            //Si no es la última pregunta
            if (actual < 9)
            {
                if (seleccion == 0)
                {
                    // Tienes que seleccionar una opcion!
                    return;
                }

                estigmometro.myQuiz[actual].selected = seleccion;
                actual++;
                seleccion = 0;
                cambioPregunta(actual);
            }
        }


        private void reiniciarQuiz()
        {
            cambioPregunta(0);

            foreach (var question in estigmometro.myQuiz)
            {
                question.selected = 0;
            }
            actual = 0;
            seleccion = 0;
        }

        private void cambioPregunta(int myActual)
        {
            TextBlock_Preguntas.Text = estigmometro.myQuiz[myActual].question;
            opcionA.Tag = estigmometro.myQuiz[myActual].answer_a;
            opcionB.Tag = estigmometro.myQuiz[myActual].answer_b;
            opcionC.Tag = estigmometro.myQuiz[myActual].answer_c;
            opcionA.IsChecked = false;
            opcionB.IsChecked = false;
            opcionC.IsChecked = false;
        }



    }
}