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

namespace carRental.win_employees
{
    /// <summary>
    /// Logika interakcji dla klasy add_emp_window.xaml
    /// </summary>
    public partial class add_emp_window : Window
    {
        public add_emp_window()
        {
            InitializeComponent();
            start_window();
        }

        int id;

        private void combo_s_items()
        {
            combo_s.Items.Add("kierowca");
            combo_s.Items.Add("specjalista");
            combo_s.Items.Add("handlowiec");
        }

        private void start_window()
        {
            combo_s_items();
        }

        private void get_id() {
            data_conn("SELECT Id_User FROM UserTb WHERE login = '" + txt_login.Text + "'");
            id = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
        }

        private void add_new_emp()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_no.Text) || string.IsNullOrWhiteSpace(txt_pes.Text) ||
                    string.IsNullOrWhiteSpace(combo_s.Text) || string.IsNullOrWhiteSpace(date_od.Text) || string.IsNullOrWhiteSpace(txt_login.Text) || string.IsNullOrWhiteSpace(txt_password.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola i spróbuj ponownie.", "Błąd!");
            }
            else
            { //wszystkie uzup

                try
                {
                    connection.openConnection();
                    connection.sql = "SELECT count(*) FROM UserTb WHERE login='"+txt_login.Text+"'";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    int count = Convert.ToInt32(connection.cmd.ExecuteScalar());
                    connection.closeConnection();
                    if (count != 0)
                    { //taki login już jest
                        MessageBox.Show("Podany login już istnieje. Spróbuj ponownie.", "Błąd!");
                        connection.closeConnection();
                    }
                    else if(count == 0)
                    { //nie ma takiego loginu - idziemy dalej
                        try
                        {
                            connection.openConnection();
                            connection.sql = "INSERT INTO UserTb(login, password) values('" + txt_login.Text + "','" + txt_password.Text + "')";
                            connection.cmd.CommandType = CommandType.Text;
                            connection.cmd.CommandText = connection.sql;
                            connection.cmd.ExecuteNonQuery();
                            connection.closeConnection();
                            get_id();
                            try
                            {
                                connection.openConnection();
                                string stan = Convert.ToString(combo_s.SelectedItem);
                                string date = Convert.ToDateTime(date_od.SelectedDate.Value).ToString("MM-dd-yyyy");
                                connection.sql = "INSERT INTO Pracownicy(imie_nazwisko, pesel, nr_relefonu, zatrudniony_od, stanowisko, Id_User, status) values('" + txt_name.Text + "','" + txt_pes.Text + "','" +
                                    txt_no.Text + "','" + date + "','" + stan + "','" + id + "','zatrudniony')";
                                connection.cmd.CommandType = CommandType.Text;
                                connection.cmd.CommandText = connection.sql;
                                connection.cmd.ExecuteNonQuery();
                                MessageBox.Show("Nowy pracownik został dodany do bazy.", "Komunikat.");
                                connection.closeConnection();
                                clear();
                                start_window();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                                connection.closeConnection();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                            connection.closeConnection();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
                    connection.closeConnection();
                }
            }
        }

        private void clear()
        {
            try
            {
                txt_login.Text = null;
                txt_name.Text = null;
                txt_no.Text = null;
                txt_password.Text = null;
                txt_pes.Text = null;
                date_od.Text = null;
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

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            add_new_emp();
        }
    }
}
