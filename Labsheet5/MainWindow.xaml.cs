using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labsheet5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MusicShopContainer db = new MusicShopContainer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from a in db.Bands
                        orderby a.Name
                        select a.Name;

            LBXBands.ItemsSource = query.ToList();

            var query5 = from a in db.Bands
                        select a;

            DGBands.ItemsSource = query5.ToList();

            var query6 = from a in db.Albums
                        select a;

            DGAlbum.ItemsSource = query6.ToList();


        }

        private void LBXBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string band = LBXBands.SelectedItem as string;

            if(band != null)
            {
                var query = from A in db.Albums
                            where A.Name.Equals(band)
                            select A.Name;
                LBXAlbum.ItemsSource = query.ToList();
            }
          
        }
    }
}
