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

            DataGrid dgGuest = new DataGrid() 
            {
                ItemsSource = registeredGuestList.list,
                AutoGenerateColumns = false,
                Columns =
                {
                    new DataGridTextColumn() { Header = "ID", Binding = new Binding("guestId") { Mode = BindingMode.OneWay }, IsReadOnly = true},
                    new DataGridTextColumn() { Header = "Kód", Binding = new Binding("guestCode") { Mode = BindingMode.OneWay }, IsReadOnly = true},
                    new DataGridTextColumn() { Header = "Név", Binding = new Binding("guestName"),},
                    new DataGridTextColumn() { Header = "Szül. dátum", Binding = new Binding("birthDay") { StringFormat = "yyyy.MM.dd" } },
                    new DataGridTextColumn() { Header = "Ország", Binding = new Binding("country") },
                    new DataGridTextColumn() { Header = "Irányító szám", Binding = new Binding("postalCode") },
                    new DataGridTextColumn() { Header = "Város", Binding = new Binding("city") },
                    new DataGridTextColumn() { Header = "Cím", Binding = new Binding("address") },
                    new DataGridTextColumn() { Header = "E-mail", Binding = new Binding("email") },
                    new DataGridCheckBoxColumn() { Header = "VIP", Binding = new Binding("vip")},
                    new DataGridCheckBoxColumn() { Header = "Tiltva", Binding = new Binding("banned") },
                }
            };
            dpContainer.Children.Add(dgGuest);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //registeredGuestList.InsertToDB();
        }
    }
}