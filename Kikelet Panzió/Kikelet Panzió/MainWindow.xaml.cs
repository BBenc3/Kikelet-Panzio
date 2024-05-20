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

            string connectionString = "server=localhost;user={username};password={password};database=varosaink";

            // Step 2: Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Step 3: Open the connection
                    connection.Open();
                    Console.WriteLine("Connection Opened Successfully");

                    // Step 4: Create a SQL command
                    string query = "SELECT * FROM TableName";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Step 5: Execute the command and read the data
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Assuming the table has a column named 'ColumnName'
                        Console.WriteLine(reader["ColumnName"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    // Step 6: Close the connection
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        Console.WriteLine("Connection Closed");
                    }
                }
            }
        
    }
    }
}