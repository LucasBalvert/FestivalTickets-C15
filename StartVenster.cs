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
    public partial class StartVenster : Form
    {
        public StartVenster()
        {
            InitializeComponent();
        }

        private void Festivaltickets_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bewerkenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();

            var festivalTicketForm = new FestivalTickets();
            festivalTicketForm.ShowDialog();
            Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info form2 = new Info();
            form2.Show();
       
        }

        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Over form3 = new Over();
            form3.Show();

        }

        private void afsluitenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult resultaat = MessageBox.Show(
                "Weet u zeker dat u het programma wilt afsluiten?",
                "Afsluiten",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultaat == DialogResult.No)
            {
                return;
            }
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void festivalStandToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
