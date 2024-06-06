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
using System.Windows.Shapes;

namespace Kikelet_Panzió
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        public ReservationWindow()
        {
            InitializeComponent();
            cbGuest.ItemsSource = MainWindow.registeredGuestList.list;
            cbRoom.ItemsSource = MainWindow.roomList.list;
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.Text != "" &&dpTo.Text != "")
            {
                Reservation rs = new Reservation(
                    Convert.ToInt32(((RegisteredGuest)cbGuest.SelectedItem).guestId),
                    Convert.ToInt32(((Room)cbRoom.SelectedItem).roomId),
                    dpFrom.SelectedDate.Value,
                    dpTo.SelectedDate.Value
                );
                MainWindow.reservationList.InsertToDB(rs);
                MainWindow.reservationList.GetLastFromDB();
                this.Close();
            }
            else
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
            }
        }
    }
}
