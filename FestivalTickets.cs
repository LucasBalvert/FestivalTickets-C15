using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FestivalTickets_C15
{
    public partial class FestivalTickets : Form
    {
        private string naam;
        private string email;
        private string emailO;
        private string leeftijd;
        private string dag;
        private string klasse;
        private string muntjes;
        private string verzendmethode;
        private string tickets;

        public FestivalTickets()
        {
            InitializeComponent();
            label_resultaat.Text = String.Empty;
        }

        private void button_reserveerTickets_Click(object sender, EventArgs e)
        {
            ReserveerTickets();
        }

        private void ReserveerTickets()
        { 
            string naam = textBox_naam.Text;
            string email = textBox_email.Text;
            string emailO = textBox_emailControle.Text;
            string leeftijd = comboBox_leeftijd.Text;
            string dag = "";
            string klasse = "";
            string muntjes = comboBox_muntjes.Text;
            string verzendmethode = "";
            string tickets = comboBox_tickets.Text;
            string uitslag = "";

            if (naam == "")
            {
                MessageBox.Show(this, "Je hebt geen naam ingevuld", "Naam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (email == "")
            {
                MessageBox.Show(this, "Je hebt geen e-mail ingevuld", "e-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // controleer of de e-mail adressen gelijk zijn
            if (email != emailO)
            {
                MessageBox.Show(this, "De e-mail adressen zijn niet hetzelfde", "e-mail adressen controle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBox_zaterdag.Checked)
            {
                dag = "zaterdag ";
            }
            if (checkBox_zondag.Checked)
            {
                if (checkBox_zaterdag.Checked) dag = dag + " & ";
                dag = dag + "zondag ";
            }

            if (radioButton_normaal.Checked)
            {
                klasse = "normaal";
            }
            else if (radioButton_VIP.Checked)
            {
                klasse = "VIP";
            }

            if (radioButton_email.Checked)
            {
                verzendmethode = "e-mail";
            }
            else if (radioButton_post.Checked)
            {
                verzendmethode = "Post (+ €2,95)";
            }

            uitslag =  "Hallo " + naam + ", uw e-mail is " + email + ". U bent " + leeftijd + " jaar oud";
            uitslag += " en u heeft gekozen voor " + dag;
            uitslag += ". U zit in klasse " + klasse + " en u heeft " + muntjes + " muntjes gereserveerd.";
            uitslag += " U heeft " + tickets + " tickets besteld die worden verzonden per " + verzendmethode + ".";
            uitslag += " Dank voor uw aankoop en veel plezier bij Festival Strand!";

            label_resultaat.Text = uitslag;
        }

    }
}
