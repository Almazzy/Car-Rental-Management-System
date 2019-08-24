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
    /// Logika interakcji dla klasy del_emp_window.xaml
    /// </summary>
    public partial class del_emp_window : Window
    {
        public del_emp_window()
        {
            InitializeComponent();
            combo_emp_items();
        }

        int help2, emp_id;

        private void Btn_end_step2_Click(object sender, RoutedEventArgs e)
        {
            if (help2 == 0)//nie potwierdzono 
            {
                MessageBox.Show("Dezaktywacja pracownika musi być potwierdzona.", "Komunikat");
            }
            else if (help2 == 1)
            { //potwierdzno
                try
                {
                    string n = Convert.ToString(combo_emp.SelectedItem);

                    connection.openConnection();
                    connection.sql = "UPDATE Pracownicy SET status = 'niezatrudniony' where Id_Pracownika = '" + emp_id + "'";
                    connection.cmd.CommandType = CommandType.Text;
                    connection.cmd.CommandText = connection.sql;
                    connection.cmd.ExecuteNonQuery();
                    connection.closeConnection();

                    clear();
                    MessageBox.Show("Pracownik został dezaktywowany.", "Komunikat");
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
            if (Convert.ToString(lbl_inf5.Content) == "zatrudniony")
            {
                MessageBox.Show("Aby zakończyć i potwierdzić dezaktywacje pracownika kliknij 'dezaktywuj'.", "Komunikat");
                help2 = 1;
            }
            else
            {
                MessageBox.Show("Dezaktywować można tylko pracownika, który jest wolny.", "Komunikat");
            }

        }

        private void clear()
        {
            lbl_inf4.Content = null;
            lbl_inf5.Content = null;
            lbl_inf1.Content = null;
            lbl_inf2.Content = null;
            lbl_inf3.Content = null;
            combo_emp.Text = null;
        }

        private void Combo_car_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string n = Convert.ToString(combo_emp.SelectedItem);
                data_conn("SELECT pesel FROM pracownicy WHERE imie_nazwisko = '" + n + "'");
                lbl_inf1.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT nr_relefonu FROM pracownicy WHERE imie_nazwisko = '" + n + "'");
                lbl_inf2.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT stanowisko FROM pracownicy WHERE imie_nazwisko = '" + n + "'");
                lbl_inf3.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                data_conn("SELECT zatrudniony_od FROM pracownicy WHERE imie_nazwisko = '" + n + "'");
                DateTime data_do = (DateTime)connection.cmd.ExecuteScalar();
                lbl_inf4.Content = Convert.ToString(data_do);
                connection.closeConnection();
                data_conn("SELECT status FROM pracownicy WHERE imie_nazwisko = '" + n + "'");
                lbl_inf5.Content = (string)connection.cmd.ExecuteScalar();
                connection.closeConnection();
                if (Convert.ToString(lbl_inf5.Content) == "zatrudniony" )
                {
                    lbl_inf5.Foreground = new SolidColorBrush(Color.FromRgb(50, 240, 20));
                }
                data_conn("SELECT Id_Pracownika FROM Pracownicy WHERE imie_nazwisko = '" + n + "' ");
                emp_id = (int)connection.cmd.ExecuteScalar();
                connection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "Komunikat o błędzie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void combo_emp_items()
        {
            connection.openConnection();
            connection.sql = ("SELECT * FROM Pracownicy WHERE status = 'zatrudniony'");
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.rd = connection.cmd.ExecuteReader();

            while (connection.rd.Read())
            {
                string nr = connection.rd.GetString(connection.rd.GetOrdinal("imie_nazwisko"));
                combo_emp.Items.Add(nr);
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
