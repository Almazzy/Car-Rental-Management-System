using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using carRental.other;
using carRental.win_cars;
using carRental.win_customers;
using carRental.win_employees;
using carRental.win_finance;
using carRental.win_overview;
using carRental.win_rentals;

namespace carRental.win_cars
{
 
    /// <summary>
    /// Logika interakcji dla klasy cars_window.xaml
    /// </summary>
    public partial class cars_window : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public cars_window()
        {
            InitializeComponent();

            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            open_Window();
        }

        void load_count_all_cars()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Samochodu) FROM Samochody WHERE aktywnosc = 'aktywny'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_cars.Content = count;
        }

        void load_count_wy_cars()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Samochodu) FROM Samochody WHERE stan = 'wydany'  AND aktywnosc = 'aktywny'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_wy_cars.Content = Convert.ToInt32(count);
        }

        void load_count_wo_cars()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Samochodu) FROM Samochody WHERE stan = 'wolny' AND aktywnosc = 'aktywny'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_wo_cars.Content = Convert.ToString(count);
        }

        void load_count_res_cars()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Samochodu) FROM Samochody WHERE stan = 'rezerwacja' AND aktywnosc = 'aktywny'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_res_cars.Content = Convert.ToString(count);
        }

        void load_count_ser_cars()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Samochodu) FROM Samochody WHERE aktywnosc = 'aktywny' AND stan = 'dyzur' OR stan = 'serwis'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_ser_cars.Content = Convert.ToString(count);
        }


        void click_buttons_background(byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7, byte c8, byte c9,
            byte c10, byte c11, byte c12, byte c13, byte c14, byte c15)
        {
            btn_all_cars.Background = new SolidColorBrush(Color.FromRgb(c1, c2, c3));
            btn_wy_cars.Background = new SolidColorBrush(Color.FromRgb(c4, c5, c6));
            btn_wo_cars.Background = new SolidColorBrush(Color.FromRgb(c7, c8, c9));
            btn_res_cars.Background = new SolidColorBrush(Color.FromRgb(c10, c11, c12));
            btn_ser_cars.Background = new SolidColorBrush(Color.FromRgb(c13, c14, c15));
        }

        void click_lbl_freground(byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7, byte c8, byte c9,
            byte c10, byte c11, byte c12, byte c13, byte c14, byte c15)
        { 
            lbl_all_cars.Foreground = new SolidColorBrush(Color.FromRgb(c1, c2, c3));
            lbl_wy_cars.Foreground = new SolidColorBrush(Color.FromRgb(c4, c5, c6));
            lbl_wo_cars.Foreground = new SolidColorBrush(Color.FromRgb(c7, c8, c9));
            lbl_res_cars.Foreground = new SolidColorBrush(Color.FromRgb(c10, c11, c12));
            lbl_ser_cars.Foreground = new SolidColorBrush(Color.FromRgb(c13, c14, c15));
        }

        void main_buttons_foreground(byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7, byte c8, byte c9,
            byte c10, byte c11, byte c12, byte c13, byte c14, byte c15)
        {
            btn_all_cars.Foreground = new SolidColorBrush(Color.FromRgb(c1, c2, c3));
            btn_wy_cars.Foreground = new SolidColorBrush(Color.FromRgb(c4, c5, c6));
            btn_wo_cars.Foreground = new SolidColorBrush(Color.FromRgb(c7, c8, c9));
            btn_res_cars.Foreground = new SolidColorBrush(Color.FromRgb(c10, c11, c12));
            btn_ser_cars.Foreground = new SolidColorBrush(Color.FromRgb(c13, c14, c15));
        }

        void main_buttons_image_source(string i1, string i2, string i3, string i4, string i5)
        {
            im1.Source = new BitmapImage(new Uri(i1, UriKind.Relative));
            im2.Source = new BitmapImage(new Uri(i2, UriKind.Relative));
            im3.Source = new BitmapImage(new Uri(i3, UriKind.Relative));
            im4.Source = new BitmapImage(new Uri(i4, UriKind.Relative));
            im5.Source = new BitmapImage(new Uri(i5, UriKind.Relative));
        }

        //--==========================================================================

        void bottom_buttons_colors(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6, int i) {
            if (i == 1)
            {
                b1.Opacity = 0.5;
                b1.Background = new SolidColorBrush(Color.FromRgb(203, 153, 197));
            }
            else {
                b1.Opacity = 0.75;
                b1.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            }

            b2.Opacity = 0.75;
            b3.Opacity = 0.75;
            b4.Opacity = 0.75;
            b5.Opacity = 0.75;
            b6.Opacity = 0.75;

            b2.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b3.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b4.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b5.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b6.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
        }

        void top_buttons_colors(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6, Button b7, Button b8, int i)
        {
            if (i == 1)
            {
                b1.Opacity = 0.7;
                b1.Background = new SolidColorBrush(Color.FromRgb(203, 153, 197));
            }
            else
            {
                b1.Opacity = 0.55;
                b1.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            }

            b2.Opacity = 0.55;
            b3.Opacity = 0.55;
            b4.Opacity = 0.55;
            b5.Opacity = 0.55;
            b6.Opacity = 0.55;
            b7.Opacity = 0.55;
            b8.Opacity = 0.55;

            b2.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b3.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b4.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b5.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b6.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b7.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b8.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
        }

        DataTable samochody;

        void show_table(string txt)
        {
            try
            {
                connection.sql = "SELECT s.nr_rejestracyjny, s.vin, s.marka, s.model, s.rok_produkcji, " + 
                    " s.pojemnosc, s.paliwo, s.typ, s.stan, pr.data_doo, po.data_do FROM Samochody s, " + 
                    " Przeglady pr, Polisy po WHERE s.Id_Polisy=po.Id_Polisy AND s.Id_Przegladu =pr.Id_Przegladu " + txt;
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                //connection.da = new SqlDataAdapter();
                samochody = new DataTable();
                connection.da.Fill(samochody);
                dataGrid1.ItemsSource = samochody.DefaultView;

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
        }

        private void open_Window()
        {
            load_count_all_cars();
            load_count_res_cars();
            load_count_ser_cars();
            load_count_wo_cars();
            load_count_wy_cars();
            click_buttons_background(203, 153, 197, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232);
            click_lbl_freground(255, 255, 255, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_foreground(255, 255, 255, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_image_source("/carRental;component/pic/cars/twob.png", "/carRental;component/pic/cars/manwcars.png", "/carRental;component/pic/cars/wols.png", "/carRental;component/pic/cars/ress.png", "/carRental;component/pic/cars/sers.png");
            show_table("");
        }

        private void main_buttons_not_use() {
            click_buttons_background(232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232);
            click_lbl_freground(112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_foreground(112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_image_source("/carRental;component/pic/cars/twos.png", "/carRental;component/pic/cars/manwcars.png", "/carRental;component/pic/cars/wols.png", "/carRental;component/pic/cars/ress.png", "/carRental;component/pic/cars/sers.png");
        }

        // nav:

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
            //im here
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

        private void Btn_employees_Click(object sender, RoutedEventArgs e)
        {
            employees_window ew = new employees_window();
            this.Close();
            ew.ShowDialog();
        }
        // =======================================

        private void Txt_s1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("nr_rejestracyjny LIKE '%{0}%'", txt_s1.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s2_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("vin LIKE '%{0}%'", txt_s2.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("marka LIKE '%{0}%'", txt_search.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s4_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("model LIKE '%{0}%'", txt_s4.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s5_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("rok_produkcji LIKE '%{0}%'", txt_s5.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s6_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("pojemnosc LIKE '%{0}%'", txt_s6.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s7_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("paliwo LIKE '%{0}%'", txt_s7.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s8_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("typ LIKE '%{0}%'", txt_s8.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s9_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Format("stan LIKE '%{0}%'", txt_s9.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s10_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Concat("CONVERT(", "data_doo", ",System.String) LIKE '%", txt_s10.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s11_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(samochody);
            DV.RowFilter = string.Concat("CONVERT(", "data_do", ",System.String) LIKE '%", txt_s11.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Btn_all_cars_Click(object sender, RoutedEventArgs e) //1
        {
            click_buttons_background(203, 153, 197, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232);
            click_lbl_freground(255, 255, 255, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_foreground(255, 255, 255, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_image_source("/carRental;component/pic/cars/twob.png", "/carRental;component/pic/cars/manwcars.png", "/carRental;component/pic/cars/wols.png", "/carRental;component/pic/cars/ress.png", "/carRental;component/pic/cars/sers.png");
            show_table(" AND aktywnosc = 'aktywny'");

            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);

        }

        private void Btn_wy_cars_Click(object sender, RoutedEventArgs e)//2
        {
            click_buttons_background(232, 232, 232, 203, 153, 197, 232, 232, 232, 232, 232, 232, 232, 232, 232);
            click_lbl_freground(112, 112, 112, 255, 255, 255, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_foreground(112, 112, 112, 255, 255, 255, 112, 112, 112, 112, 112, 112, 112, 112, 112);
            main_buttons_image_source("/carRental;component/pic/cars/twos.png", "/carRental;component/pic/cars/manwcarb.png", "/carRental;component/pic/cars/wols.png", "/carRental;component/pic/cars/ress.png", "/carRental;component/pic/cars/sers.png");
            show_table(" AND s.stan='wydany' AND aktywnosc = 'aktywny'");

            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_wo_cars_Click(object sender, RoutedEventArgs e) //3
        {
            click_buttons_background(232, 232, 232, 232, 232, 232, 203, 153, 197, 232, 232, 232, 232, 232, 232);
            click_lbl_freground(112, 112, 112, 112, 112, 112, 255, 255, 255, 112, 112, 112, 112, 112, 112);
            main_buttons_foreground(112, 112, 112, 112, 112, 112, 255, 255, 255, 112, 112, 112, 112, 112, 112);
            main_buttons_image_source("/carRental;component/pic/cars/twos.png", "/carRental;component/pic/cars/manwcars.png", "/carRental;component/pic/cars/wolb.png", "/carRental;component/pic/cars/ress.png", "/carRental;component/pic/cars/sers.png");
            show_table(" AND s.stan='wolny' AND aktywnosc = 'aktywny'");

            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_res_cars_Click(object sender, RoutedEventArgs e)//4
        {
            click_buttons_background(232, 232, 232, 232, 232, 232, 232, 232, 232, 203, 153, 197, 232, 232, 232);
            click_lbl_freground(112, 112, 112, 112, 112, 112, 112, 112, 112, 255, 255, 255, 112, 112, 112);
            main_buttons_foreground(112, 112, 112, 112, 112, 112, 112, 112, 112, 255, 255, 255, 112, 112, 112);
            main_buttons_image_source("/carRental;component/pic/cars/twos.png", "/carRental;component/pic/cars/manwcars.png", "/carRental;component/pic/cars/wols.png", "/carRental;component/pic/cars/resb.png", "/carRental;component/pic/cars/sers.png");
            show_table(" AND s.stan='rezerwacja' AND aktywnosc = 'aktywny'");

            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_ser_cars_Click(object sender, RoutedEventArgs e)//5
        {
            click_buttons_background(232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 232, 203, 153, 197);
            click_lbl_freground(112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 255, 255, 255);
            main_buttons_foreground(112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 112, 255, 255, 255);
            main_buttons_image_source("/carRental;component/pic/cars/twos.png", "/carRental;component/pic/cars/manwcars.png", "/carRental;component/pic/cars/wols.png", "/carRental;component/pic/cars/ress.png", "/carRental;component/pic/cars/serb.png");
            show_table(" AND s.stan='serwis' AND aktywnosc = 'aktywny'");
            show_table(" AND s.stan='dyzur' AND aktywnosc = 'aktywny'");

            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        

        // =====================================================

        private void Btn_hatchback_Click(object sender, RoutedEventArgs e)
        {
            bottom_buttons_colors(btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, btn_van, 1);
            show_table(" AND s.typ='hatchback' AND aktywnosc = 'aktywny'");


            main_buttons_not_use();
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
        }

        private void Btn_sedan_Click(object sender, RoutedEventArgs e)
        {
            bottom_buttons_colors(btn_sedan, btn_hatchback, btn_kombi, btn_sport, btn_suvy, btn_van, 1);
            show_table(" AND s.typ='sedan' AND aktywnosc = 'aktywny'");


            main_buttons_not_use();
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
        }

        private void Btn_kombi_Click(object sender, RoutedEventArgs e)
        {
            bottom_buttons_colors(btn_kombi, btn_hatchback, btn_sedan, btn_sport, btn_suvy, btn_van, 1);
            show_table(" AND s.typ='kombi' AND aktywnosc = 'aktywny'");


            main_buttons_not_use();
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
        }

        private void Btn_sport_Click(object sender, RoutedEventArgs e)
        {
            bottom_buttons_colors(btn_sport, btn_hatchback, btn_sedan, btn_kombi, btn_suvy, btn_van, 1);
            show_table(" AND s.typ='coupe' AND aktywnosc = 'aktywny'");


            main_buttons_not_use();
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
        }

        private void Btn_suvy_Click(object sender, RoutedEventArgs e)
        {
            bottom_buttons_colors(btn_suvy, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_van, 1);
            show_table(" AND s.typ='suv' AND aktywnosc = 'aktywny'");


            main_buttons_not_use();
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
        }

        private void Btn_van_Click(object sender, RoutedEventArgs e)
        {
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 1);
            show_table(" AND s.typ='van' AND aktywnosc = 'aktywny'");


            main_buttons_not_use();
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 2);
        }


        // =====================================================



        private void Btn_a_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, btn_suv, 1);
            show_table(" AND s.klasa='a' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_b_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_b, btn_a, btn_c, btn_d, btn_e, btn_p, btn_r, btn_suv, 1);
            show_table(" AND s.klasa='b' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_c_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_c, btn_a, btn_b, btn_d, btn_e, btn_p, btn_r, btn_suv, 1);
            show_table(" AND s.klasa='c' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_d_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_d, btn_a, btn_b, btn_c, btn_e, btn_p, btn_r, btn_suv, 1);
            show_table(" AND s.klasa='d' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_e_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_e, btn_a, btn_b, btn_c, btn_d, btn_p, btn_r, btn_suv, 1);
            show_table(" AND s.klasa='e' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_p_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_p, btn_a, btn_b, btn_c, btn_d, btn_e, btn_r, btn_suv, 1);
            show_table(" AND s.klasa='p' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_r_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_r, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_suv, 1);
            show_table(" AND s.klasa='r' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_suv_Click(object sender, RoutedEventArgs e)
        {
            top_buttons_colors(btn_suv, btn_a, btn_b, btn_c, btn_d, btn_e, btn_p, btn_r, 1);
            show_table(" AND s.klasa='suv' AND aktywnosc = 'aktywny'");

            main_buttons_not_use();
            bottom_buttons_colors(btn_van, btn_hatchback, btn_sedan, btn_kombi, btn_sport, btn_suvy, 2);
        }

        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            open_Window();
        }

        // --------------------------------------------------------------------

        private void Btn_change_status_Click(object sender, RoutedEventArgs e)
        {
            change_status_window csw = new change_status_window();
            csw.ShowDialog();
        }

        private void Btn_add_new_car_Click(object sender, RoutedEventArgs e)
        {
            add_new_car_window ancw = new add_new_car_window();
            ancw.ShowDialog();
        }

        private void Btn_delete_car_Click(object sender, RoutedEventArgs e)
        {
            delete_car_window dcw = new delete_car_window();
            dcw.ShowDialog();
        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            logout_window lw = new logout_window();
            lw.ShowDialog();
        }

     
    }
}
