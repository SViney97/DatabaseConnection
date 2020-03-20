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
            var query = from b in db.Bands
                        orderby b.Name
                        select b;

            var results = query.ToList();

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
            var BandID = LBXBands.SelectedValue;

            int bandID = Convert.ToInt32(BandID);

            if(BandID != null)
            {
                var query = from A in db.Albums
                            where A.BandId == bandID
                            select A.Name;

                var results = query.ToList();

                LBXAlbum.ItemsSource = query.ToList();
            }
          
        }
    }
}
