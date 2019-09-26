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
    
    public partial class Prijava : Form
    {
        public string prijavljeni;

        public Prijava()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registracija open = new Registracija();
            open.Show();
            this.Hide(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var con = Baza.conn(); 
            prijavljeni = textBox1.Text;
            con.Open();
            SqlDataAdapter prijava = new SqlDataAdapter("select count(*) from Korisnik where korisnik='" + textBox1.Text + "'and lozinka = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            prijava.Fill(dt);  
            if (dt.Rows[0][0].ToString() == "1")
            {
                Izbornik otvori = new Izbornik(prijavljeni);
                this.Hide();
                otvori.Show();
                Servis_unos otvori_= new Servis_unos(prijavljeni);
                MessageBox.Show(" Korisnik " +prijavljeni+" prijavljen"); 
                
            }
            else MessageBox.Show("Pogresno korisnicko ime ili lozinka");
        }

        private void Prijava_Load(object sender, EventArgs e)
        {

        }
    }
}
