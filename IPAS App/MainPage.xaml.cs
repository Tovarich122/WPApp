using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using IPAS_App.Resources;
using Telerik.Windows.Controls;
using System.Windows.Media.Animation;

namespace IPAS
{
    public partial class MainPage : PhoneApplicationPage
    {
        int a = 0;
        int sz = 170;
        int wmarcon = 0; int wtecnologiasr = 0; int wmetodosa = 0; int westigma = 0;
        bool LosingFocus = true;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            shield.Visibility = Visibility.Collapsed;
            grid_marcoN.Height = 0; grid_TecnologiasR.Height = 0; grid_MetodosA.Height = 0; grid_Estigma.Height = 0;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            while (NavigationService.RemoveBackEntry() != null) ;
        }

        private void tile_Tecnologias_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Tec_Recomendadas/Principal_Tec_Recomendadas.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RadSlideHubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MarcoN_main.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RadSlideHubTile_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_main.xaml", UriKind.RelativeOrAbsolute));
        }

        private void RadSlideHubTile_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Main_Metodos_Anticonceptivos.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

            RadMoveAnimation animation = new RadMoveAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;
            Point endPoint = new Point();
            if (a == 0)
            {
                endPoint.X = 321;
                endPoint.Y = 0;
                a = 1;
                CControl.Focus();
                //boton_menu.IsEnabled = false;
            }
            shield.Visibility = Visibility.Visible;
            animation.EndPoint = endPoint;
            animation.Easing = ease;
            RadAnimationManager.Play(CControl, animation);


        }
        private void CControl_LostFocus(object sender, RoutedEventArgs e)
        {
            bool fg = LosingFocus;
            if (LosingFocus == true)
            {
                RadMoveAnimation animation = new RadMoveAnimation();
                EasingFunctionBase ease = new QuadraticEase();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = 0;
                a = 0;
                animation.EndPoint = endPoint;
                animation.Easing = ease;
                shield.Visibility = Visibility.Collapsed;
                //boton_menu.IsEnabled = true;
                RadAnimationManager.Play(CControl, animation);
            }
            else
            {

                LosingFocus = true;
            }
        }
        private void pA(RadMoveAnimation animation, int a)
        {
            if (a == 1) // Tecnologias
            {
                RadAnimationManager.Play(bBarra_TecnologiasR, animation);
                RadAnimationManager.Play(grid_TecnologiasR, animation);
            }
            if (a == 2) //Metodos
            {
                RadAnimationManager.Play(bBarra_MetodosA, animation);
                RadAnimationManager.Play(grid_MetodosA, animation);
            }
            if (a == 3) //Estigma
            {
                RadAnimationManager.Play(bBarra_Estigma, animation);
                RadAnimationManager.Play(grid_Estigma, animation);
            }
        }

        private void bBarra_MarcoN_Click(object sender, RoutedEventArgs e)
        {

            LosingFocus = false;
            RadResizeAnimation resizeAnimation = new RadResizeAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;

            RadMoveAnimation animation2 = new RadMoveAnimation();
            ease.EasingMode = EasingMode.EaseInOut;
            Point endPoint2 = new Point();
            endPoint2.X = 0;
            endPoint2.Y = 2 * sz;
            animation2.EndPoint = endPoint2;
            animation2.Easing = ease;

            RadMoveAnimation animation3 = new RadMoveAnimation();
            ease.EasingMode = EasingMode.EaseInOut;
            Point endPoint3 = new Point();
            endPoint3.X = 0;
            endPoint3.Y = 3 * sz;
            animation3.EndPoint = endPoint3;
            animation3.Easing = ease;
            sz = 140;
            if (wmarcon == 0) //marcoN Cerrado -> abierto.
            {

                resizeAnimation.StartSize = new Size(321, 0);
                Size size = new Size(321, sz);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = sz;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                wmarcon = 1;

                if (wtecnologiasr == 1 && wmetodosa == 1)
                {

                    endPoint.Y = sz;
                    animation.EndPoint = endPoint;
                    pA(animation, 1);

                    endPoint2.Y = 140 + 290;
                    animation2.EndPoint = endPoint2;
                    pA(animation2, 2);

                    endPoint3.Y = 140 + 290 + 220;
                    animation3.EndPoint = endPoint3;
                    pA(animation3, 3);

                }
                else
                {
                    if (wtecnologiasr == 1)
                    {
                        endPoint.Y = 1 * sz;
                        animation.EndPoint = endPoint;
                        pA(animation, 1);

                        endPoint2.Y = sz + 290;
                        animation2.EndPoint = endPoint2;
                        pA(animation2, 2);
                        pA(animation2, 3);

                    }
                    else
                    {
                        if (wmetodosa == 1)
                        {
                            endPoint.Y = 1 * sz;
                            animation.EndPoint = endPoint;
                            pA(animation, 1);

                            endPoint2.Y = 1 * sz;
                            animation2.EndPoint = endPoint2;
                            pA(animation2, 2);

                            endPoint3.Y = 220 + sz;
                            animation3.EndPoint = endPoint3;
                            pA(animation3, 3);
                        }
                        else
                        {
                            endPoint.Y = sz;
                            animation.EndPoint = endPoint;
                            pA(animation, 1); pA(animation, 2); pA(animation, 3);
                        }

                    }
                }

            }
            else //MarcoN Abierto -> cerrado.
            {
                resizeAnimation.StartSize = new Size(321, sz);
                Size size = new Size(321, 0);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = 0;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                wmarcon = 0;

                if (wtecnologiasr == 1 && wmetodosa == 1)
                {
                    endPoint.Y = 0 * sz;
                    animation.EndPoint = endPoint;
                    pA(animation, 1);

                    endPoint2.Y = 290;
                    animation2.EndPoint = endPoint2;
                    pA(animation2, 2);

                    endPoint3.Y = 290 + 220;
                    animation3.EndPoint = endPoint3;
                    pA(animation3, 3);

                }
                else
                {
                    if (wtecnologiasr == 1)
                    {
                        endPoint.Y = 0 * sz;
                        animation.EndPoint = endPoint;
                        pA(animation, 1);

                        endPoint2.Y = 290;
                        animation2.EndPoint = endPoint2;
                        pA(animation2, 2);
                        pA(animation2, 3);
                    }
                    else
                    {
                        if (wmetodosa == 1)
                        {
                            endPoint.Y = 0 * sz;
                            animation.EndPoint = endPoint;
                            pA(animation, 1);

                            endPoint2.Y = 0 * sz;
                            animation2.EndPoint = endPoint2;
                            pA(animation2, 2);

                            endPoint3.Y = 220;
                            animation3.EndPoint = endPoint3;
                            pA(animation3, 3);
                        }
                        else
                        {
                            endPoint.Y = 0;
                            animation.EndPoint = endPoint;
                            pA(animation, 1); pA(animation, 2); pA(animation, 3);
                        }

                    }
                }
            }

            RadAnimationManager.Play(grid_marcoN, resizeAnimation);
        }

        private void bBarra_TecnologiasR_Click(object sender, RoutedEventArgs e)
        {
            LosingFocus = false;
            RadResizeAnimation resizeAnimation = new RadResizeAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;

            RadMoveAnimation animation2 = new RadMoveAnimation();
            ease.EasingMode = EasingMode.EaseInOut;
            Point endPoint2 = new Point();
            endPoint2.X = 0;
            endPoint2.Y = 2 * sz;
            animation2.EndPoint = endPoint2;
            animation2.Easing = ease;

            RadMoveAnimation animation3 = new RadMoveAnimation();
            ease.EasingMode = EasingMode.EaseInOut;
            Point endPoint3 = new Point();
            endPoint3.X = 0;
            endPoint3.Y = 3 * sz;
            animation3.EndPoint = endPoint3;
            animation3.Easing = ease;
            sz = 290;
            if (wtecnologiasr == 0) //tecnologias Cerrado
            {
                resizeAnimation.StartSize = new Size(321, 0);
                Size size = new Size(321, sz);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = sz;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                wtecnologiasr = 1;
                if (wmarcon == 1 && wmetodosa == 1)
                {
                    endPoint2.Y = 140 + sz;
                    animation2.EndPoint = endPoint2;
                    pA(animation2, 2);

                    endPoint.Y = 140 + 220 + sz;
                    animation.EndPoint = endPoint;
                    pA(animation, 3);

                }
                else
                {
                    if (wmetodosa == 1)
                    {
                        endPoint.Y = sz;
                        animation.EndPoint = endPoint;
                        pA(animation, 2);

                        endPoint2.Y = 220 + sz;
                        animation2.EndPoint = endPoint2;
                        pA(animation2, 3);
                    }
                    else
                    {
                        if (wmarcon == 1)
                        {

                            endPoint.Y = sz + 140;
                            animation.EndPoint = endPoint;
                            pA(animation, 2);

                            endPoint2.Y = sz + 140;
                            animation2.EndPoint = endPoint2;
                            pA(animation2, 3);
                        }
                        else
                        {
                            endPoint.Y = sz;
                            animation.EndPoint = endPoint;
                            pA(animation, 2); pA(animation, 3);
                        }

                    }

                }


            }
            else //TecnologiasR Abierto.
            {
                resizeAnimation.StartSize = new Size(321, sz);
                Size size = new Size(321, 0);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = 0;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                wtecnologiasr = 0;

                if (wmarcon == 1 && wmetodosa == 1)
                {
                    endPoint2.Y = 140;
                    animation2.EndPoint = endPoint2;
                    pA(animation2, 2);

                    endPoint.Y = 220 + 140;
                    animation.EndPoint = endPoint;
                    pA(animation, 3);

                }
                else
                {
                    if (wmetodosa == 1)
                    {
                        endPoint.Y = 0 * sz;
                        animation.EndPoint = endPoint;
                        pA(animation, 2);

                        endPoint2.Y = 220;
                        animation2.EndPoint = endPoint2;
                        pA(animation2, 3);
                    }
                    else
                    {
                        if (wmarcon == 1)
                        {

                            endPoint.Y = 140;
                            animation.EndPoint = endPoint;
                            pA(animation, 2);

                            endPoint2.Y = 140;
                            animation2.EndPoint = endPoint2;
                            pA(animation2, 3);
                        }
                        else
                        {
                            endPoint.Y = 0;
                            animation.EndPoint = endPoint;
                            pA(animation, 2); pA(animation, 3);
                        }

                    }

                }
            }

            RadAnimationManager.Play(grid_TecnologiasR, resizeAnimation);
        }

        private void bBarra_MetodosA_Click(object sender, RoutedEventArgs e)
        {
            LosingFocus = false;
            RadResizeAnimation resizeAnimation = new RadResizeAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;
            sz = 220;
            if (wmetodosa == 0) // Metodos Abierto
            {
                resizeAnimation.StartSize = new Size(321, 0);
                Size size = new Size(321, sz);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = sz;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                wmetodosa = 1;
                if (wtecnologiasr == 1 && wmarcon == 1) // Si tecnologias esta abierto sumar a estigma 
                {

                    endPoint.Y = sz + 290 + 140;
                    animation.EndPoint = endPoint;
                    pA(animation, 3);
                }
                else
                {
                    if (wtecnologiasr == 1)
                    {
                        endPoint.Y = 290 + sz;
                        animation.EndPoint = endPoint;
                        pA(animation, 3);
                    }
                    else
                    {
                        if (wmarcon == 1)
                        {
                            endPoint.Y = 140 + sz;
                            animation.EndPoint = endPoint;
                            pA(animation, 3);
                        }
                        else
                        {
                            endPoint.Y = sz;
                            animation.EndPoint = endPoint;
                            pA(animation, 3);
                        }

                    }
                }


            }
            else // Metodos Cerrado
            {
                resizeAnimation.StartSize = new Size(321, sz);
                Size size = new Size(321, 0);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = 0;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                wmetodosa = 0;
                if (wtecnologiasr == 1 && wmarcon == 1)
                {

                    endPoint.Y = (290 + 140);
                    animation.EndPoint = endPoint;
                    pA(animation, 3);
                }
                else
                {
                    if (wtecnologiasr == 1)
                    {
                        endPoint.Y = 290;
                        animation.EndPoint = endPoint;
                        pA(animation, 3);

                    }
                    else
                    {
                        if (wmarcon == 1)
                        {
                            endPoint.Y = 140;
                            animation.EndPoint = endPoint;
                            pA(animation, 3);
                        }
                        else
                        {
                            endPoint.Y = 0;
                            animation.EndPoint = endPoint;
                            pA(animation, 3);
                        }
                    }
                }
            }


            RadAnimationManager.Play(grid_MetodosA, resizeAnimation);
        }

        private void bBarra_Estigma_Click(object sender, RoutedEventArgs e)
        {
            LosingFocus = false;
            RadResizeAnimation resizeAnimation = new RadResizeAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;
            sz = 180;
            if (westigma == 0)
            {
                resizeAnimation.StartSize = new Size(321, 0);
                Size size = new Size(321, sz);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = sz;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                westigma = 1;
            }
            else
            {
                resizeAnimation.StartSize = new Size(321, sz);
                Size size = new Size(321, 0);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                RadMoveAnimation animation = new RadMoveAnimation();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                endPoint.X = 0;
                endPoint.Y = 0;
                animation.EndPoint = endPoint;
                animation.Easing = ease;

                westigma = 0;
            }

            RadAnimationManager.Play(grid_Estigma, resizeAnimation);
        }

        private void shield_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            LosingFocus = true;
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MarcoN_1.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MarcoN_2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MarcoN_3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Tec_Recomendadas/Servicios_Aborto_Seguro.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Tec_Recomendadas/Clinica_Aborto_Seguro.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Tec_Recomendadas/Metodos_Recomendados.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_6(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Tec_Recomendadas/Contraindicaciones_Precauciones.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_7(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Criterios_Medicos.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_8(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Informacion_Anticonceptiva.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_9(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Disco_Criterios.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_10(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Metodos_Anticonceptivos/Quiz_Metodos_Anticonceptivos.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_11(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_1.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_12(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TextBlock_Tap_13(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Estigma_3.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click(object sender, System.Windows.Input.GestureEventArgs e)
        {
            RadMoveAnimation animation = new RadMoveAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;
            Point endPoint = new Point();
            if (a == 0)
            {
                endPoint.X = 321;
                endPoint.Y = 0;
                a = 1;
                CControl.Focus();
                //boton_menu.IsEnabled = false;
            }
            shield.Visibility = Visibility.Visible;
            animation.EndPoint = endPoint;
            animation.Easing = ease;
            RadAnimationManager.Play(CControl, animation);
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}