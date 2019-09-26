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
    public partial class Gotovi_Servisi : Form
    {
        private string prijavljeni;
        public int broj;
        public string klijent;
        public int cijena;

        List<Racuni> servisi = new List<Racuni>();
        public string prijava;
        public Gotovi_Servisi(string prijava)
        {
            InitializeComponent();
            prijavljeni = prijava;
            Ispisi(prijavljeni);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izbornik open = new Izbornik(prijavljeni);
            open.Show();
            this.Hide();

        }
        public void Ispisi(string prijavljeni)
        { 
            
            var con = Baza.conn();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Racun where Korisnik ='"+prijavljeni+"'", con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            while (reader.Read())
            {

                Racuni prebacivanje = new Racuni(prijava);
                prebacivanje.broj = (int)reader["Broj"];
                prebacivanje.klijent = (string)reader["klijent"];
                prebacivanje.cijena = (int)reader["cijena"];
                
               
                servisi.Add(prebacivanje);




            }
            foreach (var s in servisi)
            {
                


                string[] red = { s.broj.ToString(), s.cijena.ToString(), s.klijent};
                var redak = new ListViewItem(red);

                listView1.Items.Add(redak);

            }
            con.Close();
        }

        private void Gotovi_Servisi_Load(object sender, EventArgs e)
        {

        }
    }
}
