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
    /// Logika interakcji dla klasy delete_car_window.xaml
    /// </summary>
    public partial class delete_car_window : Window
    {
        public delete_car_window()
        {
            InitializeComponent();
            combo_car_items();
        }

        int help2, car_id;

        private void Btn_end_step2_Click(object sender, RoutedEventArgs e)
        {
            if (help2 == 0)//nie potwierdzono 
            {
                MessageBox.Show("Dezaktywacja samochodu musi być potwierdzona.", "Komunikat");
            }
            else if (help2 == 1) { //potwierdzno
                try
                {
                    string n = Convert.ToString(combo_car.SelectedItem);

                    connection.openConnection();
                    connection.sql = "UPDATE Samochody SET aktywnosc = 'dezaktywowany' where Id_Samochodu = '" + car_id + "'";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    connection.closeConnection();

                    clear();
                    MessageBox.Show("Samochód został dezaktywowany.", "Komunikat");
                    help2 = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void Btn_end_step1_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(lbl_inf5.Content) == "WOLNY")
            {
                MessageBox.Show("Aby zakończyć i potwierdzić dezaktywacje samochodu kliknij 'dezaktywuj'.", "Komunikat");
                help2 = 1;
            }
            else {
                MessageBox.Show("Dezaktywować można tylko samochód, który jest wolny.", "Komunikat");
            }

        }

        private void clear() {
            lbl_inf4.Content = null;
            lbl_inf5.Content = null;
            lbl_inf1.Content = null;
            lbl_inf2.Content = null;
            lbl_inf3.Content = null;
            combo_car.Text = null;
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
                data_conn("SELECT vin FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_inf3.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT rok_produkcji FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_inf4.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT stan FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_inf5.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                if (Convert.ToString(lbl_inf5.Content) == "wydany" || Convert.ToString(lbl_inf5.Content) == "serwis" ||
                    Convert.ToString(lbl_inf5.Content) == "dyzur" || Convert.ToString(lbl_inf5.Content) == "rezerwacja")
                {
                    lbl_inf5.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }else if (Convert.ToString(lbl_inf5.Content) == "wolny")
                {
                    lbl_inf5.Content = "WOLNY";
                    lbl_inf5.Foreground = new SolidColorBrush(Color.FromRgb(50, 240, 20));
                }
                data_conn("SELECT Id_Samochodu FROM Samochody WHERE nr_rejestracyjny = '" + n + "' ");
                car_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void combo_car_items()
        {
            connection.openConnection();
            connection.sql = ("SELECT * FROM Samochody WHERE aktywnosc = 'aktywny'");
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