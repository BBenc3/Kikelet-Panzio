using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Kikelet_Panzió
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        internal static ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        internal static ObservableCollection<RegisteredGuest> guests = new ObservableCollection<RegisteredGuest>();
        internal static ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}