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
using carRental.other;

namespace carRental.win_finance
{
    /// <summary>
    /// Logika interakcji dla klasy add_new_inv_window.xaml
    /// </summary>
    public partial class add_new_inv_window : Window
    {

        string today;
        int id_p, id_w;

        public add_new_inv_window()
        {
            InitializeComponent();
            Start_window();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Add_new_inv();
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        // ----

        private void Combo_payment_method_items()
        {
            combo_payment.Items.Add("gotówka");
            combo_payment.Items.Add("karta płatnicza");
            combo_payment.Items.Add("przelew");
        }

        private void Combo_no_items()
        {
            try
            {
                connection.openConnection();
                connection.sql = "SELECT * FROM Wynajmy WHERE faktura = 'brak' AND data_odbioru < GETDATE()";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                connection.rd = connection.cmd.ExecuteReader();
                while (connection.rd.Read())
                {
                    string no = connection.rd.GetString(connection.rd.GetOrdinal("nr_zlecenia"));
                    combo_no.Items.Add(no);
                }
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Combo_emp_items()
        {
            try
            {
                connection.openConnection();
                connection.sql = "SELECT * FROM Pracownicy WHERE status = 'zatrudniony'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                connection.rd = connection.cmd.ExecuteReader();
                while (connection.rd.Read())
                {
                    string no = connection.rd.GetString(connection.rd.GetOrdinal("imie_nazwisko"));
                    combo_emp.Items.Add(no);
                }
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Start_window()
        {
            Combo_no_items();
            Combo_payment_method_items();
            Combo_emp_items();
        }

        private void Clear()
        {
            txt_day.Text = null;
            txt_no.Text = null;
            txt_txt.Text = null;
            combo_emp.Text = null;
            combo_no.Text = null;
            combo_payment.Text = null;
        }

        private void Change_w()
        {
            try
            {
                connection.openConnection();
                connection.sql = "UPDATE Wynajmy SET faktura = 'wygenerowana' where Id_Wynajmu= '" + id_w + "'";
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

        private void Date()
        {
            DateTime d;
            d = DateTime.Now;
            DateTime dateValue = new DateTime(DateTime.Now.Day);
            today = d.Month + "-" + d.Day + "-" + d.Year;
        }

        private void Get_Id()
        {
            try
            {
                connection.openConnection();
                connection.sql = "SELECT Id_Wynajmu FROM Wynajmy WHERE nr_zlecenia = '" + Convert.ToString(combo_no.SelectedItem) + "'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                id_w = Convert.ToInt32(connection.cmd.ExecuteScalar());
                connection.closeConnection();

                connection.openConnection();
                connection.sql = "SELECT Id_Pracownika FROM Pracownicy WHERE imie_nazwisko = '" + Convert.ToString(combo_emp.SelectedItem) + "'";
                connection.cmd.CommandType = CommandType.Text;
                connection.cmd.CommandText = connection.sql;
                id_p = Convert.ToInt32(connection.cmd.ExecuteScalar());
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Combo_no_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string n = Convert.ToString(combo_no.SelectedItem);
            data_conn("SELECT s.nr_rejestracyjny FROM Wynajmy w, Samochody s WHERE w.Id_Samochodu = s.Id_Samochodu AND w.nr_zlecenia = '" + n + "'");
            l1.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            data_conn("SELECT s.marka FROM Wynajmy w, Samochody s WHERE w.Id_Samochodu = s.Id_Samochodu AND w.nr_zlecenia = '" + n + "'");
            l2.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            data_conn("SELECT s.model FROM Wynajmy w, Samochody s WHERE w.Id_Samochodu = s.Id_Samochodu AND w.nr_zlecenia = '" + n + "'");
            l3.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            data_conn("SELECT k.najemca FROM Wynajmy w, Klienci k WHERE w.Id_Klienta = k.Id_Klienta AND w.nr_zlecenia = '" + n + "'");
            l4.Content = (string)connection.cmd.ExecuteScalar();
            connection.closeConnection();
        }

        private void Add_new_inv()
        {
            if (string.IsNullOrWhiteSpace(txt_day.Text) || string.IsNullOrWhiteSpace(txt_no.Text) || string.IsNullOrWhiteSpace(txt_txt.Text) ||
                string.IsNullOrWhiteSpace(date_payment.Text) || string.IsNullOrWhiteSpace(combo_payment.Text) || string.IsNullOrWhiteSpace(combo_no.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            }
            else
            { // wszystkie pola uzupelnione:
                try
                {
                    string payMeth = Convert.ToString(combo_payment.SelectedItem);
                    string payDate = Convert.ToDateTime(date_payment.SelectedDate.Value).ToString("MM-dd-yyyy");

                    Date();
                    Get_Id();


                    connection.openConnection();
                    connection.sql = "INSERT INTO Faktury(nr_faktury, Id_Pracownika, Id_Wynajmu, data_wystawienia, sposob_platnosci, termin_platnosci, usluga, suma_dni) values('" +
                        txt_no.Text + "','" + id_p + "','" + id_w + "','" + today + "','" + payMeth + "','" + payDate + "','" + txt_txt.Text + "','" + txt_day.Text + "')";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    MessageBox.Show("Poprawnie wygenerowano nową fakturę.", "Komunikat.");
                    connection.closeConnection();
                    Change_w();
                    Clear();
                    Start_window();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
