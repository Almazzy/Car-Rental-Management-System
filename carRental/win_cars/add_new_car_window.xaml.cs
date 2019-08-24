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
    /// Logika interakcji dla klasy add_new_car_window.xaml
    /// </summary>
    public partial class add_new_car_window : Window
    {
        public add_new_car_window()
        {
            InitializeComponent();
            start_window();
        }

        string fuel;

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_new_car();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //btn_add_new_ov click
        {
            win_overview.new_p_window npw = new win_overview.new_p_window();
            npw.ShowDialog();
            combo_ov_items();
        }

        private void Btn_add_new_pol_Click(object sender, RoutedEventArgs e)
        {
            win_overview.new_ub_window nuw = new win_overview.new_ub_window();
            nuw.ShowDialog();
            combo_pol_items();
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // -----------------------------

        private void combo_items(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();
        }

        private void data_conn(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
        }

        private void combo_pol_items()
        {
            combo_items("SELECT * FROM Polisy WHERE status = 'nieprzypisana'");
            while (connection.rd.Read())
            {
                int n = connection.rd.GetInt32(connection.rd.GetOrdinal("Id_Polisy"));
                string nr = Convert.ToString(n);
                combo_pol.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_ov_items()
        {
            combo_items("SELECT * FROM Przeglady WHERE status = 'nieprzypisany'");
            while (connection.rd.Read())
            {
                int n = connection.rd.GetInt32(connection.rd.GetOrdinal("Id_Przegladu"));
                string nr = Convert.ToString(n);
                combo_ov.Items.Add(nr);
            }
            connection.closeConnection();
        }

        private void combo_class_items()
        {
            combo_class.Items.Add("A");
            combo_class.Items.Add("B");
            combo_class.Items.Add("C");
            combo_class.Items.Add("D");
            combo_class.Items.Add("E");
            combo_class.Items.Add("P");
            combo_class.Items.Add("SUV");
            combo_class.Items.Add("VIN");
        }

        private void combo_type_items()
        {
            combo_type.Items.Add("hatchback");
            combo_type.Items.Add("sedan");
            combo_type.Items.Add("kombi");
            combo_type.Items.Add("coupe");
            combo_type.Items.Add("VAN");
            combo_type.Items.Add("SUV");
        }

        private void combo_fuel_items()
        {
            combo_fuel.Items.Add("Diesel");
            combo_fuel.Items.Add("Benzyna");
            combo_fuel.Items.Add("Benzyna / Gaz");
        }

        private void combo_s_items()
        {
            combo_s.Items.Add("wolny");
            combo_s.Items.Add("dyzur");
        }

        private void start_window()
        {
            combo_pol_items();
            combo_ov_items();
            combo_class_items();
            combo_type_items();
            combo_fuel_items();
            combo_s_items();
        }

        private void add_new_car()
        {
            if (string.IsNullOrWhiteSpace(txt_mark.Text) || string.IsNullOrWhiteSpace(txt_model.Text) ||
                string.IsNullOrWhiteSpace(txt_vin.Text) || string.IsNullOrWhiteSpace(txt_no.Text) ||
                string.IsNullOrWhiteSpace(txt_year.Text) || string.IsNullOrWhiteSpace(txt_engine.Text) ||
                string.IsNullOrWhiteSpace(combo_class.Text) || string.IsNullOrWhiteSpace(combo_fuel.Text) ||
                string.IsNullOrWhiteSpace(combo_ov.Text) || string.IsNullOrWhiteSpace(combo_pol.Text) ||
                string.IsNullOrWhiteSpace(combo_s.Text) || string.IsNullOrWhiteSpace(combo_type.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            }
            else
            { // wszystkie pola uzupelnione:
                try
                {
                    string type = Convert.ToString(combo_type.SelectedItem);
                    string s = Convert.ToString(combo_s.SelectedItem);
                    string cl = Convert.ToString(combo_class.SelectedItem);
                    int id_o = Convert.ToInt32(combo_ov.SelectedItem);
                    int id_p = Convert.ToInt32(combo_pol.SelectedItem);
                    get_f();

                    connection.openConnection();
                    connection.sql = "INSERT INTO Samochody(nr_rejestracyjny, vin, marka, model, rok_produkcji, " +
                        " pojemnosc, paliwo, typ, Id_Przegladu, Id_Polisy, stan, klasa, aktywnosc) values ('" +
                        txt_no.Text + "','" + txt_vin.Text + "','" + txt_mark.Text + "','" + txt_model.Text + "','" +
                        txt_year.Text + "','" + txt_engine.Text + "','" + fuel + "','" + type + "','" + id_o + "','" + id_p + "','" +
                        s + "','" + cl + "','aktywny')";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    MessageBox.Show("Poprawnie dodano nowy samochód.", "Komunikat.");
                    connection.closeConnection();
                    clear();
                    change_pol_ub();
                    start_window();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void change_pol_ub()
        {
            try
            {
                int id_o = Convert.ToInt32(combo_ov.SelectedItem);
                int id_p = Convert.ToInt32(combo_pol.SelectedItem);

                connection.openConnection();
                connection.sql = "UPDATE Polisy SET status = 'zajeta' where Id_Polisy = '" + id_p + "'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                connection.cmd.ExecuteNonQuery();
                connection.closeConnection();

                connection.openConnection();
                connection.sql = "UPDATE Przeglady SET status = 'zajety' where Id_Przegladu = '" + id_o + "'";
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

        private void get_f()
        {
            try
            {
                string f = Convert.ToString(combo_fuel.SelectedItem);
                if (f == "Benzyna") fuel = "B";
                else if (f == "Diesel") fuel = "D";
                else if (f == "Benzyna / Gaz") fuel = "B/G";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Combo_pol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string n = Convert.ToString(combo_pol.SelectedItem);
            data_conn("SELECT data_od FROM Polisy WHERE Id_Polisy = '" + n + "'");
            DateTime data_od = (DateTime)connection.cmd.ExecuteScalar();
            lbl_p_start.Content = Convert.ToString(data_od);
            connection.closeConnection();
            data_conn("SELECT data_do FROM Polisy WHERE Id_Polisy = '" + n + "'");
            DateTime data_do = (DateTime)connection.cmd.ExecuteScalar();
            lbl_p_end.Content = Convert.ToString(data_do);
            connection.closeConnection();
            data_conn("SELECT notatka FROM Polisy WHERE Id_Polisy = '" + n + "'");
            txtb_p_txt.Text = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            data_conn("SELECT ubezpieczyciel FROM Polisy WHERE Id_Polisy = '" + n + "'");
            lbl_p_name.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
        }

        private void Combo_ov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string n = Convert.ToString(combo_ov.SelectedItem);
            data_conn("SELECT data_od FROM Przeglady WHERE Id_Przegladu = '" + n + "'");
            DateTime data_od = (DateTime)connection.cmd.ExecuteScalar();
            lbl_o_start.Content = Convert.ToString(data_od);
            connection.closeConnection();
            data_conn("SELECT data_doo FROM Przeglady WHERE Id_Przegladu = '" + n + "'");
            DateTime data_do = (DateTime)connection.cmd.ExecuteScalar();
            lbl_o_end.Content = Convert.ToString(data_do);
            connection.closeConnection();
            data_conn("SELECT notatka FROM Przeglady WHERE Id_Przegladu = '" + n + "'");
            txtb_o_txt.Text = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            data_conn("SELECT miejsce_wykonania FROM Przeglady WHERE Id_Przegladu = '" + n + "'");
            lbl_o_name.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
        }

        private void clear()
        {
            try
            {
                txt_no.Text = null;
                txt_mark.Text = null;
                txt_model.Text = null;
                txt_vin.Text = null;
                txt_engine.Text = null;
                txt_year.Text = null;
                combo_class.Text = null;
                combo_s.Text = null;
                combo_fuel.Text = null;
                combo_type.Text = null;
                //--
                lbl_o_name.Content = null;
                lbl_p_name.Content = null;
                lbl_o_end.Content = null;
                lbl_p_end.Content = null;
                lbl_o_start.Content = null;
                lbl_p_start.Content = null;
                txtb_p_txt.Text = null;
                txtb_o_txt.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
