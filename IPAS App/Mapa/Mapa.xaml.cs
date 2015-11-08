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

namespace IPAS_App.Mapa
{

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
    public class Root
    {
        [XmlArray("clinics")]
        [XmlArrayItem("clinic",typeof (Clinic))]
        public Clinic[] clinics { get; set; }
    };

    public partial class Mapa : PhoneApplicationPage
    {
        public Mapa()
        {
            InitializeComponent();

            Root rootXML = null;
            string path = "Model/clinics.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            StreamReader reader = new StreamReader(path);
            rootXML = (Root)serializer.Deserialize(reader);
            reader.Close();

            MapLayer mapLayer = new MapLayer();

            foreach (var item in rootXML.clinics)
            {
                double finalLat = Double.Parse(item.lat.Replace('"', ' ').Trim());
                double finalLon = Double.Parse(item.lng.Replace('"', ' ').Trim());

                Pushpin pushpin = new Pushpin();
                pushpin.GeoCoordinate = new GeoCoordinate(finalLat, finalLon);
                pushpin.Content = item.name;
                //pushpin.Style = (Style)App.Current.Resources["MyPushpin"];
                pushpin.Tap += OnTap;

                MapOverlay mapOverlay = new MapOverlay();
                mapOverlay.Content = pushpin;
                mapOverlay.GeoCoordinate = new GeoCoordinate(finalLat, finalLon);
                mapLayer.Add(mapOverlay);
            }

            Map MyMap = new Map();
            MyMap.Center = new GeoCoordinate(Double.Parse(rootXML.clinics[0].lat.Replace('"', ' ').Trim()), Double.Parse(rootXML.clinics[0].lng.Replace('"', ' ').Trim()));
            MyMap.ZoomLevel = 12;
            MyMap.CartographicMode = MapCartographicMode.Road;
            MyMap.ColorMode = MapColorMode.Light;
            

           MyMap.Layers.Add(mapLayer);


           ContentPanel.Children.Add(MyMap);
        }

        private void OnTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}