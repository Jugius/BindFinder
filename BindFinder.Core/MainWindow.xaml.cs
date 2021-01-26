using BindFinder.ViewModels;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BindFinder.Core
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModels.MainWindowVM DataContextModel;
        public MainWindow()
        {
            //Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Windows8Theme();
            //Telerik.Windows.Controls.StyleManager.ApplicationTheme = new Telerik.Windows.Controls.FluentTheme();
            InitializeComponent();
            InitializeMap();
            this.DataContext = this.DataContextModel = new ViewModels.MainWindowVM();
            this.DataContextModel.PropertyChanged += DataContextModel_PropertyChanged;
        }

        private void DataContextModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedBind")
            {
                DrawPoint(this.DataContextModel.SelectedBind);
            }
        }
        private void DrawPoint(BindVM selectedBind)
        {
            gMap.Markers.Clear();

            if(selectedBind == null || OutOfHome.Models.Location.IsNullOrEmpty(selectedBind.Location))
            {
                gMap.Position = new PointLatLng(50.45, 30.52333);
                gMap.MinZoom = 5;
                gMap.MaxZoom = 5;
                gMap.Zoom = 5;

                lblGoogleMap.Visibility = Visibility.Hidden;
            }
            else
            {
                gMap.Position = new PointLatLng(selectedBind.Location.Latitude, selectedBind.Location.Longitude);
                GMapMarker marker = new GMapMarker(gMap.Position);
                marker.Offset = new Point(-5, -5);

                Rectangle rectangle = new Rectangle { Fill = new SolidColorBrush(Colors.Red), Width = 11, Height = 11, RadiusX = 6, RadiusY = 6, Stroke = Brushes.Black, StrokeThickness = 1 };
                marker.Shape = rectangle;
                gMap.Markers.Add(marker);
                gMap.MinZoom = gMap.MaxZoom = 17;
                gMap.Zoom = 17;
                lblGoogleMap.Visibility = Visibility.Visible;
                linkGoogleMap.NavigateUri = new Uri(@"https://www.google.com/maps/search/" + selectedBind.Location.ToString());     
            }            
        }

        private void InitializeMap()
        {
            gMap.Manager.Mode = AccessMode.ServerAndCache;
            gMap.ShowCenter = false;
            gMap.MapProvider = GMapProviders.GoogleMap;

            gMap.Position = new PointLatLng(50.45, 30.52333);
            gMap.MinZoom = 5;
            gMap.MaxZoom = 5;
            gMap.Zoom = 5;           
            
            gMap.CanDragMap = false;
            gMap.MouseWheelZoomEnabled = false;
            gMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            if(e.Uri != null)
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }            
        }
    }
}
