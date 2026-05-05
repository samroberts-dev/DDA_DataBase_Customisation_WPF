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
using MySql.Data.MySqlClient;

namespace DDA_Week12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlConnection connection;
        private string server = "127.0.0.1";
        private string port = "3306";
        private string username = "root";
        private string password = "";
        private string database = "sakila_tafe";

        public MainWindow()
        {
            InitializeComponent();
            string connectionString = $"server={server};port={port};uid={username};pwd={password};database={database};";
            connection = new MySqlConnection(connectionString);
        }

        private void LoadTablesInDatabase()
        {
            connection.Open();
            DataTable tables = connection.GetSchema("Tables");

            ListBox_Display_Tables.Items.Clear();

            foreach (DataRow row in tables.Rows)
            {
                ListBox_Display_Tables.Items.Add(row["TABLE_NAME"].ToString());

            }
            connection.Close();
        }

        private void ShowCreationPage(object sender, RoutedEventArgs e)
        {
            Grid_Select.Visibility = Visibility.Collapsed;
        }

        private void ShowSelectionPage(object sender, RoutedEventArgs e)
        {
            Grid_Select.Visibility = Visibility.Visible;
            LoadTablesInDatabase();
        }

        private void ShowInsertionPage(object sender, RoutedEventArgs e)
        {
            Grid_Select.Visibility = Visibility.Collapsed;
        }

        private void Selection_Changed_Display_Tables(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Table_Entry.Text = (string)ListBox_Display_Tables.SelectedValue;
        }

    }
}