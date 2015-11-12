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

namespace IPAS_App
{
    public partial class Quiz_Metodos_Anticonceptivos : PhoneApplicationPage
    {
        public Quiz_Metodos_Anticonceptivos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Popup popup = new Popup();
            popup.Height = 300;
            popup.Width = 400;
            popup.VerticalOffset = 100;
            OverlayMenu control = new OverlayMenu();
            popup.Child = control;
            popup.IsOpen = true;

            //control.btnOK.Click += (s, args) =>
            //{
            //    popup.IsOpen = false;
            //};

            control.btnCancel.Click += (s, args) =>
            {
                popup.IsOpen = false;
            };

        }

    }
}