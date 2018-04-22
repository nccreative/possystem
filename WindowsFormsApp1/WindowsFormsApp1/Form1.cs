using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printer = new PrintDocument();
            printer.PrinterFont = new Font("Verdana", 18);

            printer.TextToPrint = " Hello World";
            System.Drawing.Printing.PrinterSettings newSettings = new System.Drawing.Printing.PrinterSettings();
            printer.PrinterSettings.PrinterName = "HP209535 (HP Photosmart 7510 series)";
            printer.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            String connString;
            connString = "SERVER=162.241.216.125;PORT=3306;DATABASE=cmleduco_kidswearinventory;UID=cmleduco_cozy;PASSWORD=cozycradles";
            
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string query = "SELECT first_name FROM account WHERE id='1'";

            using (var command = new MySqlCommand(query, conn))
            {
                
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //topmargin.Text = reader.GetString(0);
                        PrintDocument printer = new PrintDocument();
                        printer.PrinterFont = new Font("Verdana", 18);

                        printer.TextToPrint = reader.GetString(0);
                        System.Drawing.Printing.PrinterSettings newSettings = new System.Drawing.Printing.PrinterSettings();
                        printer.PrinterSettings.PrinterName = "HP209535 (HP Photosmart 7510 series)";
                        printer.Print();
                    }
                }
                

                reader.Close();
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            String connString;
            connString = "SERVER=162.241.216.125;PORT=3306;DATABASE=cmleduco_kidswearinventory;UID=cmleduco_cozy;PASSWORD=cozycradles";

            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string query = "INSERT account (first_name) VALUES ('test')";

            using (var command = new MySqlCommand(query, conn))
            {
                topmargin.Text = "Insertion Finished,Affected Rows "+ command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
