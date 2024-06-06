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
    /// Interaction logic for GuestRegistWindow.xaml
    /// </summary>
    public partial class GuestRegistWindow : Window
    {
        public GuestRegistWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text != "" && dpBirth.Text != "" && tbCountry.Text != "" && tbCity.Text !="" && tbZip.Text != "" && tbAddress.Text !="")
            {
                var obj = new RegisteredGuest(tbName.Text, Convert.ToDateTime(dpBirth.Text), tbCountry.Text, tbZip.Text, tbCity.Text, tbAddress.Text, tbEmail.Text, (bool)cbVIP.IsChecked, (bool)cbBanned.IsChecked);
                try
                {
                    MainWindow.registeredGuestList.InsertToDB(obj);
                    MainWindow.registeredGuestList.GetLastFromDB();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
            }
            
        }
    }
}
