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
        internal static RegisteredGuestList registeredGuestList = new RegisteredGuestList("kikeletpanzio", "root", "");
        internal static RoomList roomList = new RoomList("kikeletpanzio", "root", "");
        internal static ReservationList reservationList = new ReservationList("kikeletpanzio", "root", "");

        public MainWindow()
        {
            InitializeComponent();
            registeredGuestList.LoadFromDB();
            dgvalami.ItemsSource = registeredGuestList.list;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            registeredGuestList.InsertToDB();
        }
    }
}