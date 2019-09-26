using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Izbornik : Form
    {
        public string prijava;
        public Izbornik(string prijavljeni )
        {
            InitializeComponent();
            prijava = prijavljeni;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servis_unos otvori = new Servis_unos(prijava);
            otvori.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pregled otvori = new Pregled(prijava);
            otvori.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Racuni open = new Racuni(prijava);
            open.Show();
            this.Hide();
        }

        private void Izbornik_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Gotovi_Servisi open = new Gotovi_Servisi(prijava);
            open.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Prijava open = new Prijava();
            open.Show();
            this.Hide();
        }
    }
}
