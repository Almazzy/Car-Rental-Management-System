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

namespace carRental.win_customers
{
    /// <summary>
    /// Logika interakcji dla klasy add_new_user_window.xaml
    /// </summary>
    public partial class add_new_user_window : Window
    {
        public add_new_user_window()
        {
            InitializeComponent();
            start_window();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_new_client();
        }

        private void combo_type_items()
        {
            combo_type.Items.Add("indywidualny");
            combo_type.Items.Add("firma");
        }

        private void start_window()
        {
            combo_type_items();
        }

        private void add_new_client()
        {
            string type = Convert.ToString(combo_type.SelectedItem);
            if (type == "indywidualny")
            {
                if (string.IsNullOrWhiteSpace(txt_address.Text) || string.IsNullOrWhiteSpace(txt_cl.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
               string.IsNullOrWhiteSpace(txt_naj.Text) || string.IsNullOrWhiteSpace(txt_no_d.Text) || string.IsNullOrWhiteSpace(txt_no_p.Text) ||
               string.IsNullOrWhiteSpace(txt_number1.Text) || string.IsNullOrWhiteSpace(txt_pes.Text) || string.IsNullOrWhiteSpace(combo_type.Text))
                {
                    MessageBox.Show("Podczas dodawania nowego klienta indywidualnego, wszystkie pola poza NIPem oraz dodatkowym numerem telefonu są wymagane.", "Błąd!");
                }
                else
                {
                    try
                    {
                        connection.openConnection();
                        connection.sql = "INSERT INTO Klienci(typ_klienta, najemca, uzytkownik, nr_prawa_jazdy, nr_dowodu, adres_zameldowania, " +
                            "nr_telefonu, email, pesel) values ('" + type + "','" + txt_naj.Text + "','" + txt_cl.Text + "','" + txt_no_p.Text + "','" + txt_no_d.Text +
                            "','" + txt_address.Text + "','" + txt_number1.Text + "','" + txt_email.Text + "','" + txt_pes.Text + "')";
                        connection.cmd.CommandType = CommandType.Text;
                        connection.cmd.CommandText = connection.sql;
                        connection.cmd.ExecuteNonQuery();
                        MessageBox.Show("Poprawnie dodanow nowego klienta (indywidualnego).", "Komunikat.");
                        connection.closeConnection();
                        clear();
                        start_window();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else if (type == "firma")
            {
                if (string.IsNullOrWhiteSpace(txt_address.Text) || string.IsNullOrWhiteSpace(txt_cl.Text) || string.IsNullOrWhiteSpace(txt_email.Text) ||
              string.IsNullOrWhiteSpace(txt_naj.Text) || string.IsNullOrWhiteSpace(txt_no_d.Text) || string.IsNullOrWhiteSpace(txt_no_p.Text) ||
              string.IsNullOrWhiteSpace(txt_number1.Text) || string.IsNullOrWhiteSpace(txt_pes.Text) || string.IsNullOrWhiteSpace(combo_type.Text) ||
              string.IsNullOrWhiteSpace(txt_nip.Text))
                {
                    MessageBox.Show("Podczas dodawania nowego klienta typu firma, wszystkie pola poza dodatkowym numerem telefonu są wymagane.", "Błąd!");
                }
                else
                {
                    try
                    {
                        connection.openConnection();
                        connection.sql = "INSERT INTO Klienci(typ_klienta, najemca, uzytkownik, nr_prawa_jazdy, nr_dowodu, adres_zameldowania, " +
                            "nr_telefonu, email, pesel, nip) values ('" + type + "','" + txt_naj.Text + "','" + txt_cl.Text + "','" + txt_no_p.Text + "','" + txt_no_d.Text +
                            "','" + txt_address.Text + "','" + txt_number1.Text + "','" + txt_email.Text + "','" + txt_pes.Text + "','" + txt_nip.Text + "')";
                        connection.cmd.CommandType = CommandType.Text;
                        connection.cmd.CommandText = connection.sql;
                        connection.cmd.ExecuteNonQuery();
                        MessageBox.Show("Poprawnie dodanow nowego klienta (firmę).", "Komunikat.");
                        connection.closeConnection();
                        clear();
                        start_window();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void clear()
        {
            try
            {
                txt_address.Text = null;
                txt_cl.Text = null;
                txt_email.Text = null;
                txt_naj.Text = null;
                txt_nip.Text = null;
                txt_no_d.Text = null;
                txt_no_p.Text = null;
                txt_number1.Text = null;
                txt_number2.Text = null;
                txt_pes.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
