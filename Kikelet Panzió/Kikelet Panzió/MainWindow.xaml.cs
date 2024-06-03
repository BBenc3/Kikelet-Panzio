using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Kikelet_Panzió
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        internal static RegisteredGuestList registeredGuestList = new RegisteredGuestList();
        internal static RoomList roomList = new RoomList();
        internal static ReservationList reservationList = new ReservationList();

        public MainWindow()
        {
            WindowLogin windowLogin = new WindowLogin();
            windowLogin.ShowDialog();
            InitializeComponent();
            registeredGuestList.LoadFromDB();

            DataGrid dgGuests = new DataGrid()
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
            DataGrid dgRooms = new DataGrid()
            {
                ItemsSource = roomList.list,
                AutoGenerateColumns = false,
                Columns =
                {
                    new DataGridTextColumn() { Header = "ID", Binding = new Binding("roomId") { Mode = BindingMode.OneWay }, IsReadOnly = true},
                    new DataGridTextColumn() { Header = "Szoba szám", Binding = new Binding("roomNumber"), IsReadOnly = true},
                    new DataGridTextColumn() { Header = "Férőhely", Binding = new Binding("accommodation"), IsReadOnly = true },
                    new DataGridTextColumn() { Header = "Ár", Binding = new Binding("price") },
                }
            };
            DataGrid dgReservations = new DataGrid() 
            {
                ItemsSource = reservationList.list,
                AutoGenerateColumns = false,
                Columns =
                {
                    new DataGridTextColumn { Header = "ID", Binding = new Binding("reservationId"), IsReadOnly = true },
                    new DataGridTextColumn { Header = "Szoba", Binding = new Binding("room") },
                    new DataGridTextColumn { Header = "Vendég", Binding = new Binding("guest") },
                    new DataGridTextColumn { Header = "Érkezés", Binding = new Binding("checkedIn") },
                    new DataGridTextColumn { Header = "Távozás", Binding = new Binding("checkedOut") },
                    new DataGridTextColumn { Header = "Fizetendő", Binding = new Binding("price") },
                    new DataGridTextColumn { Header = "Első lefoglalt nap", Binding = new Binding("firstReservedDay") { StringFormat = "yyyy.MM.dd" } },
                    new DataGridTextColumn { Header = "Utolsó lefoglalt nap", Binding = new Binding("lastReservedDay") { StringFormat = "yyyy.MM.dd" } },
                    new DataGridTextColumn { Header = "Foglalás időpontja", Binding = new Binding("dateOfReservation") },
                    new DataGridTextColumn { Header = "Foglalás állapota", Binding = new Binding("reservationStatust") }

                }

            };
            dpContainer.Children.Add(dgGuests);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //registeredGuestList.InsertToDB();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miGuestregister_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miReservation_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miStatistics_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miGuests_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miBanned_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miRooms_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miAllRooms_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miFreeRooms_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miReservedRooms_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miReservations_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miAllReservations_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miInactiveReservations_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miDeletedReservations_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miSortByDate_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miAllGuests_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void miVIP_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}