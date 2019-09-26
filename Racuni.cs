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
    public partial class Racuni : Form
    {
        List<Servis_unos> servisi = new List<Servis_unos>();
        List<Racuni> racuni = new List<Racuni>();
        public int broj;
        public string klijent;
        public int dodatak ;
        private string prijava;
        public int cijena;
        public Racuni(string prijava1)
        {
            InitializeComponent();
            prijava = prijava1;
            Ispisi(prijava);
        }

        public void Ispisi(string prijava)
        { // sve isto kao i u formu 'Pregled'
            
            var con = Baza.conn();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Servis_racunala where Korisnik ='"+this.prijava+ "' and Korisnik = '" + prijava + "' and Oznaka_potvrde ='N'", con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
    
            while (reader.Read())
            {

                Servis_unos prebacivanje = new Servis_unos(prijava);
                prebacivanje.kvar = (string)reader["kvar"];
                prebacivanje.klijent = (string)reader["klijent"];
                prebacivanje.cijena = (int)reader["cijena"];
                prebacivanje.id = (int)reader["Id"];
                servisi.Add(prebacivanje);




            }
            foreach (var s in servisi)
            {
                


                string[] red = { s.id.ToString(),  s.klijent, s.cijena.ToString(), s.kvar };
                var redak = new ListViewItem(red);

                listView1.Items.Add(redak);

            }
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        { 
          
                var con = Baza.conn();

                con.Open();
                string izvadi = "select * from  Servis_racunala where id = '"+textBox5.Text+"'  ; ";
                SqlCommand izvadi_cmd = new SqlCommand(izvadi, con);
                SqlDataReader prijenos;
                prijenos = izvadi_cmd.ExecuteReader();
                if (prijenos.Read())
                {
                
                    textBox3.Text = (prijenos["cijena"].ToString());
                    textBox2.Text = (prijenos["klijent"].ToString());
                    cijena = Int32.Parse(textBox3.Text);




                }
                else
                {




                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    
                }
                con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            var con = Baza.conn();

            con.Open();
            int dodatak = Int32.Parse(textBox4.Text);
            cijena =+dodatak;




            string zadatak = "INSERT INTO Racun(cijena,klijent,Korisnik)  VALUES("+this.cijena+" ,  '"+this.textBox2.Text+"' , '"+prijava+"'  );";
            SqlCommand cmd = new SqlCommand(zadatak, con); 
            cmd.ExecuteNonQuery();

            string update = "Update Servis_racunala set Oznaka_potvrde ='D' where id= '"+textBox5.Text+"';"; 
            

            SqlCommand upcmd = new SqlCommand(update, con);
            upcmd.ExecuteNonQuery();
            con.Close();
            


            MessageBox.Show("Racun izdan !");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izbornik open = new Izbornik(prijava);
            open.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                int ukupno = cijena + Int32.Parse(textBox4.Text);
                textBox6.Text = ukupno.ToString();
            }
            else
            {
                textBox4.Text = "0";
            }
                

        }

        private void Racuni_Load(object sender, EventArgs e)
        {

        }
    }
}
