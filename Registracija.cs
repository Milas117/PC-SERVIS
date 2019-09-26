using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prijava open = new Prijava();
            this.Hide();
            open.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                var con = Baza.conn();
                con.Open();
                string zadatak = "INSERT INTO Korisnik (Ime,Prezime,korisnik, lozinka)  VALUES( '" + this.textBox1.Text + "' ,'" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "')";
                SqlCommand cmdnar = new SqlCommand(zadatak, con);

                cmdnar.ExecuteNonQuery();

                textBox2.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                con.Close();

                MessageBox.Show("Korisnik spremljen !");
            
        }

        private void Registracija_Load(object sender, EventArgs e)
        {

        }
    }
}
