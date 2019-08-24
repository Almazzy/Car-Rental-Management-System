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

namespace carRental.win_rentals
{
    /// <summary>
    /// Logika interakcji dla klasy end_window.xaml
    /// </summary>
    public partial class end_window : Window
    {
        public end_window()
        {
            InitializeComponent();
            combo_car_items();
        }

        public int car_id;

        private void combo_car_items()
        {
            connection.openConnection();
            connection.sql = ("SELECT * FROM Samochody WHERE stan = 'wydany' AND aktywnosc = 'aktywny'");
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();

            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nr_rejestracyjny"));
                combo_car.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void Combo_car_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string n = Convert.ToString(combo_car.SelectedItem);
                data_conn("SELECT marka FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_car1.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT model FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_car2.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void data_conn(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
        }

        private void clear() {
            lbl_car1.Content = null;
            lbl_car2.Content = null;
            lbl_inf1.Content = null;
            lbl_inf2.Content = null;
            lbl_inf3.Content = null;
            combo_car.Text = null;
        }

        private void Btn_check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string n = Convert.ToString(combo_car.SelectedItem);
                data_conn("SELECT k.najemca FROM Klienci k, Wynajmy w, Samochody s WHERE s.nr_rejestracyjny = '" + n + "' AND w.Id_Samochodu=s.Id_Samochodu AND w.Id_Klienta=k.Id_Klienta");
                lbl_inf1.Content = (string)connection.cmd.ExecuteScalar();
                data_conn("SELECT k.uzytkownik FROM Klienci k, Wynajmy w, Samochody s WHERE s.nr_rejestracyjny = '" + n + "' AND w.Id_Samochodu=s.Id_Samochodu AND w.Id_Klienta=k.Id_Klienta");
                lbl_inf2.Content = (string)connection.cmd.ExecuteScalar();
                data_conn("SELECT w.data_wydania FROM Klienci k, Wynajmy w, Samochody s WHERE s.nr_rejestracyjny = '" + n + "' AND w.Id_Samochodu=s.Id_Samochodu AND w.Id_Klienta=k.Id_Klienta");
                lbl_inf3.Content = (System.DateTime)connection.cmd.ExecuteScalar();
                data_conn("SELECT Id_Samochodu FROM Samochody WHERE nr_rejestracyjny = '" + n + "' ");
                car_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string n = Convert.ToString(combo_car.SelectedItem);

                connection.openConnection();
                connection.sql = "UPDATE Samochody SET stan = 'wolny' where Id_Samochodu = '" + car_id + "'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;

                connection.cmd.ExecuteNonQuery();
                connection.sql = "UPDATE Wynajmy SET data_odbioru = '" + DateTime.Now + "' where Id_Samochodu = '" + car_id + "'";
                connection.cmd.ExecuteNonQuery();
                connection.closeConnection();

                clear();
                MessageBox.Show("Poprawnie zakończono wynajem.", "Komunikat.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
