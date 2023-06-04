using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace To_Do_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=LocalHost;database=to_do_tracker;uid=root;pwd=root";

            string usuario = textBoxName.Text;
            string senha = textBoxPassword.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM user_login WHERE usuario = @usuario AND senha = @senha";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@senha", senha);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("passou");
                }
                else
                {
                    MessageBox.Show("usuario invalido");
                }

            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
