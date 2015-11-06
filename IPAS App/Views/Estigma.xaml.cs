using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IPAS_App.Model;
using Telerik.Windows.Controls;
using Microsoft.Phone.Tasks;

namespace IPAS.Views
{
    public partial class Estigma : PhoneApplicationPage
    {
        string[] preguntas_text = new string[10];
        string[] rads = new string[] { "rad1", "rad2", "rad3", "rad4" };
        RadioButton[] r = new RadioButton[3];
        List<Pregunta> preguntas = new List<Pregunta>();
        Pregunta p, p1, p2, p3, p4, p5,p6,p7,p8,p9,p10;
        int i = 0;
        ApplicationBarIconButton bSiguiente, bPrevio, bCancelar, bTerminar;
        public Estigma()
        {
            InitializeComponent();
            c_resultado.Visibility = Visibility.Collapsed;
            n_resultado_1.Visibility = Visibility.Collapsed;
            n_resultado_2.Visibility = Visibility.Collapsed;
            n_resultado_3.Visibility = Visibility.Collapsed;
            n_resultado_x1.Visibility = Visibility.Collapsed;
            n_resultado_x2.Visibility = Visibility.Collapsed;
            RadPlaneProjectionAnimation obj_Animation = new RadPlaneProjectionAnimation();
            obj_Animation.AutoReverse = false;
            obj_Animation.Axes = PerspectiveAnimationAxis.XY;
            obj_Animation.StartAngleY = -450.22;
            obj_Animation.EndAngleY = 0;
            obj_Animation.Direction = PerspectiveAnimationDirection.CounterClockwise;
            obj_Animation.Duration = TimeSpan.FromSeconds(.7);
            obj_Animation.Ended += this.obj_Animation_Ended;

            test_window.Visibility = Visibility.Collapsed;
            ApplicationBar = new ApplicationBar();
            this.bSiguiente = new ApplicationBarIconButton();
            this.bPrevio = new ApplicationBarIconButton();
            this.bCancelar = new ApplicationBarIconButton();
            this.bTerminar = new ApplicationBarIconButton();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.IsMenuEnabled = false;
            bSiguiente.IconUri = new Uri("/Assets/iconos/appbar.arrow.right.png", UriKind.Relative);
            bSiguiente.Text = "Siguiente";
            bPrevio.IconUri = new Uri("/Assets/iconos/appbar.arrow.left.png", UriKind.Relative);
            bPrevio.Text = "Anterior";
            bCancelar.IconUri = new Uri("/Assets/iconos/appbar.close.png", UriKind.Relative);
            bCancelar.Text = "Cancelar";
            bTerminar.IconUri = new Uri("/Assets/iconos/appbar.check.png", UriKind.Relative);
            bTerminar.Text = "Aceptar";
            ApplicationBar.Buttons.Add(bCancelar);
            ApplicationBar.Buttons.Add(bSiguiente);


            bCancelar.Click += new EventHandler(cancel_test);
            bPrevio.Click += new EventHandler(GoToPrev);
            bSiguiente.Click += new EventHandler(GoToIntermedio);
            bTerminar.Click += new EventHandler(GoToNextEstigma);
            ApplicationBar.IsVisible = false;
            r[0] = r1; r[1] = r2; r[2] = r3;
            preguntas_text[0] = "Las mujeres que quieren tener hijos/as son más felices que las que no quieren tenerlos/as";
            preguntas_text[1] = "Una mujer que decide abortar es irresponsable.";
            preguntas_text[2] = "Una mujer que ha tenido un aborto podría influenciar a otras mujeres a tener abortos";
            preguntas_text[3] = "Si tuviera la opción, preferiría no atender a una mujer que ha tenido más de un aborto";
            preguntas_text[4] = "Un prestador de servicios de salud que atiende a una mujer que ha tenido un aborto debe avisar a su pareja (novio o esposo) y/o a sus padres.";
            preguntas_text[5] = "Si una mujer me preguntara sobre opciones frente a un embarazo no planeado, yo le recomendaría que continuara con el embarazo.";
            preguntas_text[6] = "Las mujeres que abortan siempre tienen alguna consecuencia negativa en su salud física";
            preguntas_text[7] = "Si una mujer me solicitara apoyo para interrumpir su embarazo, yo trataría de ayudarla para que lo hiciera de manera segura.";
            preguntas_text[8] = "Un prestador de servicios de salud debe denunciar a una mujer si sospecha que tuvo un aborto inducido.";
            preguntas_text[9] = "Si conociera a un/a colega que realizara abortos, no me gustaría que me relacionaran con el/ella.";


            p1 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p1.correcta = p1.res3;
            p1.res4 = "Decidir ser madre debe ser una elección y no una obligación por el simple hecho de ser mujer. Los hijos/as tienen el derecho a ser deseados.";
            this.i++;
            p2 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p2.correcta = p2.res3;
            p2.res4 = "Una idea frecuente en nuestra sociedad es considerar que las mujeres se embarazaron sin planearlo porque no utilizaron anticonceptivos, sin embargo, existen un sinnúmero de razones como la falla del anticonceptivo, haber sido presionada por la pareja para no usar algún método, por violencia sexual, esta última con mayor frecuencia en mujeres menores de 15 años.";
            this.i++;
            p3 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p3.correcta = p3.res3;
            p3.res4 = " La decisión de abortar no se contagia porque no se trata de una enfermedad, cada mujer tiene la libertad de decidir lo mejor para ella y como sociedad debemos respetar las decisiones que las mujeres toman sobre sus cuerpos y sus vidas";
            this.i++;
            p4 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p4.correcta = p4.res3;
            p4.res4 = "Cuando un prestador de servicios de salud deja de atender o referir a un servicio seguro a una mujer en situación de aborto, ella podría buscar opciones inseguras y retrasar la atención poniendo en riesgo su salud.";
            this.i++;
            p5 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p5.correcta = p5.res3;
            p5.res4 = " El prestador de servicio de salud debe proteger la confidencialidad de las mujeres para asegurar que puedan tomar decisiones libres e informadas, por lo que no se debe notificar a ninguna persona sin previa autorización de la mujer.";
            this.i++;
            p6 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p6.correcta = p6.res3;
            p6.res4 = "Es importante que la información que le demos a las mujeres sea lo más objetiva posible y mostrándole todas las opciones posibles para tomar una decisión informada. Si sólo le damos una opción estaremos interfiriendo en su libertad de elegir.";
            this.i++;
            p7 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p7.correcta = p7.res3;
            p7.res4 = " El aborto es uno de los procedimientos médicos de menor riesgo. En países donde las mujeres tienen acceso a servicios de aborto seguros la probabilidad de muerte no es mayor a 1 de cada 100,000 procedimientos.";
            this.i++;
            p8 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p8.correcta = p8.res1;
            p8.res4 = " A las mujeres que buscan interrumpir un embarazo se les dificulta llegar a los servicios de salud para pedir ayuda porque piensan que las van a tratar mal por la decisión que han tomado, es importante aprovechar la llegada de estas mujeres a los servicios para asegurar que reciban un servicio de calidad y no ponerlas en riesgo forzándolas a buscar atención con prestadores de servicios de salud no calificados.";
            this.i++;
            p9 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p9.correcta = p9.res3;
            p9.res4 = " El que un prestador de servicios de salud decida denunciar a una mujer por haber abortado, criminaliza a las mujeres retrasando la atención y poniendo en riesgo su salud.";
            this.i++;
            p10 = new Pregunta(1, this.i, preguntas_text[this.i]);
            p10.correcta = p10.res3;
            p10.res4 = " El no querer que nos relacionen con personal que hace abortos refleja una actitud de rechazo y de devaluación hacia los colegas que lo realizan, lo cual minimiza su labor afectando su salud emocional. Los prestadores de servicios de salud deben evitar ser una barrera para la salud emocional de sus colegas y facilitar que ellos/as puedan dar una atención de calidad a las mujeres en situación de aborto.";
            this.i = 0;
            preguntas.Add(p1); preguntas.Add(p2); preguntas.Add(p3);
            preguntas.Add(p4); preguntas.Add(p5); preguntas.Add(p6);
            preguntas.Add(p7); preguntas.Add(p8); preguntas.Add(p9); preguntas.Add(p10);

            RadAnimationManager.Play(LayoutRoot, obj_Animation);
        }
        private void HyperlinkButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://ipasmexico.org", UriKind.Absolute);
            webBrowserTask.Show();
        }
    private void GoToNextEstigma(object sender, EventArgs e)
        {

            if (this.i >= 10) // Resultado Final.
            {
                //Regresar a la normalidad
                cancel_test(sender, e);
            }
            else //Cualquiera
            {
                c_resultado.Visibility = Visibility.Collapsed;
                n_resultado_x1.Visibility = Visibility.Collapsed;
                n_resultado_x2.Visibility = Visibility.Collapsed;
                //Modificar Appbar
                ApplicationBar.Buttons.RemoveAt(0);
                ApplicationBar.Buttons.Insert(0, bPrevio);
                ApplicationBar.Buttons.Insert(1, bSiguiente);
                int v = ApplicationBar.Buttons.Count;
                //Mostrar testWindow.
                img_holder_MarcoNtest.Visibility = Visibility.Collapsed;
                test_window.Visibility = Visibility.Visible;
            }
        }
        private void titulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Panorama)sender).SelectedIndex)
            {
                case 0:
                    ApplicationBar.IsVisible = false;
                    break;

                case 1:
                    ApplicationBar.IsVisible = false;
                    break;

                case 2:
                    if (img_holder_MarcoNtest.Visibility == Visibility.Collapsed)
                    {
                        ApplicationBar.IsVisible = true;
                    }
                    else
                    {
                        ApplicationBar.IsVisible = false;
                    }
                    
                    break;

            }
        }
        
        private void GoToIntermedio(object sender, EventArgs e)
        {
            
            //Show before Next
            if (r2.IsChecked != true && (r1.IsChecked== true || r3.IsChecked == true) )
            {
                showMessageBox(this.i);
            }

            if (this.i >= 9) //fin del cuestionario.
            {
                test_window.Visibility = Visibility.Collapsed;
                this.i++;
                int c = 1;
                //calcular Score.
               
                foreach (var item in preguntas)
                {
                    if (item.its_correct == true)
                    {
                        //sumar correctas
                        c++;
                    }
                    item.rad_checked = -1;
                }
                foreach (var item in r)
                {
                    item.IsChecked = false;
                }
                if (c < 5) { t_resultado.Text = ("Reflexiona sobre las acciones y respuestas que podrían estigmatizar a las mujeres afectando la calidad de la atención brindada y poniendo en riesgo su salud."); n_resultado_2.Visibility = Visibility.Visible; }//Malo
                else
                {
                    if (c >= 9) { t_resultado.Text = ("Continúa siendo un prestador de servicios de salud libre de estigma, atendiendo a las mujeres con calidad y protegiendo su salud."); n_resultado_1.Visibility = Visibility.Visible; } //Perfecto
                    else { t_resultado.Text = "Realizas tu trabajo con compromiso, sin embargo hay algunas acciones y respuestas que puedes seguir mejorando para incrementar la calidad de la atención y la salud de las mujeres."; n_resultado_3.Visibility = Visibility.Visible; } //Regular
                }
                c = 1;
                ApplicationBar.Buttons.RemoveAt(0);
                int v = ApplicationBar.Buttons.Count;
                if (v >= 1)
                {
                    modifyAppbar(bTerminar);
                }
                else
                {
                    ApplicationBar.Buttons.Insert(0, bTerminar);
                }
                c_resultado.Visibility = Visibility.Visible;
                n_resultado_x1.Visibility = Visibility.Collapsed;
                n_resultado_x2.Visibility = Visibility.Collapsed;
            }
            else
            {
                //save user answer.
                saveAnswer(this.i) ;
                this.i++;
                    if (this.i == 1) //segunda pregunta
                    {
                        int v = ApplicationBar.Buttons.Count;
                        if (v == 1)
                        {

                        }
                        else
                        {
                            modifyAppbar(bPrevio);
                        }
                        ActualizarRads(this.i);
                    }
                    else
                    {
                        ActualizarRads(this.i);
                    }
             }
            
        }

        private void GoToPrev(object sender, EventArgs e)
        {

                if (this.i == 1) //regresa al principio.
                {
                    saveAnswer(this.i);
                    this.i--;
                    modifyAppbar(bCancelar);
                    ActualizarRads(this.i);
                }
                else
                { saveAnswer(this.i); this.i--; ActualizarRads(this.i); }
        }

        private void cancel_test(object sender, EventArgs e)
        {
            ApplicationBar.IsVisible = false;
            //ResetAppBar.
            ApplicationBar.Buttons.RemoveAt(0);
            ApplicationBar.Buttons.Insert(0, bCancelar);
            if (ApplicationBar.Buttons.Count != 2)
            {
                ApplicationBar.Buttons.Insert(1, bSiguiente);
            }

            img_holder_MarcoNtest.Visibility = Visibility.Visible;
            test_window.Visibility = Visibility.Collapsed;
            c_resultado.Visibility = Visibility.Collapsed;
            n_resultado_3.Visibility = Visibility.Collapsed;
            n_resultado_2.Visibility = Visibility.Collapsed;
            n_resultado_1.Visibility = Visibility.Collapsed;
            n_resultado_x1.Visibility = Visibility.Collapsed;
            n_resultado_x2.Visibility = Visibility.Collapsed;
            this.i = 0;
            foreach (var item in preguntas)
            {
                item.rad_checked = -1;
            }
            foreach (var item in r)
            {
                item.IsChecked = false;
            }
            
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            img_holder_MarcoNtest.Visibility = Visibility.Collapsed;
            test_window.Visibility = Visibility.Visible;
            ApplicationBar.IsVisible = true;
            //Reset Appbar.
            ApplicationBar.Buttons.RemoveAt(0);
            ApplicationBar.Buttons.Insert(0, bCancelar);
            if (ApplicationBar.Buttons.Count != 2)
            {
                ApplicationBar.Buttons.Insert(1, bSiguiente);
            }
            
            
            ActualizarRads(this.i);
           
        }

        private void ActualizarRads(int o)
        {
            p = preguntas.Find(k => k.id == o);
            pregunta_text.Text = p.text;
            r1.Content = p.res1;
            r2.Content = p.res2;
            r3.Content = p.res3;
            
            if (p.rad_checked != -1)
            {
                r[p.rad_checked].IsChecked = true;
            }
            pregunta_textblock.Text = "Pregunta "+(this.i + 1).ToString() + " de 10";
        }

        private void saveAnswer(int o)
        {
            p = preguntas.Find(k => k.id == o);
            for (int y = 0; y <= 2; y++)
            {
                if (r[y].IsChecked == true)
                {
                    p.rad_checked = y;
                    if (r[y].Content.ToString() == p.correcta)
                    {
                        p.its_correct = true;
                    }
                    r[y].IsChecked = false;
                    break;
                }
            }

        }
        private void showMessageBox(int o)
        {
            //ocultar TestWindow
            test_window.Visibility = Visibility.Collapsed;
            //Modificar Appbar
            ApplicationBar.Buttons.RemoveAt(0); ApplicationBar.Buttons.RemoveAt(0);
            ApplicationBar.Buttons.Insert(0, bTerminar);
            int v = ApplicationBar.Buttons.Count;
            //Mostrar c_resultado
            c_resultado.Visibility = Visibility.Visible;
            //Actualizar Valores
            saveAnswer(o);
            p = preguntas.Find(k => k.id == o);
            if (p.its_correct) //Semaforo Verde
            {
                n_resultado_x1.Visibility = Visibility.Visible;
                t_resultado.Text = "Adelante, Estas en lo correcto.";
            }
            else // semaforo rojo.
            {
                n_resultado_x2.Visibility = Visibility.Visible;
                t_resultado.Text = p.res4;
            }

        }
        private void modifyAppbar(ApplicationBarIconButton a)
        {
            ApplicationBar.Buttons.RemoveAt(0);
            ApplicationBar.Buttons.Insert(0, a);
            int v = ApplicationBar.Buttons.Count;
        }
        private void obj_Animation_Ended(object sender, AnimationEndedEventArgs e)
        {        
        }


    }
}