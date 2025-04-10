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
            decimal prijs = 0;
            decimal verzendkosten = 0;
            int aantalTickets = 1;
            decimal prijsPerMunt = 2.00m;
            int aantalMuntjes = 0;


            if (naam == "")
            {
                MessageBox.Show(this, "Geen naam ingevuld", "Naam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (email == "")
            {
                MessageBox.Show(this, "Geen e-mail ingevuld", "E-mail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show(this, "Ongeldig e-mailadres: ontbreekt '@'", "E-mailcontrole", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (email != emailO)
            {
                MessageBox.Show(this, "De e-mail adressen zijn niet hetzelfde", "E-mail adressen controle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (leeftijd == "")
            {
                MessageBox.Show(this, "Geen leeftijd ingevoerd", "Leeftijd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!checkBox_zaterdag.Checked && !checkBox_zondag.Checked)
            {
                MessageBox.Show(this, "Geen dag geselecteerd", "Dag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!radioButton_normaal.Checked && !radioButton_VIP.Checked)
            {
                MessageBox.Show(this, "Geen klasse geselecteerd", "Klasse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (muntjes == "")
            {
                MessageBox.Show(this, "Geen aantal muntjes geselecteerd", "Muntjes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(muntjes, out aantalMuntjes))
            {
                MessageBox.Show(this, "Aantal muntjes is ongeldig", "Muntjes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!radioButton_email.Checked && !radioButton_post.Checked)
            {
                MessageBox.Show(this, "Geen verzendmethode geselecteerd", "Verzendmethode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tickets == "")
            {
                MessageBox.Show(this, "Geen aantal tickets geselecteerd", "Tickets", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBox_zaterdag.Checked)
            {
                dag = "zaterdag";
            }
            if (checkBox_zondag.Checked)
            {
                if (checkBox_zaterdag.Checked) dag = dag + " & ";
                dag = dag + "zondag";
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

            if (!int.TryParse(tickets, out aantalTickets))
            {
                MessageBox.Show(this, "Aantal tickets is ongeldig", "Tickets", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBox_zaterdag.Checked) dag = "zaterdag";
            if (checkBox_zondag.Checked)
            {
                if (dag != "") dag += " & ";
                dag += "zondag";
            }

            if (radioButton_normaal.Checked) klasse = "normaal";
            else if (radioButton_VIP.Checked) klasse = "VIP";

            if (radioButton_email.Checked)
            {
                verzendmethode = "e-mail";
            }
            else
            {
                verzendmethode = "Post (+ €2,95)";
                verzendkosten = 2.95m;
            }

            decimal basisPrijs = 0;

            if (checkBox_zaterdag.Checked && checkBox_zondag.Checked)
            {
                basisPrijs = (klasse == "VIP") ? 45.00m : 27.50m;
            }
            else if (checkBox_zaterdag.Checked || checkBox_zondag.Checked)
            {
                basisPrijs = (klasse == "VIP") ? 25.00m : 15.00m;
            }

            prijs = (basisPrijs * aantalTickets) + verzendkosten + (aantalMuntjes * prijsPerMunt);

            uitslag =  "Hallo " + naam + ", uw e-mail is " + email + ". U bent " + leeftijd + " jaar oud";
            uitslag += " en u heeft gekozen voor " + dag;
            uitslag += ". U zit in klasse " + klasse + " en u heeft " + muntjes + " muntjes gereserveerd.";
            uitslag += " U heeft " + tickets + " tickets besteld die worden verzonden per " + verzendmethode + ".";
            uitslag += " De totale prijs is €" + prijs.ToString("0.00") + ".";
            uitslag += " Dank voor uw aankoop en veel plezier bij Festival Strand!";

            label_resultaat.Text = uitslag;
            label_prijs.Text = "Totale prijs: €" + prijs.ToString("0.00");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox_zaterdag.Checked = false;
            checkBox_zondag.Checked = false;
            radioButton_normaal.Checked = false;
            radioButton_VIP.Checked = false;
            comboBox_muntjes.SelectedIndex = -1;
            radioButton_email.Checked = false;
            radioButton_post.Checked = false;
            comboBox_tickets.SelectedIndex = -1;
            label_resultaat.Text = " ";
            label_prijs.Text = " ";
        }

        private void textBox_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }
    }
}
