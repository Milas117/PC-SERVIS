
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
    public partial class Pregled : Form
    {
        List<Servis_unos> servisi = new List<Servis_unos>();
        private string prijava;
        public Pregled(string prijava1)
        {
            InitializeComponent();
            prijava = prijava1;
            Ispisi(prijava); 
        }

         public void Ispisi(string prijava)
        {
            label2.Text = prijava; 
            var con = Baza.conn();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Servis_racunala where Korisnik ='"+this.label2.Text+"' and Oznaka_potvrde='N'", con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            while (reader.Read())
            {
                
                Servis_unos prebacivanje = new Servis_unos(prijava);
                prebacivanje.kvar = (string)reader["kvar"];
                prebacivanje.klijent = (string)reader["klijent"];
                prebacivanje.datum = (string)reader["datum"];
                prebacivanje.cijena = (int)reader["cijena"];
                prebacivanje.korisnik = (string)reader["Korisnik"];
                prebacivanje.id = (int)reader["Id"];          
                servisi.Add(prebacivanje);

               


            }
            foreach (var s in servisi)
            {
               
                
                
                    string[] red = { s.id.ToString(), s.kvar, s.cijena.ToString(), s.klijent,s.datum, s.korisnik };
                    var redak = new ListViewItem(red);
                   
                    listView1.Items.Add(redak); 
                
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Izbornik open = new Izbornik(prijava);
            open.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var con = Baza.conn(); 
            con.Open();
            string izvadi = "select * from  Servis_racunala where id = '" + textBox1.Text + "'  and Korisnik = '"+prijava+"'; ";
            SqlCommand izvadi_cmd = new SqlCommand(izvadi, con);
            SqlDataReader prijenos;
            prijenos = izvadi_cmd.ExecuteReader();
            if (prijenos.Read())
            {
                textBox2.Text = (prijenos["Kvar"].ToString());
                textBox3.Text = (prijenos["cijena"].ToString());
                textBox4.Text = (prijenos["klijent"].ToString());
                dateTimePicker1.Text = (prijenos["datum"].ToString());
                
                


            }
            else
            {


               

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Text = "";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            var con = Baza.conn();
            con.Open();
            SqlDataReader citac;
            string izmjeni = "UPDATE  Servis_racunala set kvar = '" + this.textBox2.Text + "'  where id = '" + textBox1.Text + "' ; ";
            SqlCommand cmd = new SqlCommand(izmjeni, con);

            citac = cmd.ExecuteReader();
            citac.Close();



            izmjeni = "UPDATE  Servis_racunala set cijena = '" + this.textBox3.Text + "'  where id = '" + textBox1.Text + "' ; ";
            cmd = new SqlCommand(izmjeni, con);
            citac = cmd.ExecuteReader();
            citac.Close();


            izmjeni = "UPDATE  Servis_racunala set klijent = '" + this.textBox4.Text + "'  where id = '" + textBox1.Text + "' ; ";
            cmd = new SqlCommand(izmjeni, con);
            citac = cmd.ExecuteReader();
            citac.Close();



            izmjeni = "UPDATE  Servis_racunala set datum = '" + this.dateTimePicker1.Text + "'  where id = '" + textBox1.Text + "' ; ";
            cmd = new SqlCommand(izmjeni, con);
            citac = cmd.ExecuteReader();
            citac.Close();

            servisi.Clear();
            listView1.Items.Clear();
            Ispisi(prijava);
            con.Close();
            MessageBox.Show(" Izmjenjeno");
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            var con = Baza.conn();
            con.Open();
            string brisi = "delete from  Servis_racunala where id = '" + textBox1.Text + "' ; ";
            SqlCommand brisi_cmd = new SqlCommand(brisi, con);
            SqlDataReader citac;
            citac = brisi_cmd.ExecuteReader();
            if (citac.Read())
            {
                con.Close();
                listView1.Items.Clear();
                

                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                MessageBox.Show("Obrisano");
            }
            else
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";

            }


            servisi.Clear();
            listView1.Items.Clear();
            Ispisi(prijava);
            con.Close();

        }

        private void Pregled_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
