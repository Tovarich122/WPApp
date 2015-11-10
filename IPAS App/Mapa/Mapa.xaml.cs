using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using Windows.ApplicationModel;
using System.Windows.Resources;
using Microsoft.Phone.Maps.Toolkit;
using System.Windows.Controls.Primitives;

namespace IPAS_App.Mapa
{

    public class Station
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("icon")]
        public string icon { get; set; }

        [XmlElement("lat")]
        public string lat { get; set; }

        [XmlElement("lng")]
        public string lng { get; set; }
    }

    [XmlRoot("root")]
    public class StationRoot
    {
        [XmlArray("stations")]
        [XmlArrayItem("station", typeof(Station))]
        public Station[] stations { get; set; }
    }

    public class Clinic 
    {
        [XmlElement("number")]
        public string number { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("address")]
        public string address { get; set; }

        [XmlElement("contact")]
        public string contact { get; set; }

        [XmlElement("references")]
        public string references { get; set; }

        [XmlElement("lat")]
        public string lat { get; set; }

        [XmlElement("lng")]
        public string lng { get; set; }

    };

    [XmlRoot("root")]
    public class ClinicsRoot
    {
        [XmlArray("clinics")]
        [XmlArrayItem("clinic",typeof (Clinic))]
        public Clinic[] clinics { get; set; }
    };

    public partial class Mapa : PhoneApplicationPage
    {
        Map MyMap;

        private void onMapLoaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "0b0c3b9a-6c18-4d60-9ad4-91289b5a1197";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "1pOOPeH3OK4vDUybldNrBw";
        }

        public Mapa()
        {
            InitializeComponent();
            MyMap = new Map();
            MapLayer mapLayer = new MapLayer();
            MyMap.Loaded += onMapLoaded;

            ClinicsRoot clinicsXML = null;
            string path = "Model/clinics.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(ClinicsRoot));
            StreamReader reader = new StreamReader(path);
            clinicsXML = (ClinicsRoot)serializer.Deserialize(reader);
            reader.Close();

            foreach (var item in clinicsXML.clinics)
            {
                double finalLat = Double.Parse(item.lat.Replace('"', ' ').Trim());
                double finalLon = Double.Parse(item.lng.Replace('"', ' ').Trim());

                Pushpin pushpin = new Pushpin();
                pushpin.GeoCoordinate = new GeoCoordinate(finalLat, finalLon);
                if (item.name.Length > 15)
                {
                    StackPanel stack = new StackPanel();
                    stack.Children.Add(new TextBlock { Text = item.name.Substring(0, 14) + "...", MaxWidth = 480,TextWrapping = TextWrapping.Wrap });
                    stack.Children.Add(new TextBlock { Text = item.name, MaxWidth = 480, TextWrapping = TextWrapping.Wrap });
                    stack.Children[1].Visibility = Visibility.Collapsed;

                    StackPanel hiddenStack = new StackPanel();
                    hiddenStack.Children.Add(new TextBlock { Text = item.address, MaxWidth = 480, TextWrapping = TextWrapping.Wrap });
                    hiddenStack.Children.Add(new TextBlock { Text = item.contact, MaxWidth = 480, TextWrapping = TextWrapping.Wrap });
                    hiddenStack.Children.Add(new TextBlock { Text = item.references, MaxWidth = 480, TextWrapping = TextWrapping.Wrap });
                    hiddenStack.Visibility = Visibility.Collapsed;

                    StackPanel coordinates = new StackPanel();
                    coordinates.Children.Add(new TextBlock { Text = item.lat });
                    coordinates.Children.Add(new TextBlock { Text = item.lng });
                    coordinates.Visibility = Visibility.Collapsed;

                    stack.Children.Add(hiddenStack);
                    stack.Children.Add(coordinates);
                    
                    pushpin.Content = stack;
                }
                else
                {
                    pushpin.Content = item.name;
                }

                pushpin.Style = (Style)App.Current.Resources["OrangePushpin"];
                pushpin.Tap += OnTap;

                MapOverlay mapOverlay = new MapOverlay();
                mapOverlay.Content = pushpin;
                mapOverlay.GeoCoordinate = new GeoCoordinate(finalLat, finalLon);
                mapOverlay.PositionOrigin = new Point(0.5, 0.5);
                mapLayer.Add(mapOverlay);
            }

            StationRoot stationsXML = null;
            path = "Model/stations.xml";
            XmlSerializer serializer2 = new XmlSerializer(typeof(StationRoot));
            StreamReader reader2 = new StreamReader(path);
            stationsXML = (StationRoot)serializer2.Deserialize(reader2);
            reader2.Close();

            foreach (var item in stationsXML.stations)
            {
                double finalLat = Double.Parse(item.lat.Replace('"', ' ').Trim());
                double finalLon = Double.Parse(item.lng.Replace('"', ' ').Trim());

                Pushpin pushpin = new Pushpin();
                pushpin.GeoCoordinate = new GeoCoordinate(finalLat, finalLon);

                System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                string filePath = "/Images/"+ item.icon +".png";
                bmp.UriSource = new Uri(filePath, UriKind.Relative);
                
                var imageBrush = new System.Windows.Media.ImageBrush
                {
                    ImageSource = bmp
                };

                pushpin.Content = new Grid()
                {
                    Background = imageBrush,
                    Height = 40,
                    Width = 40
                };

                pushpin.Style = (Style)App.Current.Resources["OrangePushpin"];
                //pushpin.Tap += OnTap;

                MapOverlay mapOverlay = new MapOverlay();
                mapOverlay.Content = pushpin;
                mapOverlay.GeoCoordinate = new GeoCoordinate(finalLat, finalLon);
                mapLayer.Add(mapOverlay);
            }

            MyMap.Center = new GeoCoordinate(Double.Parse(clinicsXML.clinics[0].lat.Replace('"', ' ').Trim()), Double.Parse(clinicsXML.clinics[0].lng.Replace('"', ' ').Trim()));
            MyMap.ZoomLevel = 12;
            MyMap.CartographicMode = MapCartographicMode.Road;
            MyMap.ColorMode = MapColorMode.Light;
            
            MyMap.Layers.Add(mapLayer);
            ContentPanel.Children.Add(MyMap);
        }

        private void OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;

            if (pushpin.Content != null)
            {
                StackPanel hiddenContentParent = pushpin.Content as StackPanel;
                StackPanel hiddenChildren = hiddenContentParent.Children[2] as StackPanel;
                StackPanel hiddenCoordinates = hiddenContentParent.Children[3] as StackPanel;

                //SetCenter
                TextBlock latTB = hiddenCoordinates.Children[0] as TextBlock;
                TextBlock lngTB = hiddenCoordinates.Children[1] as TextBlock;
                MyMap.SetView(new GeoCoordinate(Double.Parse(latTB.Text), Double.Parse(lngTB.Text)),18,MapAnimationKind.Parabolic);

                if (hiddenChildren.Visibility == Visibility.Collapsed)
                {
                    TextBlock name = hiddenContentParent.Children[0] as TextBlock;
                    TextBlock newName = hiddenContentParent.Children[1] as TextBlock;
                    name.Visibility = Visibility.Collapsed;
                    newName.Visibility = Visibility.Visible;
                    hiddenChildren.Visibility = Visibility.Visible;
                }
            }
            // to stop the event from going to the parent map control
            e.Handled = true;

        }
    }
}