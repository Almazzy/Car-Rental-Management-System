using carRental.win_cars;
using carRental.win_customers;
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
using carRental.win_rentals;
using carRental.win_finance;
using System.Data;
using carRental.klasy;
using System.Data.SqlClient;
using carRental.other;
using carRental.win_employees;

namespace carRental.win_overview
{
    /// <summary>
    /// Logika interakcji dla klasy overview_window.xaml
    /// </summary>
    public partial class overview_window : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public overview_window()
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
            //im here
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

        // ============================================================================================================== \\

        private void Txt_s1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("ubezpieczyciel LIKE '%{0}%'", txt_s1.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s2_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("miejsce_wykonania LIKE '%{0}%'", txt_s2.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("CONVERT(", "kwota_brutto", ",System.String) LIKE '%", txt_search.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s4_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("CONVERT(", "data_od", ",System.String) LIKE '%", txt_s4.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s5_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("CONVERT(", "data_do", ",System.String) LIKE '%", txt_s5.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s6_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("nr_rejestracyjny LIKE '%{0}%'", txt_s6.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s7_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Concat("marka LIKE '%{0}%'", txt_s7.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s8_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("model LIKE '%{0}%'", txt_s8.Text);
            dataGrid1.ItemsSource = DV;
        }

        private void Txt_s9_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView DV = new DataView(pandp);
            DV.RowFilter = string.Format("CONVERT(", "data_doo", ",System.String) LIKE '%", txt_s9.Text, "%'");
            dataGrid1.ItemsSource = DV;
        }

        // ============================================================================================================== \\

        private void Btn_all_ub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_ub, btn_little_time_ub, btn_history_ub, btn_all_p, btn_little_time_p, btn_history_p, btn_not_use_ub, btn_not_use_p,
                lbl_all_ub, lbl_little_time_ub, lbl_history_ub, lbl_all_p, lbl_little_time_p, lbl_history_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1b.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 1);
                show_table_ub(" AND data_do > GETDATE() AND status='zajeta' ", 0);
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_little_time_ub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_little_time_ub, btn_all_ub, btn_history_ub, btn_all_p, btn_little_time_p, btn_history_p, btn_not_use_ub, btn_not_use_p,
                lbl_little_time_ub, lbl_all_ub, lbl_history_ub, lbl_all_p, lbl_little_time_p, lbl_history_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2b.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 1);
                show_table_ub(" AND DATEPART(month, data_do) = DATEPART(month, GETDATE()) AND data_do > GETDATE() AND DATEPART(year, data_do) = DATEPART(year, GETDATE()) AND status='zajeta' ORDER BY po.data_do ", 0);

                int count3 = Convert.ToInt32(lbl_little_time_ub.Content);
                if (count3 != 0)
                {
                    MessageBox.Show("Posiadasz polisy, których okres ważności niedługo się kończy.", "Ostrzeżenie");
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_history_ub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_history_ub, btn_all_ub, btn_little_time_ub, btn_all_p, btn_little_time_p, btn_history_p, btn_not_use_ub, btn_not_use_p,
                lbl_history_ub, lbl_all_ub, lbl_little_time_ub, lbl_all_p, lbl_little_time_p, lbl_history_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3b.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 1);
                show_table_ub(" AND data_do < GETDATE() AND status='zajeta' ", 0);
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_not_use_ub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_not_use_ub, btn_history_ub, btn_all_ub, btn_little_time_ub, btn_all_p, btn_little_time_p, btn_history_p, btn_not_use_p,
                 lbl_not_use_ub, lbl_history_ub, lbl_all_ub, lbl_little_time_ub, lbl_all_p, lbl_little_time_p, lbl_history_p, lbl_not_use_p,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unpb.png", "/carRental;component/pic/unps.png", 1);
                show_table_ub(" status='nieprzypisana' ", 1);

                int count1 = Convert.ToInt32(lbl_not_use_ub.Content);
                if (count1 != 0)
                {
                    MessageBox.Show("Posiadasz polisy, które nie są przypisane do żadnego samochodu.", "Ostrzeżenie");
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }

        }

        // ============================================================================================================== \\

        private void Btn_all_p_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_all_p, btn_all_ub, btn_little_time_ub, btn_history_ub, btn_little_time_p, btn_history_p, btn_not_use_ub, btn_not_use_p,
                lbl_all_p, lbl_all_ub, lbl_little_time_ub, lbl_history_ub, lbl_little_time_p, lbl_history_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1b.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 2);
                show_table_p(" AND data_doo > GETDATE() AND status='zajety' ", 0);
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_little_time_p_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_little_time_p, btn_all_ub, btn_little_time_ub, btn_history_ub, btn_all_p, btn_history_p, btn_not_use_ub, btn_not_use_p,
                lbl_little_time_p, lbl_all_ub, lbl_little_time_ub, lbl_history_ub, lbl_all_p, lbl_history_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2b.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 2);
                show_table_p(" AND DATEPART(month, data_doo) = DATEPART(month, GETDATE()) AND data_doo > GETDATE() AND DATEPART(year, data_doo) = DATEPART(year, GETDATE()) AND status='zajety' ORDER BY pr.data_doo", 0);

