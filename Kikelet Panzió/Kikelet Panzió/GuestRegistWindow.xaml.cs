using System.Text.RegularExpressions;
using System.Windows;

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
            if (tbName.Text != "" && dpBirth.Text != "" && tbCountry.Text != "" && tbCity.Text != "" && tbZip.Text != "" && tbAddress.Text != "")
            {
                string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
                if (!Regex.IsMatch(tbEmail.Text, emailPattern))
                {
                    MessageBox.Show("Nem megfelelő email.");
                    tbEmail.Focus();
                }
                else
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
}
