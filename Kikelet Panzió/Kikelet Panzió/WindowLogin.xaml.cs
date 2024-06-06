using System.Windows;
using MySqlConnector;

namespace Kikelet_Panzió
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection($"Server=localhost;Database=kikeletpanzio;Uid={tbName.Text};Pwd={pbPassword.Password};");
            try
            {
                mySqlConnection.Open();
                MainWindow.loggedin = true;
                this.Close(); 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MainWindow.loggedin = false;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
    }
}