                int count4 = Convert.ToInt32(lbl_little_time_p.Content);
                if (count4 != 0)
                {
                    MessageBox.Show("Posiadasz przeglądy, których okres ważności niedługo się kończy.", "Ostrzeżenie");
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_history_p_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_history_p, btn_all_ub, btn_little_time_ub, btn_history_ub, btn_all_p, btn_little_time_p, btn_not_use_ub, btn_not_use_p,
              lbl_history_p, lbl_all_ub, lbl_little_time_ub, lbl_history_ub, lbl_all_p, lbl_little_time_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3b.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 2);
                show_table_p(" AND data_doo < GETDATE() AND status='zajety' ", 0);
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_not_use_p_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttons_click_colors(btn_not_use_p, btn_history_p, btn_all_ub, btn_little_time_ub, btn_history_ub, btn_all_p, btn_little_time_p, btn_not_use_ub,
              lbl_not_use_p, lbl_history_p, lbl_all_ub, lbl_little_time_ub, lbl_history_ub, lbl_all_p, lbl_little_time_p, lbl_not_use_ub,
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unpb.png", 2);
                show_table_p(" status='nieprzypisany' ", 1);

                int count2 = Convert.ToInt32(lbl_not_use_p.Content);
                if (count2 != 0)
                {
                    MessageBox.Show("Posiadasz przeglądy, które nie są przypisane do żadnego samochodu.", "Ostrzeżenie");
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }


        // ============================================================================================================== \\

        DataTable pandp;

        void show_table_ub(string txt, int i)
        {
            try
            {
                if (i == 0)
                {
                    connection.sql = "SELECT po.ubezpieczyciel, po.kwota_brutto, po.data_od, po.data_do, s.nr_rejestracyjny, " +
                        " s.marka, s.model, po.notatka, po.status FROM Polisy po, Samochody s WHERE s.Id_Polisy = po.Id_Polisy " + txt;
                }
                else if (i == 1)
                {
                    connection.sql = "SELECT ubezpieczyciel, kwota_brutto, data_od, data_do, notatka, status " +
                    " FROM Polisy WHERE " + txt;
                }
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                pandp = new DataTable();
                connection.da.Fill(pandp);
                dataGrid1.ItemsSource = pandp.DefaultView;
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
            connection.closeConnection();
        }



        void show_table_p(string txt, int i)
        {
            try
            {
                if (i == 0)
                {
                    connection.sql = "SELECT pr.miejsce_wykonania, pr.data_od, pr.data_doo, s.nr_rejestracyjny, " +
                    " s.marka, s.model, pr.notatka, pr.status FROM Przeglady pr, Samochody s WHERE s.Id_Przegladu = pr.Id_Przegladu " + txt;
                }
                else if (i == 1)
                {
                    connection.sql = "SELECT miejsce_wykonania, data_od, data_doo, notatka, status FROM Przeglady WHERE " + txt;
                }
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                pandp = new DataTable();
                connection.da.Fill(pandp);
                dataGrid1.ItemsSource = pandp.DefaultView;
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
            load_count_all_ub();
            load_count_little_time_ub();
            load_count_history_ub();
            load_count_all_p();
            load_count_little_time_p();
            load_count_history_p();
            load_cout_not_use_ub();
            load_cout_not_use_p();

            buttons_click_colors(btn_all_ub, btn_little_time_ub, btn_history_ub, btn_all_p, btn_little_time_p, btn_history_p, btn_not_use_ub, btn_not_use_p,
                lbl_all_ub, lbl_little_time_ub, lbl_history_ub, lbl_all_p, lbl_little_time_p, lbl_history_p, lbl_not_use_ub, lbl_not_use_p,
                "/carRental;component/pic/um1b.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/um1s.png", "/carRental;component/pic/um2s.png", "/carRental;component/pic/um3s.png",
                "/carRental;component/pic/unps.png", "/carRental;component/pic/unps.png", 1);
            show_table_ub(" AND data_do > GETDATE() AND status='zajeta' ", 0);
        }

        // ============================================================================================================== \\

        void load_count_all_ub()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Polisy) FROM Polisy WHERE data_do > GETDATE() AND status='zajeta'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_ub.Content = count;
        }

        void load_count_little_time_ub()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Polisy) FROM Polisy WHERE DATEPART(month, data_do) = DATEPART(month, GETDATE()) AND data_do > GETDATE() AND DATEPART(year, data_do) = DATEPART(year, GETDATE()) AND status='zajeta'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_little_time_ub.Content = Convert.ToInt32(count);
        }


        void load_count_history_ub()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Polisy) FROM Polisy WHERE data_do < GETDATE() AND status='zajeta'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_history_ub.Content = Convert.ToString(count);
        }


        void load_cout_not_use_ub()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Polisy) FROM Polisy WHERE status='nieprzypisana'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_not_use_ub.Content = Convert.ToString(count);
        }

        // ============================================================================================================== \\

        void load_count_all_p()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Przegladu) FROM Przeglady WHERE data_doo > GETDATE() AND status='zajety'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_p.Content = count;
        }

        void load_count_little_time_p()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Przegladu) FROM Przeglady WHERE DATEPART(month, data_doo) = DATEPART(month, GETDATE()) AND data_doo > GETDATE() AND DATEPART(year, data_doo) = DATEPART(year, GETDATE()) AND status='zajety'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_little_time_p.Content = Convert.ToInt32(count);
        }


        void load_count_history_p()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Przegladu) FROM Przeglady WHERE data_doo < GETDATE() AND status='zajety'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_history_p.Content = Convert.ToString(count);
        }


        void load_cout_not_use_p()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Przegladu) FROM Przeglady WHERE status='nieprzypisany'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_not_use_p.Content = Convert.ToString(count);
        }

        void buttons_click_colors(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6, Button b7, Button b8, Label l1, Label l2,
            Label l3, Label l4, Label l5, Label l6, Label l7, Label l8, string i1, string i2, string i3, string i4, string i5, string i6,
            string i7, string i8, int i)
        {
            b1.Background = new SolidColorBrush(Color.FromRgb(166, 159, 199));
            b2.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b3.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b4.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b5.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b6.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b7.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b8.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));

            b1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            b2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b3.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b4.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b5.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b6.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b7.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b8.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));

            l1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l3.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l4.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l5.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l6.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l7.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l8.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));

            im1.Source = new BitmapImage(new Uri(i1, UriKind.Relative));
            im2.Source = new BitmapImage(new Uri(i2, UriKind.Relative));
            im3.Source = new BitmapImage(new Uri(i3, UriKind.Relative));
            im4.Source = new BitmapImage(new Uri(i4, UriKind.Relative));
            im5.Source = new BitmapImage(new Uri(i5, UriKind.Relative));
            im6.Source = new BitmapImage(new Uri(i6, UriKind.Relative));
            im7.Source = new BitmapImage(new Uri(i7, UriKind.Relative));
            im8.Source = new BitmapImage(new Uri(i8, UriKind.Relative));

            if (i == 1)
            {
                rec1.Fill = new SolidColorBrush(Color.FromRgb(188, 183, 214));
                rec1.Stroke = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                lbl1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                rec2.Fill = new SolidColorBrush(Color.FromRgb(232, 232, 232));
                rec2.Stroke = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                lbl2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            }
            else if (i == 2)
            {
                rec2.Fill = new SolidColorBrush(Color.FromRgb(188, 183, 214));
                rec2.Stroke = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                lbl2.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                rec1.Fill = new SolidColorBrush(Color.FromRgb(232, 232, 232));
                rec1.Stroke = new SolidColorBrush(Color.FromRgb(112, 112, 112));
                lbl1.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            }

            checking_if_zero();
        }

        // ============================================================================================================== \\

        private void Btn_new_service_Click(object sender, RoutedEventArgs e)
        {
            new_service_window nsw = new new_service_window();
            nsw.ShowDialog();
        }

        private void Btn_new_uw_Click(object sender, RoutedEventArgs e)
        {
            new_uw_window nuw = new new_uw_window();
            nuw.ShowDialog();
        }

        private void Btn_new_p_Click(object sender, RoutedEventArgs e)
        {
            new_p_window npw = new new_p_window();
            npw.ShowDialog();
        }

        private void Btn_new_ub_Click(object sender, RoutedEventArgs e)
        {
            new_ub_window nuw = new new_ub_window();
            nuw.ShowDialog();
        }

        // ============================================================================================================== \\

        void checking_if_zero()
        {
            int count1 = Convert.ToInt32(lbl_not_use_ub.Content);
            if (count1 != 0)
            {
                btn_not_use_ub.Background = new SolidColorBrush(Color.FromRgb(241, 126, 126));
                btn_not_use_ub.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lbl_not_use_ub.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                im7.Source = new BitmapImage(new Uri("/carRental;component/pic/unpb.png", UriKind.Relative));
            }

            int count2 = Convert.ToInt32(lbl_not_use_p.Content);
            if (count2 != 0)
            {
                btn_not_use_p.Background = new SolidColorBrush(Color.FromRgb(241, 126, 126));
                btn_not_use_p.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lbl_not_use_p.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                im8.Source = new BitmapImage(new Uri("/carRental;component/pic/unpb.png", UriKind.Relative));
            }

            int count3 = Convert.ToInt32(lbl_little_time_ub.Content);
            if (count3 != 0)
            {
                btn_little_time_ub.Background = new SolidColorBrush(Color.FromRgb(241, 126, 126));
                btn_little_time_ub.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lbl_little_time_ub.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                im3.Source = new BitmapImage(new Uri("/carRental;component/pic/um2b.png", UriKind.Relative));
            }

            int count4 = Convert.ToInt32(lbl_little_time_p.Content);
            if (count4 != 0)
            {
                btn_little_time_p.Background = new SolidColorBrush(Color.FromRgb(241, 126, 126));
                btn_little_time_p.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                lbl_little_time_p.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                im5.Source = new BitmapImage(new Uri("/carRental;component/pic/um2b.png", UriKind.Relative));
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.Background = new SolidColorBrush(Color.FromRgb(241, 126, 126));
            dataGrid1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            logout_window lw = new logout_window();
            lw.ShowDialog();
        }


    }
}
