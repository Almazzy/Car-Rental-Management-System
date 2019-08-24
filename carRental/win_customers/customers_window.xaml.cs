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
using carRental.klasy;
using carRental.other;
using carRental.win_cars;
using carRental.win_customers;
using carRental.win_employees;
using carRental.win_finance;
using carRental.win_overview;
using carRental.win_rentals;


namespace carRental.win_customers
{
    /// <summary>
    /// Logika interakcji dla klasy customers_window.xaml
    /// </summary>
    public partial class customers_window : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public customers_window()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();


            open_Window();
        }

        private void Btn_rentals_Click(object sender, RoutedEventArgs e)
        {
            rentals_window rw = new rentals_window();
            this.Close();
            rw.ShowDialog();
        }

        private void Btn_customers_Click(object sender, RoutedEventArgs e)
        {
            //im here
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

        private void Btn_finance_Click_1(object sender, RoutedEventArgs e)
        {
            finance_window fw = new finance_window();
            this.Close();
            fw.ShowDialog();
        }

        private void Btn_o_user_Click(object sender, RoutedEventArgs e)
        {
            add_new_user_window anuw = new add_new_user_window();
            anuw.ShowDialog();
        }

        private void Btn_employees_Click(object sender, RoutedEventArgs e)
        {
            employees_window ew = new employees_window();
            this.Close();
            ew.ShowDialog();
        }
        // --------------------------------

        private void Btn_ind_Click(object sender, RoutedEventArgs e)
        {
            click_buttons_background(240, 210, 100, 232, 232, 232, 232, 232, 232, 255, 255, 255, 112, 112, 112);
            click_buttons2(255, 255, 255, 112, 112, 112);
            click_buttons3("/carRental;component/pic/1pb.png", "/carRental;component/pic/wpc.png");
            show_table("WHERE typ_klienta='indywidualny'");
        }

        private void Btn_com_Click(object sender, RoutedEventArgs e)
        {
            click_buttons_background(232, 232, 232, 240, 210, 100, 232, 232, 232, 112, 112, 112, 255, 255, 255);
            click_buttons2(112, 112, 112, 255, 255, 255);
            click_buttons3("/carRental;component/pic/1pc.png", "/carRental;component/pic/wpb.png");
            show_table("WHERE typ_klienta='firma'");
        }

        private void open_Window()
        {
            load_count_ind();
            load_count_comp();
            click_buttons_background(240, 210, 100, 232, 232, 232, 232, 232, 232, 255, 255, 255, 112, 112, 112);
            click_buttons2(255, 255, 255, 112, 112, 112);
            click_buttons3("/carRental;component/pic/1pc.png", "/carRental;component/pic/wpc.png");
            show_table("WHERE typ_klienta='indywidualny'");
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            DateTime dateValue = new DateTime(DateTime.Now.Day);
            lbl_time1.Content = d.Hour + " : " + d.Minute + " : " + d.Second + "   " + d.Day + " / " + d.Month + " / " + d.Year;
        }

        DataTable klienci;

        void show_table(string txt)
        {
            try
            {
                connection.sql = "SELECT *FROM Klienci " + txt;
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                //connection.da = new SqlDataAdapter();
                klienci = new DataTable();
                connection.da.Fill(klienci);
                dataGrid1.ItemsSource = klienci.DefaultView;

            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }

            connection.closeConnection();
        }


        void click_buttons_background(byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7, byte c8, byte c9, byte o1, byte o2, byte o3, byte o4, byte o5, byte o6)
        {
            btn_ind.Background = new SolidColorBrush(Color.FromRgb(c1, c2, c3));
            btn_com.Background = new SolidColorBrush(Color.FromRgb(c4, c5, c6));          

            btn_ind.Foreground = new SolidColorBrush(Color.FromRgb(o1, o2, o3));
            btn_com.Foreground = new SolidColorBrush(Color.FromRgb(o4, o5, o6));
        }

        void click_buttons2(byte o1, byte o2, byte o3, byte o4, byte o5, byte o6)
        {
            lbl_ind.Foreground = new SolidColorBrush(Color.FromRgb(o1, o2, o3));
            lbl_com.Foreground = new SolidColorBrush(Color.FromRgb(o4, o5, o6));
        }

        void click_buttons3(string i1, string i2)
        {
            im1.Source = new BitmapImage(new Uri(i1, UriKind.Relative));
            im2.Source = new BitmapImage(new Uri(i2, UriKind.Relative));
        }

        void load_count_ind()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Klienta) FROM Klienci WHERE typ_klienta='indywidualny'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_ind.Content = count;
        }

        void load_count_comp()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Klienta) FROM Klienci WHERE typ_klienta='firma'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_com.Content = Convert.ToInt32(count);
        }

        //search in datagrid;

        private void Txt_s1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("typ_klienta LIKE '%{0}%'", txt_s1.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s2_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("najemca LIKE '%{0}%'", txt_s2.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("uzytkownik LIKE '%{0}%'", txt_search.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s4_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("nr_prawa_jazdy LIKE '%{0}%'", txt_s4.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s5_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("nr_dowodu LIKE '%{0}%'", txt_s5.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s6_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("adres_zameldowania LIKE '%{0}%'", txt_s6.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s7_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("'nr_telefonu' LIKE '%{0}%'", txt_s7.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s8_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("'nr_telefonu_2' LIKE '%{0}%'", txt_s8.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s9_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("email LIKE '%{0}%'", txt_s9.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s10_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("pesel LIKE '%{0}%'", txt_s10.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s11_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(klienci);
            DV.RowFilter = string.Format("NIP LIKE '%{0}%'", txt_s11.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();


            open_Window();
        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            logout_window lw = new logout_window();
            lw.ShowDialog();
        }

       
    }
}
