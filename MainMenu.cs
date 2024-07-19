using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainMenu : Form
    {
        SqlConnection _connection;
        public MainMenu(SqlConnection connection, string userId)
        {
            InitializeComponent();
            _connection = connection;
        }

    }
}
