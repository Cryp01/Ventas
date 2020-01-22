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

namespace Ventas2
{
    public partial class Form1 : Form
    {
        //AA

        MySqlConnection conexion = new MySqlConnection("Server=Localhost; Database=market_ventas; Uid=root; Pwd=12345678");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
            }
            catch
            {
                MessageBox.Show("Error en la conexion");
            }
            //AB
            MySqlCommand iniciar = new MySqlCommand();
            iniciar.Connection = conexion;
            iniciar.CommandText = ("SELECT * FROM usuarios WHERE Usuario = '" + textBox1.Text + "'AND Contrasena = '"+ textBox2.Text + "'");
            //AC
            MySqlDataReader Verificar = iniciar.ExecuteReader();
            //AD
            if (Verificar.Read())
            {
                this.Hide();
                Form2 Menu = new Form2();
                Menu.Show();
            }
            else
            {
                MessageBox.Show("Verifique el usuario o la contraseña");
            }
            conexion.Close();
        }
    }
}
