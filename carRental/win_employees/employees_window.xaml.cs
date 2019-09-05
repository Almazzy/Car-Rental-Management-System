using carRental.klasy;
using carRental.other;
using carRental.win_cars;
using carRental.win_customers;
using carRental.win_finance;
using carRental.win_overview;
using carRental.win_rentals;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Logika interakcji dla klasy employees_window.xaml
    /// </summary>
    public partial class employees_window : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public employees_window()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();


            open_Window();
        }

        // ============================================================================================================== \\

        private void Btn_rentals_Click(object sender, RoutedEventArgs e)
        {
            rentals_window rw = new rentals_window();
            this.Close();
            rw.ShowDialog();
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

        private void Btn_finance_Click(object sender, RoutedEventArgs e)
        {
            finance_window fw = new finance_window();
            this.Close();
            fw.ShowDialog();
        }

        private void Btn_employees_Click(object sender, RoutedEventArgs e)
        {
            //im here
        }

        // ============================================================================================================== \\

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            DateTime dateValue = new DateTime(DateTime.Now.Day);
            lbl_time1.Content = d.Hour + " : " + d.Minute + " : " + d.Second + "   " + d.Day + " / " + d.Month + " / " + d.Year;
        }

        DataTable emp;

        void show_table(string txt)
        {
            try
            {
                connection.sql = "SELECT p.imie_nazwisko, p.pesel, p.nr_relefonu, p.zatrudniony_od, p.stanowisko, u.login, p.status FROM Pracownicy p, UserTb u WHERE " +
                    " p.Id_User = u.Id_User " + txt;
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                //connection.da = new SqlDataAdapter();
                emp = new DataTable();
                connection.da.Fill(emp);
                dataGrid1.ItemsSource = emp.DefaultView;

            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }

            connection.closeConnection();
        }

        void buttons_click_colors(Button b1, Button b2, Button b3, Button b4, Button b5, Label l1, Label l2,
           Label l3, Label l4, Label l5, string i1, string i2, string i3, string i4, string i5)
        {
            b1.Background = new SolidColorBrush(Color.FromRgb(127, 177, 191));
            b2.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b3.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b4.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b5.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));

            b1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            b2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b3.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b4.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b5.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));

            l1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l3.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l4.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l5.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));

            im1.Source = new BitmapImage(new Uri(i1, UriKind.Relative));
            im2.Source = new BitmapImage(new Uri(i2, UriKind.Relative));
            im3.Source = new BitmapImage(new Uri(i3, UriKind.Relative));
            im4.Source = new BitmapImage(new Uri(i4, UriKind.Relative));
            im5.Source = new BitmapImage(new Uri(i5, UriKind.Relative));
        }

        private void open_Window()
        {
            load_count_all_w();
            load_count_all_nw();
            load_count_all_k();
            load_count_all_s();
            load_count_all_h();
            buttons_click_colors(btn_all_w, btn_all_nw, btn_all_k, btn_all_s, btn_all_h, lbl_all_w, lbl_all_nw, lbl_all_k, lbl_all_s, lbl_all_h,
                "/carRental;component/pic/emp/pzbb.png", "/carRental;component/pic/emp/zss.png", "/carRental;component/pic/emp/ws.png",
                "/carRental;component/pic/emp/ss.png", "/carRental;component/pic/emp/hs.png");
            show_table(" AND p.status = 'zatrudniony'");
        }

        // ============================================================================================================== \\

        private void Btn_all_w_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_w, btn_all_nw, btn_all_k, btn_all_s, btn_all_h, lbl_all_w, lbl_all_nw, lbl_all_k, lbl_all_s, lbl_all_h,
                "/carRental;component/pic/emp/pzbb.png", "/carRental;component/pic/emp/zss.png", "/carRental;component/pic/emp/ws.png",
                "/carRental;component/pic/emp/ss.png", "/carRental;component/pic/emp/hs.png");
                show_table(" AND status = 'zatrudniony'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_all_nw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_nw, btn_all_w, btn_all_k, btn_all_s, btn_all_h, lbl_all_nw, lbl_all_w, lbl_all_k, lbl_all_s, lbl_all_h,
                "/carRental;component/pic/emp/pzss.png", "/carRental;component/pic/emp/zbb.png", "/carRental;component/pic/emp/ws.png",
                "/carRental;component/pic/emp/ss.png", "/carRental;component/pic/emp/hs.png");
                show_table(" AND status = 'niezatrudniony'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_all_k_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_k, btn_all_w, btn_all_nw, btn_all_s, btn_all_h, lbl_all_k, lbl_all_w, lbl_all_nw, lbl_all_s, lbl_all_h,
                "/carRental;component/pic/emp/pzss.png", "/carRental;component/pic/emp/zss.png", "/carRental;component/pic/emp/wb.png",
                "/carRental;component/pic/emp/ss.png", "/carRental;component/pic/emp/hs.png");
                show_table(" AND status = 'zatrudniony' AND stanowisko = 'kierowca'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_all_s_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_s, btn_all_w, btn_all_nw, btn_all_k, btn_all_h, lbl_all_s, lbl_all_w, lbl_all_nw, lbl_all_k, lbl_all_h,
                "/carRental;component/pic/emp/pzss.png", "/carRental;component/pic/emp/zss.png", "/carRental;component/pic/emp/ws.png",
                "/carRental;component/pic/emp/sb.png", "/carRental;component/pic/emp/hs.png");
                show_table(" AND status = 'zatrudniony' AND stanowisko = 'specjalista'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_all_h_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_h, btn_all_w, btn_all_nw, btn_all_k, btn_all_s, lbl_all_h, lbl_all_w, lbl_all_nw, lbl_all_k, lbl_all_s,
                "/carRental;component/pic/emp/pzss.png", "/carRental;component/pic/emp/zss.png", "/carRental;component/pic/emp/ws.png",
                "/carRental;component/pic/emp/ss.png", "/carRental;component/pic/emp/hb.png");
                show_table(" AND status = 'zatrudniony' AND stanowisko = 'handlowiec'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        // ============================================================================================================== \\

        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
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

        // ============================================================================================================== \\

        private void Txt_s1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Format("imie_nazwisko LIKE '%{0}%'", txt_s1.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s2_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Format("pesel LIKE '%{0}%'", txt_s2.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s3_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Format("nr_telefonu LIKE '%{0}%'", txt_s3.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s4_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Format("CONVERT(", "zatrudniony_od", ",System.String) LIKE '%", txt_s4.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s5_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Format("stanowisko LIKE '%{0}%'", txt_s5.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s6_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Format("login LIKE '%{0}%'", txt_s6.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s7_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(emp);
            DV.RowFilter = string.Concat("status LIKE '%{0}%'", txt_s7.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s8_TextChanged(object sender, TextChangedEventArgs e)
        {
            // :)
        }

        // ============================================================================================================== \\

        void load_count_all_w()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Pracownika) FROM Pracownicy WHERE status = 'zatrudniony'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_w.Content = count;
        }

        void load_count_all_nw()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Pracownika) FROM Pracownicy WHERE status = 'niezatrudniony'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_nw.Content = count;
        }

        void load_count_all_k()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Pracownika) FROM Pracownicy WHERE status = 'zatrudniony' AND stanowisko = 'kierowca'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_k.Content = count;
        }

        void load_count_all_s()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Pracownika) FROM Pracownicy WHERE status = 'zatrudniony' AND stanowisko = 'specjalista'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_s.Content = count;
        }

        void load_count_all_h()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Pracownika) FROM Pracownicy WHERE status = 'zatrudniony' AND stanowisko = 'handlowiec'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_h.Content = count;
        }

        // ============================================================================================================== \\

        private void Btn_add_e_Click(object sender, RoutedEventArgs e)
        {
            add_emp_window aew = new add_emp_window();
            aew.ShowDialog();
        }

        private void Btn_del_e_Click(object sender, RoutedEventArgs e)
        {
            del_emp_window dew = new del_emp_window();
            dew.ShowDialog();
        }
    }
}
