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
    /// Logika interakcji dla klasy new_p_window.xaml
    /// </summary>
    public partial class new_p_window : Window
    {
        public new_p_window()
        {
            InitializeComponent();
            combo_ser_items();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_new();
        }

        private void add_new()
        {

            if (string.IsNullOrWhiteSpace(txt_text.Text) || string.IsNullOrWhiteSpace(date_do.Text) || 
                string.IsNullOrWhiteSpace(date_od.Text) || string.IsNullOrWhiteSpace(combo_ser.Text))
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            else
            { //wszystkie pola uzupelione
                try
                {
                    string ser = Convert.ToString(combo_ser.SelectedItem);
                    string date1 = Convert.ToDateTime(date_od.SelectedDate.Value).ToString("MM-dd-yyyy");
                    string date2 = Convert.ToDateTime(date_do.SelectedDate.Value).ToString("MM-dd-yyyy");

                    connection.openConnection();
                    connection.sql = "INSERT INTO Przeglady(miejsce_wykonania, data_od, data_doo, notatka, status) " + 
                        " values('" + ser + "','" + date1 + "','" + date2 + "','" + txt_text.Text + "','nieprzypisany')";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    MessageBox.Show("Poprawnie dodano nowy przegląd.", "Komunikat.");
                    MessageBox.Show("Pamiętaj o przypisaniu przeglądu do samochodu!", "WAŻNY KOMUNIKAT.");
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
            combo_ser.Text = null;
        }

        private void combo_items(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();
        }

        private void combo_ser_items()
        {
            combo_items("SELECT * FROM Serwisy");
            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nazwa"));
                combo_ser.Items.Add(nr);
            }
            connection.closeConnection();
        }
    }
    
}
