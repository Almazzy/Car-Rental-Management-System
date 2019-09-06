using carRental.win_cars;
using carRental.win_customers;
using carRental.win_rentals;
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
using carRental.win_overview;
using carRental.other;
using carRental.win_employees;
using carRental.klasy;
using System.Data;
using System.Data.SqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace carRental.win_finance
{
    /// <summary>
    /// Logika interakcji dla klasy finance_window.xaml
    /// </summary>
    public partial class finance_window : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public finance_window()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            Open_window();
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
            //im here
        }

        private void Btn_employees_Click(object sender, RoutedEventArgs e)
        {
            employees_window ew = new employees_window();
            this.Close();
            ew.ShowDialog();
        }

        // ============================================================================================================== \\

        private void Btn_reload_Click(object sender, RoutedEventArgs e)
        {
            Open_window();
        }

        private void Btn_logout_Click(object sender, RoutedEventArgs e)
        {
            logout_window lw = new logout_window();
            lw.ShowDialog();
        }

        // ============================================================================================================== \\

        private void Btn_gen_invoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_no_f.Text))
                {
                    MessageBox.Show("Podany numer faktury jest błędny lub nieistnieje. Spróbuj ponownie.", "Błąd!");
                }
                else
                {
                    Doc_opacity(1);
                    ShowDoc();
                }
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_download_pdf_Click(object sender, RoutedEventArgs e)
        {
            Create_Document();
        }

        // ============================================================================================================== \\

        private void Btn_all_invoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buttons_click_colors(btn_all_invoices, btn_c_invoices, btn_b_invoices, lbl_all_invoices, lbl_c_invoices, lbl_b_invoices,
                "/carRental;component/pic/inv/invab.png", "/carRental;component/pic/inv/invis.png", "/carRental;component/pic/inv/invbs.png");
                Show_table("");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_c_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buttons_click_colors(btn_c_invoices, btn_all_invoices, btn_b_invoices, lbl_c_invoices, lbl_all_invoices, lbl_b_invoices,
            "/carRental;component/pic/inv/invas.png", "/carRental;component/pic/inv/invib.png", "/carRental;component/pic/inv/invbs.png");
                Show_table(" AND k.typ_klienta='indywidualny'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_b_invoices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buttons_click_colors(btn_b_invoices, btn_all_invoices, btn_c_invoices, lbl_b_invoices, lbl_all_invoices, lbl_c_invoices,
        "/carRental;component/pic/inv/invas.png", "/carRental;component/pic/inv/invis.png", "/carRental;component/pic/inv/invbb.png");
                Show_table(" AND k.typ_klienta='firma'");
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            Doc_opacity(0);
        }

        private void Btn_add_f_Click(object sender, RoutedEventArgs e)
        {
            add_new_inv_window aniw = new add_new_inv_window();
            aniw.ShowDialog();
        }

        // ============================================================================================================== \\

        private void Data_conn(string com)
        {
            connection.openConnection();
            connection.sql = com;
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
        }

        private void Open_window()
        {
            Load_all();
            Load_c();
            Load_b();
            Doc_opacity(0);

            Buttons_click_colors(btn_all_invoices, btn_c_invoices, btn_b_invoices, lbl_all_invoices, lbl_c_invoices, lbl_b_invoices,
                "/carRental;component/pic/inv/invab.png", "/carRental;component/pic/inv/invis.png", "/carRental;component/pic/inv/invbs.png");
            Show_table(" ");
        }

        private void Doc_opacity(int o)
        {
            l1.Opacity = o;
            l2.Opacity = o;
            l3.Opacity = o;
            l4.Opacity = o;
            l5.Opacity = o;
            l6.Opacity = o;
            l7.Opacity = o;
            l8.Opacity = o;
            l9.Opacity = o;
            l10.Opacity = o;
            l11.Opacity = o;
            l12.Opacity = o;
            l13.Opacity = o;
            l14.Opacity = o;
            l15.Opacity = o;
            l16.Opacity = o;
            l17.Opacity = o;
            l18.Opacity = o;
            l19.Opacity = o;
            l20.Opacity = o;
            l21.Opacity = o;
            l22.Opacity = o;
            l23.Opacity = o;
            l24.Opacity = o;
            l25.Opacity = o;
            //--------------
            lbl_n_name.Opacity = o;
            lbl_n_no.Opacity = o;
            textblock_n_address.Opacity = o;
            lbl_f_no.Opacity = o;
            lbl_start_date.Opacity = o;
            lbl_finish_date.Opacity = o;
            lbl_today_date.Opacity = o;
            lbl_payment.Opacity = o;
            lbl_payment_date.Opacity = o;
            lbl_txt.Opacity = o;
            lbl_day.Opacity = o;
            lbl_day_c.Opacity = o;
            lbl_vat.Opacity = o;
            lbl_netto.Opacity = o;
            lbl_brutto.Opacity = o;
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d;
            d = DateTime.Now;
            DateTime dateValue = new DateTime(DateTime.Now.Day);
            lbl_time1.Content = d.Hour + " : " + d.Minute + " : " + d.Second + "   " + d.Day + " / " + d.Month + " / " + d.Year;
        }

        DataTable inv;

        void Show_table(string txt)
        {
            try
            {
                connection.sql = "SELECT f.nr_faktury, w.nr_zlecenia, k.najemca, f.data_wystawienia, f.sposob_platnosci, " +
                    "f.termin_platnosci, f.usluga, f.suma_dni, p.imie_nazwisko FROM Faktury f, Wynajmy w, Klienci k, Pracownicy p WHERE " +
                    "f.Id_Wynajmu=w.Id_Wynajmu AND f.Id_Pracownika=p.Id_Pracownika AND w.Id_Klienta=k.Id_Klienta " + txt;
                connection.cmd.CommandText = connection.sql;
                connection.da = new SqlDataAdapter(connection.cmd);
                //connection.da = new SqlDataAdapter();
                inv = new DataTable();
                connection.da.Fill(inv);
                dataGrid1.ItemsSource = inv.DefaultView;

            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }

            connection.closeConnection();
        }

        // ============================================================================================================== \\

        void Load_all()
        {
            connection.openConnection();
            connection.sql = "SELECT count(Id_Faktury) FROM Faktury";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_all_invoices.Content = count;
        }

        void Load_c()
        {
            connection.openConnection();
            connection.sql = "SELECT count(f.Id_Faktury) FROM Faktury f, Klienci k, Wynajmy w WHERE f.Id_Wynajmu=w.Id_Wynajmu AND w.Id_Klienta=k.Id_Klienta AND k.typ_klienta='indywidualny'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_c_invoices.Content = count;
        }

        void Load_b()
        {
            connection.openConnection();
            connection.sql = "SELECT count(f.Id_Faktury) FROM Faktury f, Klienci k, Wynajmy w WHERE f.Id_Wynajmu=w.Id_Wynajmu AND w.Id_Klienta=k.Id_Klienta AND k.typ_klienta='firma'";
            connection.cmd.CommandType = CommandType.Text;
            connection.cmd.CommandText = connection.sql;
            int count = (int)connection.cmd.ExecuteScalar();
            connection.closeConnection();
            lbl_b_invoices.Content = count;
        }

        // ============================================================================================================== \\

        void Buttons_click_colors(Button b1, Button b2, Button b3, Label l1, Label l2,
           Label l3, string i1, string i2, string i3)
        {
            b1.Background = new SolidColorBrush(Color.FromRgb(191, 127, 127));
            b2.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));
            b3.Background = new SolidColorBrush(Color.FromRgb(232, 232, 232));

            b1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            b2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            b3.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));

            l1.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            l2.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));
            l3.Foreground = new SolidColorBrush(Color.FromRgb(112, 112, 112));

            im1.Source = new BitmapImage(new Uri(i1, UriKind.Relative));
            im2.Source = new BitmapImage(new Uri(i2, UriKind.Relative));
            im3.Source = new BitmapImage(new Uri(i3, UriKind.Relative));
        }

        // ============================================================================================================== \\

        private void ShowDoc()
        {
            string number = Convert.ToString(txt_no_f.Text);

            Data_conn("SELECT k.najemca FROM Faktury f, Wynajmy w, Klienci k WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu AND w.Id_Klienta = k.Id_Klienta");
            lbl_n_name.Content = (string)connection.cmd.ExecuteScalar();

            Data_conn("SELECT k.adres_zameldowania FROM Faktury f, Wynajmy w, Klienci k WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu AND w.Id_Klienta = k.Id_Klienta");
            textblock_n_address.Text = (string)connection.cmd.ExecuteScalar();

            Data_conn("SELECT k.typ_klienta FROM Faktury f, Wynajmy w, Klienci k WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu AND w.Id_Klienta = k.Id_Klienta");
            string type = (string)connection.cmd.ExecuteScalar();
            if (type == "indywidualny")
            {
                Data_conn("SELECT k.pesel FROM Faktury f, Wynajmy w, Klienci k WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu AND w.Id_Klienta = k.Id_Klienta");
                lbl_n_no.Content = (string)connection.cmd.ExecuteScalar();
            }
            else if (type == "firma")
            {
                Data_conn("SELECT k.nip FROM Faktury f, Wynajmy w, Klienci k WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu AND w.Id_Klienta = k.Id_Klienta");
                lbl_n_no.Content = (string)connection.cmd.ExecuteScalar();
            }

            lbl_f_no.Content = number;

            Data_conn("SELECT w.data_wydania FROM Wynajmy w, Faktury f WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu");
            DateTime data_od = (DateTime)connection.cmd.ExecuteScalar();
            lbl_start_date.Content = Convert.ToString(data_od);

            Data_conn("SELECT w.data_odbioru FROM Wynajmy w, Faktury f WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu");
            DateTime data_do = (DateTime)connection.cmd.ExecuteScalar();
            lbl_finish_date.Content = Convert.ToString(data_do);

            Data_conn("SELECT data_wystawienia FROM Faktury WHERE nr_faktury = '" + number + "'");
            DateTime data_w = (DateTime)connection.cmd.ExecuteScalar();
            lbl_today_date.Content = Convert.ToString(data_w);


            Data_conn("SELECT sposob_platnosci FROM Faktury WHERE nr_faktury = '" + number + "'");
            lbl_payment.Content = (string)connection.cmd.ExecuteScalar();

            Data_conn("SELECT termin_platnosci FROM Faktury WHERE nr_faktury = '" + number + "'");
            DateTime data_p = (DateTime)connection.cmd.ExecuteScalar();
            lbl_payment_date.Content = Convert.ToString(data_p);

            Data_conn("SELECT usluga FROM Faktury WHERE nr_faktury = '" + number + "'");
            lbl_txt.Content = (string)connection.cmd.ExecuteScalar();

            Data_conn("SELECT c.kwota_dobowa FROM Wynajmy w, Faktury f, Cenniki c WHERE f.nr_faktury = '" + number + "' AND f.Id_Wynajmu = w.Id_Wynajmu AND w.Id_Cennika = c.Id_Cennika");
            double c = (double)connection.cmd.ExecuteScalar();
            lbl_day_c.Content = c;

            Data_conn("SELECT suma_dni FROM Faktury WHERE nr_faktury = '" + number + "'");
            int d = (int)connection.cmd.ExecuteScalar();
            lbl_day.Content = Convert.ToString(d);

            double s_brutto = c * d;
            double vat = s_brutto * 0.23;
            double s_netto = s_brutto - vat;

            lbl_netto.Content = Convert.ToString(s_netto);
            lbl_brutto.Content = Convert.ToString(s_brutto);
        }

        // ============================================================================================================== \\

        private void Create_Document()
        {
            try
            {
                //create app;
                Word.Application WordApp = new Word.Application();
                WordApp.Visible = true;
                WordApp.WindowState = Word.WdWindowState.wdWindowStateNormal;


                //create doc;
                Word.Document doc = WordApp.Documents.Add();

                //create paragraph;
                Word.Paragraph para = doc.Paragraphs.Add();
                para.Range.Text = "----------------- F A K T U R A nr " + Convert.ToString(lbl_f_no.Content) + " ------------------  \r\n \r\n";
                para.Range.Text = "--------------------------------------------------------------------------- \r\n ";
                para.Range.Text = "Najemca: \r\n ";
                para.Range.Text = Convert.ToString(lbl_n_name.Content) + " \r\n ";
                para.Range.Text = Convert.ToString(textblock_n_address.Text) + " \r\n ";
                para.Range.Text = Convert.ToString(lbl_n_no.Content) + " \r\n ";
                para.Range.Text = "--------------------------------------------------------------------------- \r\n ";
                para.Range.Text = "Kwota netto: " + Convert.ToString(lbl_netto.Content) + " \r\n ";
                para.Range.Text = "Kwota brutto: " + Convert.ToString(lbl_brutto.Content) + " \r\n ";
                para.Range.Text = "VAT: 23%  \r\n  ";
                
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                path = path + "\\faktura_"; 
                
                doc.SaveAs2(path + lbl_f_no.Content + ".docx");

                MessageBox.Show("Tworzenie dokumentu zakończyło się pomyślnie. Plik znajduje się na pulpicie.", "Komunikat.");
                doc.Close();
                WordApp.Quit();
            }
            catch
            {
                MessageBox.Show("Wystąpił nieoczekiwany błąd, spróbuj ponownie.", "Błąd");
            }

        }


    }
}
