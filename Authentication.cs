using Microsoft.AspNetCore.Http.Connections.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Authentication : Form
    {
        static HttpClient client = new HttpClient();
        HttpConnection connection;
        SqlConnection sqlConnection;
        public Authentication()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "";
            client.BaseAddress = new Uri("https://localhost:7031");

        }
        private async void Window_Loaded(object sender, EventArgs e)
        {
            try
            {
                await connection.StartAsync();
                label2.Text = "good";

            }
            catch(Exception exp)
            {
                label1.Text = exp.Message;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var sqlCommand = new SqlCommand();
            sqlConnection.ConnectionString = "";
            sqlCommand.CommandText = $"SELECT Id FROM Users WHERE UserLogin = {login}";
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
           
            using (SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
            {
                if (!reader.HasRows) // если есть данные
                {
                    label2.Text = "Проверьте правильность логина или зарегистрируйтесь.";
                }
                else
                {
                    string userId = reader.GetName(0);
                    var mainMenu = new MainMenu(sqlConnection, userId);
                    mainMenu.Show();
                }
            }
            
        }
    }
}
