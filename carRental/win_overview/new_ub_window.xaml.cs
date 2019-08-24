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
    /// Logika interakcji dla klasy new_ub_window.xaml
    /// </summary>
    public partial class new_ub_window : Window
    {
        public new_ub_window()
        {
            InitializeComponent();
            combo_ub_items();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_new();
        }

        private void add_new()
        {

            if (string.IsNullOrWhiteSpace(txt_text.Text) || string.IsNullOrWhiteSpace(date_do.Text) || 
                string.IsNullOrWhiteSpace(date_od.Text) || string.IsNullOrWhiteSpace(combo_ub.Text) || string.IsNullOrWhiteSpace(txt_price.Text))
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            else
            { //wszystkie pola uzupelione
                try
                {
                    string ub = Convert.ToString(combo_ub.SelectedItem);
                    string date1 = Convert.ToDateTime(date_od.SelectedDate.Value).ToString("MM-dd-yyyy");
                    string date2 = Convert.ToDateTime(date_do.SelectedDate.Value).ToString("MM-dd-yyyy");
                    double price = Convert.ToInt32(txt_price.Text);

                    connection.openConnection();
                    connection.sql = "INSERT INTO Polisy(ubezpieczyciel, kwota_brutto ,data_od, data_do, notatka, status) " +
                        " values('" + ub + "','" + price + "','" + date1 + "','" + date2 + "','" + txt_text.Text + "','nieprzypisana')";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    MessageBox.Show("Poprawnie dodano nową polisę.", "Komunikat");
                    MessageBox.Show("Pamiętaj o przypisaniu polisy do samochodu!", "WAŻNY KOMUNIKAT");
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
            txt_text.Text = null;
            date_do.Text = null;
            date_od.Text = null;
            combo_ub.Text = null;
            txt_price.Text = null;
        }

        private void combo_items(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();
        }

        private void combo_ub_items()
        {
            combo_items("SELECT * FROM Ubezpieczalnie");
            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nazwa"));
                combo_ub.Items.Add(nr);
            }
            connection.closeConnection();
        }
    }
}
