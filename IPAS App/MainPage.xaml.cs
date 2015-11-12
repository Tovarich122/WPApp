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
        int wmarcon = 0;
        bool LosingFocus = true;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            shield.Visibility = Visibility.Collapsed;
            grid_marcoN.Height = 0;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                RadMoveAnimation animation = new RadMoveAnimation();
                EasingFunctionBase ease = new QuadraticEase();
                ease.EasingMode = EasingMode.EaseInOut;
                Point endPoint = new Point();
                if (a == 0)
                {
                    endPoint.X = 234;
                    endPoint.Y = 0;
                    a = 1;
                    CControl.Focus();
                    boton_menu.IsEnabled = false;
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
                boton_menu.IsEnabled = true;
                RadAnimationManager.Play(CControl, animation);
            }
            else
            {

                LosingFocus = true;
            }
        }

        private void bBarra_MarcoN_Click(object sender, RoutedEventArgs e)
        {
            LosingFocus = false;
            RadResizeAnimation resizeAnimation = new RadResizeAnimation();
            EasingFunctionBase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseInOut;
            if (wmarcon == 0)
            {
                resizeAnimation.StartSize = new Size(230, 0);
                Size size = new Size(230, 170);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                wmarcon = 1;
            }
            else
            {
                resizeAnimation.StartSize = new Size(230,170);
                Size size = new Size(230, 0);
                resizeAnimation.EndSize = size;
                resizeAnimation.Easing = ease;
                wmarcon = 0;
            }
            
            RadAnimationManager.Play(grid_marcoN, resizeAnimation);
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