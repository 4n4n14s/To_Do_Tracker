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
using System.Security.Cryptography;
using Org.BouncyCastle.Utilities.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace To_Do_Tracker
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var voltar = new Form1();
            voltar.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                

                string userName = textBox1.Text;
                string userPassword = textBox2.Text;
                string confirmPassword = textBox3.Text;

                

                if (userPassword != confirmPassword)
                {
                    MessageBox.Show("as senhas não coencide ");

                }
                else
                {
                    string query = "INSERT INTO user_login (usuario, senha) VALUES(@username, @userPassword)";
                    string connectionString = "server=LocalHost;database=to_do_tracker;uid=root;pwd=root";
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@userName", userName);
                            command.Parameters.AddWithValue("@userPassword", userPassword);

                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("cadastro realizado");
                        var voltar = new Form1();
                        voltar.Show();
                        this.Close();


                    }





                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
