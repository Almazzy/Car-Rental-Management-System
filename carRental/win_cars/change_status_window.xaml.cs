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

namespace carRental.win_cars
{
    /// <summary>
    /// Logika interakcji dla klasy change_status_window.xaml
    /// </summary>
    public partial class change_status_window : Window
    {
        public change_status_window()
        {
            InitializeComponent();
            combo_car_items();
        }

        int car_id;

        private void Btn_change_Click(object sender, RoutedEventArgs e)
        {
            if (combo_car.Text != null & combo_status != null)
            {
                Status();
            }
            else
            {
                MessageBox.Show("Wybierz status i samochód.", "Błąd");
            }
        }

        private void Status()
        {
            try
            {
                string status = Convert.ToString(combo_status.SelectedItem);

                connection.openConnection();
                connection.sql = "UPDATE Samochody SET stan = '" + status + "' where Id_Samochodu = '" + car_id + "'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                connection.cmd.ExecuteNonQuery();
                connection.closeConnection();

                clear();
                MessageBox.Show("Pomyślnie zmieniono status samochodu.", "Komunikat");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Combo_car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string n = Convert.ToString(combo_car.SelectedItem);
                data_conn("SELECT marka FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_inf1.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT model FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_inf2.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT stan FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_inf5.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT Id_Samochodu FROM Samochody WHERE nr_rejestracyjny = '" + n + "' ");
                car_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clear()
        {
            lbl_inf5.Content = null;
            lbl_inf1.Content = null;
            lbl_inf2.Content = null;
            combo_car.Text = null;
        }

        private void combo_car_items()
        {
            connection.openConnection();
            connection.sql = ("SELECT * FROM Samochody WHERE aktywnosc = 'aktywny' AND stan='wolny' OR stan='dyzur' OR stan='serwis'");
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

        private void data_conn(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
        }
    }
}
