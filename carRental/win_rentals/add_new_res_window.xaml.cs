using carRental.klasy;
using carRental.win_customers;
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
    /// Logika interakcji dla klasy add_new_res_window.xaml
    /// </summary>
    public partial class add_new_res_window : Window
    {
        public add_new_res_window()
        {
            InitializeComponent();
            combo_show();
        }

        int car_id, cus_id, pri_id, emp_id;

        private void check_widget()
        {

            if (string.IsNullOrWhiteSpace(txt_number.Text) || string.IsNullOrWhiteSpace(txt_type.Text) || string.IsNullOrWhiteSpace(date_w.Text) ||
                string.IsNullOrWhiteSpace(txt_where_o.Text) || string.IsNullOrWhiteSpace(txt_where_w.Text) || string.IsNullOrWhiteSpace(combo_car.Text) ||
                string.IsNullOrWhiteSpace(combo_customer.Text) || string.IsNullOrWhiteSpace(combo_price.Text) || string.IsNullOrWhiteSpace(date_o.Text))
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            else
            { //wszystkie pola uzupelione

                get_inf();
                
                if (date_o.SelectedDate.Value < date_w.SelectedDate.Value && date_w.SelectedDate.Value > DateTime.Now)
                {
                    MessageBox.Show("Data odbioru nie może być mniejsza niż data wydania.", "Błąd!");
                }
                else
                { //data odbioru > niż wydania
                    try
                    {
                        string date1 = Convert.ToDateTime(date_w.SelectedDate.Value).ToString("MM-dd-yyyy");
                        string date2 = Convert.ToDateTime(date_o.SelectedDate.Value).ToString("MM-dd-yyyy");

                        connection.openConnection();
                        connection.sql = "INSERT INTO Wynajmy(Id_Klienta, Id_Samochodu, Id_Cennika, nr_zlecenia, " +
                            "typ_wynajmu, data_wydania, miejsce_wydania, data_odbioru, miejsce_odbioru, Id_Prac_Odp) " +
                            "values ('" + cus_id + "','" + car_id + "','" + pri_id + "','" + txt_number.Text + "','" +
                            txt_type.Text + "','" + date1 + "','" + txt_where_w.Text +
                            "','" + date2 + "','" + txt_where_o.Text + "','" + emp_id + "')";
                        connection.cmd.CommandType = CommandType.Text;
                        connection.cmd.CommandText = connection.sql;
                        connection.cmd.ExecuteNonQuery();
                        MessageBox.Show("Poprawnie dodano nową rezerwację.", "Komunikat.");
                        connection.closeConnection();
                        c_car();
                        clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }
        }

        private void combo_items(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();
        }

        

        private void combo_car_items()
        {
            combo_items("SELECT * FROM Samochody WHERE stan = 'wolny' AND aktywnosc = 'aktywny'");
            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nr_rejestracyjny"));
                combo_car.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_customer_items()
        {
            combo_items("SELECT * FROM Klienci");
            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("najemca"));
                combo_customer.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_price_items()
        {
            combo_items("SELECT * FROM Cenniki");
            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("nazwa"));
                combo_price.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_emp_items()
        {
            combo_items("SELECT * FROM Pracownicy WHERE status = 'zatrudniony' AND stanowisko = 'kierowca' OR stanowisko = 'specjalista'");
            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("imie_nazwisko"));
                combo_emp.Items.Add(nr);
            }
            connection.closeConnection();
        }

        public void combo_show()
        {
            combo_car_items();
            combo_customer_items();
            combo_price_items();
            combo_emp_items();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            check_widget();
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            combo_show();
            clear();
        }

        private void Combo_car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string n = Convert.ToString(combo_car.SelectedItem);
            data_conn("SELECT marka FROM samochody WHERE nr_rejestracyjny = '" + n + "' AND aktywnosc = 'aktywny'");
            lbl_car1.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            data_conn("SELECT model FROM samochody WHERE nr_rejestracyjny = '" + n + "' AND aktywnosc = 'aktywny'");
            lbl_car2.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();

        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_add_new_client_Click(object sender, RoutedEventArgs e)
        {
            add_new_user_window anuw = new add_new_user_window();
            anuw.ShowDialog();
            combo_customer_items();
        }

        private void get_inf()
        {
            try
            {
                string n = Convert.ToString(combo_car.SelectedItem);
                string mn = Convert.ToString(combo_emp.SelectedItem);
                string nm = Convert.ToString(combo_price.SelectedItem);
                string m = Convert.ToString(combo_customer.SelectedItem);

                data_conn("SELECT Id_Samochodu FROM Samochody WHERE nr_rejestracyjny = '" + n + "'");
                car_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT Id_Klienta FROM Klienci WHERE najemca = '" + m + "'");
                cus_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT Id_Pracownika FROM Pracownicy WHERE imie_nazwisko = '" + mn + "'");
                emp_id = (int)connection.cmd.ExecuteScalar();
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

        private void c_car()
        {
            try
            {
                connection.openConnection();
                connection.sql = "UPDATE Samochody SET stan = 'rezerwacja' where Id_Samochodu = '" + car_id + "'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                connection.cmd.ExecuteNonQuery();
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
            txt_number.Text = null;
            txt_type.Text = null;
            txt_where_o.Text = null;
            txt_where_w.Text = null;
            date_o.Text = null;
            date_w.Text = null;
            combo_car.Text = null;
            combo_customer.Text = null;
            combo_emp.Text = null;
            combo_price.Text = null;
        }
    }
}
