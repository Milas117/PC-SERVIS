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
    public partial class Servis_unos : Form
    {
        public string prijavljeni;
        public int cijena;
        public string kvar;
        public string datum;
        public string korisnik;
        public int id;
        public string klijent;
        List<Servis_unos> servisi = new List<Servis_unos>();
        public Servis_unos(string prijava)
        {
            
            InitializeComponent();
            prijavljeni = prijava;  
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Baza.conn();

            con.Open();




            string zadatak = "INSERT INTO Servis_racunala(kvar,cijena,klijent,datum,Korisnik,Oznaka_potvrde)  VALUES('" + this.textBox1.Text + "' ,  " + this.textBox2.Text + " , '" + this.textBox3.Text + "', '" + this.dateTimePicker1.Text + "' ,'"+this.prijavljeni+"','N'  );";
            SqlCommand cmd = new SqlCommand(zadatak, con); 

            cmd.ExecuteNonQuery();
            con.Close();
            this.textBox1.Text = " ";
            this.textBox2.Text = " ";
            this.textBox3.Text = " ";
            

            MessageBox.Show("Servis spremljen!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izbornik open = new Izbornik(prijavljeni);
            this.Hide();
            open.Show();
        }

        private void Servis_unos_Load(object sender, EventArgs e)
        {

        }
    }
}
