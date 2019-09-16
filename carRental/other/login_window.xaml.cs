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

namespace carRental.other
{
    /// <summary>
    /// Logika interakcji dla klasy login_window.xaml
    /// </summary>
    /// 
    public partial class login_window : Window
    {
        public int box;

        public login_window()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            connection.openConnection();
            connection.sql = "SELECT COUNT(1) FROM UserTb WHERE login=@login AND password=@password";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            connection.cmd.Parameters.AddWithValue("@login", txt_login.Text);
            connection.cmd.Parameters.AddWithValue("@password", txt_password.Password);

            int count = Convert.ToInt32(connection.cmd.ExecuteScalar());

            if (count == 1)
            {
               
                win_rentals.rentals_window rw = new win_rentals.rentals_window();

                this.Close();
                rw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Podany login lub hasło jest błędne. Spróbuj ponownie", "Komunikat.");
            }
            connection.closeConnection();
        }

        private void Btn_a_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            win_rentals.rentals_window rw = new win_rentals.rentals_window();

            this.Close();
            rw.ShowDialog();
        }

    }
}
