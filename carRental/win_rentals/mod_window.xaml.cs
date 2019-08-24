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

using carRental.win_rentals;

namespace carRental.win_rentals
{
    /// <summary>
    /// Logika interakcji dla klasy mod_window.xaml
    /// </summary>
    public partial class mod_window : Window
    {
        public mod_window()
        {
            InitializeComponent();
            start();
        }

        public int car_id, pri_id, car_id_new;

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
                combo_car_new.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_car_new_items()
        {
            connection.openConnection();
            connection.sql = ("SELECT * FROM Samochody WHERE stan = 'wolny'");
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();

            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nr_rejestracyjny"));
                combo_car_new.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_pri_items()
        {
            connection.openConnection();
            connection.sql = ("SELECT * FROM Cenniki");
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();

            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nazwa"));
                combo_pri.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void start() {
            combo_car_new_items();
            combo_car_items();
            combo_pri_items();
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

        private void Combo_car_new_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string n = Convert.ToString(combo_car_new.SelectedItem);
                data_conn("SELECT marka FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_car1_new.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT model FROM samochody WHERE nr_rejestracyjny = '" + n + "'");
                lbl_car2_new.Content = (string)connection.cmd.ExecuteScalar();
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

        private void clear()
        {
            lbl_car1.Content = null;
            lbl_car2.Content = null;
            lbl_inf1.Content = null;
            lbl_inf2.Content = null;
            lbl_inf3.Content = null;
            txt_type.Text = null;
            txt_where_o.Text = null;
            combo_car.Text = null;
            combo_car_new.Text = null;
            combo_pri.Text = null;
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

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            clear();
            start();
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void get_inf()
        {
            try
            {
                string n = Convert.ToString(combo_car_new.SelectedItem);
                string nm = Convert.ToString(combo_pri.SelectedItem);

                data_conn("SELECT Id_Samochodu FROM Samochody WHERE nr_rejestracyjny = '" + n + "'");
                car_id_new = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT Id_Cennika FROM Cenniki WHERE nazwa = '" + nm + "'");
                pri_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_type.Text) || string.IsNullOrWhiteSpace(txt_where_o.Text) || string.IsNullOrWhiteSpace(combo_car.Text) ||
                  string.IsNullOrWhiteSpace(date_o.Text))
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            else{

                get_inf();

                if (date_o.SelectedDate.Value < DateTime.Now)
                {
                    MessageBox.Show("Odbiór nie może odbyć się dzisiaj. Wprowadz nową datę i spróbuj ponownie.", "Błąd!");
                }
                else 
                { 
                    try
                    {
                        string date2 = Convert.ToDateTime(date_o.SelectedDate.Value).ToString("MM-dd-yyyy");

                        connection.openConnection();
                        connection.sql = "UPDATE Wynajmy SET Id_Cennika = '"+pri_id+"', Id_Samochodu='"+car_id_new+"', data_odbioru='"
                            + date2 + "', miejsce_odbioru='"+txt_where_o.Text+"', typ_wynajmu ='"+txt_type.Text +"' WHERE Id_Samochodu='"+car_id+"'";
                        connection.cmd.CommandType = CommandType.Text;
                        connection.cmd.CommandText = connection.sql;
                        connection.cmd.ExecuteNonQuery();
                        MessageBox.Show("Edycja została zakończona sukcesem.", "Komunikat.");
                        connection.closeConnection();
                        clear();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }

        
    }
}
