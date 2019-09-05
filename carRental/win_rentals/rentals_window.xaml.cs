using System;
using System.Collections.Generic;
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
using carRental.klasy;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using carRental.win_cars;
using carRental.win_customers;
using carRental.win_rentals;
using carRental.win_overview;
using carRental.win_finance;
using carRental.other;
using carRental.win_employees;

namespace carRental.win_rentals
{
    /// <summary>
    /// Logika interakcji dla klasy rentals_window.xaml
    /// </summary>
    public partial class rentals_window : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public rentals_window()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            open_Window();
        }

        // ============================================================================================================== \\

        void load_count_ongoing()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Wynajmu) FROM Wynajmy WHERE data_odbioru > GETDATE() AND data_wydania < GETDATE()";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_ongoing.Content = count;
        }

        void load_count_completed()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Wynajmu) FROM Wynajmy WHERE data_odbioru < GETDATE()";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_completed.Content = Convert.ToInt32(count);
        }


        void load_count_reservations()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Wynajmu) FROM Wynajmy WHERE data_wydania > GETDATE()";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_reservations.Content = Convert.ToString(count);
        }

        // ============================================================================================================== \\

        void click_buttons_background(byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7, byte c8, byte c9, byte o1, byte o2, byte o3, byte o4, byte o5, byte o6, byte o7, byte o8, byte o9)
        {
            btn_ongoing.Background = new SolidColorBrush(Color.FromRgb(c1, c2, c3));
            btn_completed.Background = new SolidColorBrush(Color.FromRgb(c4, c5, c6));
            btn_reservations.Background = new SolidColorBrush(Color.FromRgb(c7, c8, c9));

            btn_ongoing.Foreground = new SolidColorBrush(Color.FromRgb(o1, o2, o3));
            btn_completed.Foreground = new SolidColorBrush(Color.FromRgb(o4, o5, o6));
            btn_reservations.Foreground = new SolidColorBrush(Color.FromRgb(o7, o8, o9));
        }

        void click_lbl_freground(byte o1, byte o2, byte o3, byte o4, byte o5, byte o6, byte o7, byte o8, byte o9)
        {
            lbl_ongoing.Foreground = new SolidColorBrush(Color.FromRgb(o1, o2, o3));
            lbl_completed.Foreground = new SolidColorBrush(Color.FromRgb(o4, o5, o6));
            lbl_reservations.Foreground = new SolidColorBrush(Color.FromRgb(o7, o8, o9));
        }

        void buttons_image_source(string i1, string i2, string i3)
        {
            im1.Source = new BitmapImage(new Uri(i1, UriKind.Relative));
            im2.Source = new BitmapImage(new Uri(i2, UriKind.Relative));
            im3.Source = new BitmapImage(new Uri(i3, UriKind.Relative));
        }

        DataTable wynajem;

        void show_table(string txt)
        {
            try
            {
                connection.sql = "SELECT w.nr_zlecenia, w.typ_wynajmu, k.najemca, s.nr_rejestracyjny, s.marka, " +
                                 "s.model, w.data_wydania, w.miejsce_wydania, w.data_odbioru, " +
                                 "w.miejsce_odbioru, c.kwota_dobowa " +
                                 "FROM Wynajmy w, Klienci k, Cenniki c, Samochody s WHERE " +
                                 "w.Id_Klienta = k.Id_Klienta AND w.Id_Samochodu = s.Id_Samochodu AND " +
                                 "w.Id_Cennika = c.Id_Cennika " + txt;
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                //connection.da = new SqlDataAdapter();
                wynajem = new DataTable();
                connection.da.Fill(wynajem);
                dataGrid1.ItemsSource = wynajem.DefaultView;

            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }

            connection.closeConnection();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            DateTime dateValue = new DateTime(DateTime.Now.Day);
            lbl_time1.Content = d.Hour + " : " + d.Minute + " : " + d.Second + "   " + d.Day + " / " + d.Month + " / " + d.Year;

            //lbl_day.Content = dateValue.ToString("dddd", new CultureInfo("pl-PL"));
        }

        private void open_Window()
        {
            load_count_ongoing();
            load_count_completed();
            load_count_reservations();
            click_buttons_background(154, 191, 127, 232, 232, 232, 232, 232, 232, 255, 255, 255, 112, 112, 112, 112, 112, 112);
            click_lbl_freground(255, 255, 255, 112, 112, 112, 112, 112, 112);
            buttons_image_source("/carRental;component/pic/cal1b.png", "/carRental;component/pic/cal3.png", "/carRental;component/pic/cal2.png");
            show_table("AND data_odbioru > GETDATE() AND data_wydania < GETDATE()");
        }

        // ============================================================================================================== \\

        private void Btn_ongoing_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                click_buttons_background(154, 191, 127, 232, 232, 232, 232, 232, 232, 255, 255, 255, 112, 112, 112, 112, 112, 112);
                click_lbl_freground(255, 255, 255, 112, 112, 112, 112, 112, 112);
                buttons_image_source("/carRental;component/pic/cal1b.png", "/carRental;component/pic/cal3.png", "/carRental;component/pic/cal2.png");
                show_table("AND data_odbioru > GETDATE() AND data_wydania < GETDATE()");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_completed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                click_buttons_background(232, 232, 232, 154, 191, 127, 232, 232, 232, 112, 112, 112, 255, 255, 255, 112, 112, 112);
                click_lbl_freground(112, 112, 112, 255, 255, 255, 112, 112, 112);
                buttons_image_source("/carRental;component/pic/cal1.png", "/carRental;component/pic/cal3b.png", "/carRental;component/pic/cal2.png");
                show_table("AND data_odbioru < GETDATE()");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_reservations_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                click_buttons_background(232, 232, 232, 232, 232, 232, 154, 191, 127, 112, 112, 112, 112, 112, 112, 255, 255, 255);
                click_lbl_freground(112, 112, 112, 112, 112, 112, 255, 255, 255);
                buttons_image_source("/carRental;component/pic/cal1.png", "/carRental;component/pic/cal3.png", "/carRental;component/pic/cal2b.png");
                show_table("AND data_wydania > GETDATE()");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        // ============================================================================================================== \\

        private void Btn_rentals_Click(object sender, RoutedEventArgs e)
        {
            //im here
        }

        private void Btn_customers_Click(object sender, RoutedEventArgs e)
        {
            customers_window cw = new customers_window();
            this.Close();
            cw.ShowDialog();
        }

        private void Btn_cars_Click(object sender, RoutedEventArgs e)
        {
            cars_window carw = new cars_window();
            this.Close();
            carw.ShowDialog();
        }

        private void Btn_overview_Click(object sender, RoutedEventArgs e)
        {
            overview_window ovw = new overview_window();
            this.Close();
            ovw.ShowDialog();
        }

        private void Btn_finance(object sender, RoutedEventArgs e)
        {
            finance_window fw = new finance_window();
            this.Close();
            fw.ShowDialog();
        }

        private void Btn_employees_Click(object sender, RoutedEventArgs e)
        {
            employees_window ew = new employees_window();
            this.Close();
            ew.ShowDialog();
        }

        // ============================================================================================================== \\

        private void Btn_add_1_Click(object sender, RoutedEventArgs e)
        {
            add_new_window anw = new add_new_window();
            anw.ShowDialog();
        }


        private void Btn_add_r_Click(object sender, RoutedEventArgs e)
        {
            add_new_res_window anrw = new add_new_res_window();
            anrw.ShowDialog();
        }

        private void Btn_end_Click(object sender, RoutedEventArgs e)
        {
            end_window ew = new end_window();
            ew.ShowDialog();
        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            mod_window mw = new mod_window();
            mw.ShowDialog();
        }

        // ============================================================================================================== \\

        private void Txt_s1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("nr_zlecenia LIKE '%{0}%'", txt_s1.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s2_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("typ_wynajmu LIKE '%{0}%'", txt_s2.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("najemca LIKE '%{0}%'", txt_search.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s4_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("nr_rejestracyjny LIKE '%{0}%'", txt_s4.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s5_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("marka LIKE '%{0}%'", txt_s5.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s6_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("model LIKE '%{0}%'", txt_s6.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s7_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Concat("CONVERT(", "data_wydania", ",System.String) LIKE '%", txt_s7.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s8_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("miejsce_wydania LIKE '%{0}%'", txt_s8.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s9_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Concat("CONVERT(", "data_odbioru", ",System.String) LIKE '%", txt_s9.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s10_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Format("miejsce_odbioru LIKE '%{0}%'", txt_s10.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s11_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(wynajem);
            DV.RowFilter = string.Concat("CONVERT(", "kwota_dobowa", ",System.String) LIKE '%", txt_s11.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        // ============================================================================================================== \\

        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            open_Window();
            MessageBox.Show("Odświeżenie otwartej karty zostało zakończone sukcesem.", "Komunikat.");
        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            logout_window lw = new logout_window();
            lw.ShowDialog();
        }


    }

}