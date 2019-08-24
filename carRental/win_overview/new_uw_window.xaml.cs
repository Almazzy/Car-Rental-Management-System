using carRental.klasy;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace carRental.win_overview
{
    /// <summary>
    /// Logika interakcji dla klasy new_uw_window.xaml
    /// </summary>
    public partial class new_uw_window : Window
    {
        public new_uw_window()
        {
            InitializeComponent();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_po();
        }

        private void add_po()
        {

            if (string.IsNullOrWhiteSpace(txt_name.Text))
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            else
            { //wszystkie pola uzupelione
                try
                {
                    connection.openConnection();
                    connection.sql = "INSERT INTO Ubezpieczalnie(nazwa) values('" + txt_name.Text + "')";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    MessageBox.Show("Poprawnie dodano nowe towarzystwo ubezpieczeniowe.", "Komunikat.");
                    connection.closeConnection();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void clear()
        {
            txt_name.Text = null;
        }
    }
}
