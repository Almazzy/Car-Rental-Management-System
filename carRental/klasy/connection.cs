using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace carRental.klasy
{
    class connection
    {
        public static string GetConnectionStrings()
        {

            string strConString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            return strConString;

        }

        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader rd;
        public static DataTable dt = new DataTable();
        public static SqlDataAdapter da = new SqlDataAdapter();



        public static void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = GetConnectionStrings();
                    con.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia" + Environment.NewLine + "Opis błędu: " + ex.Message.ToString(), "blabla", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            catch (Exception)
            {

            }




        }


    }
}
