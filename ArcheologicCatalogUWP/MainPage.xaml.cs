using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace ArcheologicCatalogUWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal ObservableCollection<ArcheoObject> ArcheoObjects { get; } = new ObservableCollection<ArcheoObject>();
        public MainPage()
        {
            this.InitializeComponent();
            //Add ArcheoObject into the ArcheoObjects
            // Dummy Daten
            this.ArcheoObjects.Add(new ArcheoObject() { CodeOut = "Test1", PictureLinkOut = "C:\\Users\\das70\\OneDrive\\Bilder\\20191124 Beirut\\IMG_20191124_152518.jpg" });
            this.ArcheoObjects.Add(new ArcheoObject() { CodeOut = "Test2", PictureLinkOut = "C:\\Users\\das70\\OneDrive\\Bilder\\20191124 Beirut\\IMG_20191124_152518.jpg" });
            this.ArcheoObjects.Add(new ArcheoObject() { CodeOut = "Test3", PictureLinkOut = "C:\\Users\\das70\\OneDrive\\Bilder\\20191124 Beirut\\IMG_20191124_152518.jpg" });
        }

        private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DetailPage));
        }
    }
}
