using System;
using System.Drawing;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;
using System.Collections.Generic;
using System.IO;

namespace InterfataUtilizator_WindowsForms
{
    public partial class Farmacie : Form
    {
        // diferite constante
        private const int PRET_MINIM = 0;
        private const int PRET_MAXIM = 1000;
        private const int LIMITA = 10;

        IStocareData adminMedicamente;
        List<string> producatoriSelectati = new List<string>();

        // constructorul formei 
        public Farmacie()
        {
            InitializeComponent();
            adminMedicamente = StocareFactory.GetAdministratorStocare(); 
        }

        // adaugare
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            if (!ValidareFormular())
            {
                MessageBox.Show("eroare");
                ResetareControale();
                return;
            }

            List<Medicament> medicamente;
            medicamente = adminMedicamente.GetMedicamente();
            int nrMedicamente = medicamente.Count;
            Medicament.IdLastMedicament = nrMedicamente;

            Medicament medicament = new Medicament();

            medicament.Denumire = txtDenumire.Text;
            medicament.Pret = float.Parse(txtPrt.Text);
            medicament.Forma = txtFrm.Text;

            CategorieMed? categorieSelectata = GetCategorieSelectata();
            if (categorieSelectata.HasValue)
            {
                medicament.Categorie = categorieSelectata.Value;
            }

            medicament.ProducatoriMedicamente = new List<string>();
            medicament.ProducatoriMedicamente.AddRange(producatoriSelectati);

            adminMedicamente.AddMedicament(medicament);
            ResetareControale();
        }
        
        // validare formular 
        private bool ValidareFormular()
        {
            bool OK = false;
            if (txtDenumire.Text == String.Empty)
            {
                lblDenumire.ForeColor = Color.Red;
                OK = true;
            }
            if (txtPrt.Text == String.Empty)
            {
                lblPret.ForeColor = Color.Red;
                OK = true;
            }
            if (txtFrm.Text == String.Empty)
            {
                lblForma.ForeColor = Color.Red;
                OK = true;
            }
        
            float pretMedicament;
            float.TryParse(txtPrt.Text, out pretMedicament);
            if (pretMedicament <= PRET_MINIM || pretMedicament > PRET_MAXIM)
            {
                lblPret.ForeColor = Color.Red;
                OK = true;
            }

            if (OK)
                return false;
            return true;
        }

        // afisare
        private void btnAfiseaza_Click(object sender, EventArgs e)
        {
            comboBoxMedicamente.Items.Clear();
            lstMedicamente.Items.Clear();

            var antetTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", "Id", "Denumire", "Pret", "Categorie", "Forma", "Producator");

            List<Medicament> medicamente = adminMedicamente.GetMedicamente();
            foreach(Medicament medicament in medicamente)
            {
                var linieTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", medicament.IdMedicament, medicament.Denumire, medicament.Pret, medicament.Categorie, medicament.Forma, medicament.ProducatoriAsString);
                lstMedicamente.Items.Add(linieTabel);
                comboBoxMedicamente.Items.Add(linieTabel);
            }
        }

        // cautare
        private void btnCauta_Click(object sender, EventArgs e)
        {
        }

        // modificare
        private void btnModifica_Click(object sender, EventArgs e)
        {
            Medicament medicament = adminMedicamente.GetMedicament(lstMedicamente.SelectedIndex);
            medicament.Denumire = txtDenumire.Text;
            medicament.Pret = float.Parse(txtPrt.Text);
            adminMedicamente.UpdateMedicament(medicament);
            lstMedicamente.Items.Clear();
            Afisare();
        }

        // metoda ce va afisa
        private void Afisare()
        {
            comboBoxMedicamente.Items.Clear();
            lstMedicamente.Items.Clear();

            var antetTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", "Id", "Denumire", "Pret", "Categorie", "Forma", "Producator");

            List<Medicament> medicamente = adminMedicamente.GetMedicamente();
            foreach (Medicament medicament in medicamente)
            {
                var linieTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", medicament.IdMedicament, medicament.Denumire, medicament.Pret, medicament.Categorie, medicament.Forma, medicament.ProducatoriAsString);
                lstMedicamente.Items.Add(linieTabel);
                comboBoxMedicamente.Items.Add(linieTabel);
            }
        }

        // resetare controale din formularul Farmacie
        private void ResetareControale()
        {
            lblDenumire.ForeColor = Color.Empty;
            lblPret.ForeColor = Color.Empty;
            lblForma.ForeColor = Color.Empty;
            txtDenumire.Text = txtPrt.Text = txtFrm.Text = string.Empty;
            rdb1.Checked = false;
            rdb2.Checked = false;
            rdb3.Checked = false;
            rdb5.Checked = false;
            rdb4.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
            checkBox4.Checked = false;
            producatoriSelectati.Clear();
            lblMesaj.Text = string.Empty; 
        }

        // verificare checkbox 
        private void ckbProducator_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; 
            string categorieSelectata = checkBoxControl.Text;
            if (checkBoxControl.Checked == true)
                producatoriSelectati.Add(categorieSelectata);
            else
                producatoriSelectati.Remove(categorieSelectata);
        }

        // verifica ce categorie a medicamentului a fost selectata in formular 
        private CategorieMed? GetCategorieSelectata()
        {
            if (rdb1.Checked)
                return CategorieMed.Analgezice;
            if (rdb2.Checked)
                return CategorieMed.ProduseDermatologice;
            if (rdb3.Checked)
                return CategorieMed.Antiseptice;
            if (rdb4.Checked)
                return CategorieMed.Vitamine;
            if (rdb5.Checked)
                return CategorieMed.Antibiotice;
            return null;
        }

        // afiseaza medicamentul selectat 
        private void lstMedicamente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Medicament medicament = adminMedicamente.GetMedicament(lstMedicamente.SelectedIndex);

            ResetareControale(); 

            txtDenumire.Text = medicament.Denumire;
            txtPrt.Text = string.Format($"{medicament.Pret}");
            txtFrm.Text = medicament.Forma;

            switch (medicament.Categorie)
            {
                case CategorieMed.Analgezice: rdb1.Checked = true; break;
                case CategorieMed.Antibiotice: rdb2.Checked = true; break;
                case CategorieMed.Antiseptice: rdb3.Checked = true; break;
                case CategorieMed.ProduseDermatologice: rdb4.Checked = true; break;
                case CategorieMed.Vitamine: rdb5.Checked = true; break;
            }

            foreach (string a in medicament.ProducatoriMedicamente)
            {
                if (a.Equals("Biofarm"))
                    checkBox1.Checked = true;
                if (a.Equals("LaborMedPharma"))
                    checkBox2.Checked = true;
                if (a.Equals("Sandoz"))
                    checkBox3.Checked = true;
                if (a.Equals("Sun_Pharma"))
                    checkBox4.Checked = true;
                if (a.Equals("HoffmannlaRoche"))
                    checkBox5.Checked = true;
            }
        }

        // afiseaza medicamentul selectat 
        private void comboBoxMedicamente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Medicament medicament = adminMedicamente.GetMedicament(comboBoxMedicamente.SelectedIndex);

            ResetareControale();

            txtDenumire.Text = medicament.Denumire;
            txtPrt.Text = string.Format($"{medicament.Pret}");
            txtFrm.Text = medicament.Forma;

            switch (medicament.Categorie)
            {
                case CategorieMed.Analgezice: rdb1.Checked = true; break;
                case CategorieMed.Antibiotice: rdb2.Checked = true; break;
                case CategorieMed.Antiseptice: rdb3.Checked = true; break;
                case CategorieMed.ProduseDermatologice: rdb4.Checked = true; break;
                case CategorieMed.Vitamine: rdb5.Checked = true; break;
            }

            foreach (string a in medicament.ProducatoriMedicamente)
            {
                if (a.Equals("Biofarm"))
                    checkBox1.Checked = true;
                if (a.Equals("LaborMedPharma"))
                    checkBox2.Checked = true;
                if (a.Equals("Sandoz"))
                    checkBox3.Checked = true;
                if (a.Equals("Sun_Pharma"))
                    checkBox4.Checked = true;
                if (a.Equals("HoffmannlaRoche"))
                    checkBox5.Checked = true;
            }
        }

        // metoda ce va filtra medicamente care au un pret mai mare decat un anumit numar 
        private void btnFiltrare_Click(object sender, EventArgs e)
        {
            List<Medicament> medicamente = adminMedicamente.GetMedicamente();
            List<Medicament> medicamenteFiltrare = new List<Medicament>();
            foreach (Medicament medicament in medicamente)
            {
                if (medicament.Pret >= LIMITA)
                {
                    medicamenteFiltrare.Add(medicament);
                }
            }
            AdaugaMedicamenteInControlulDataGridView(medicamenteFiltrare);
        }

        private void AdaugaMedicamenteInControlulDataGridView(List<Medicament> medicamente)
        {
            dataGridViewMedicamente.DataSource = null;
            dataGridViewMedicamente.DataSource = medicamente;
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "Medicamente";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; //afisare extensia txt
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamWriter swFisierText = new StreamWriter(saveFileDialog.FileName, true))
                {
                    List<Medicament> medicamente = adminMedicamente.GetMedicamente();
                    foreach (Medicament medicament in medicamente)
                        swFisierText.WriteLine(medicament.ConversieLaSir_PentruScriereInFisier());
                }
            }
        }

        private void medicamentNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetareControale();
        }

        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxMedicamente.Items.Clear();
            lstMedicamente.Items.Clear();

            var antetTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", "Id", "Denumire", "Pret", "Categorie", "Forma", "Producator");

            List<Medicament> medicamente = adminMedicamente.GetMedicamente();
            foreach (Medicament medicament in medicamente)
            {
                var linieTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", medicament.IdMedicament, medicament.Denumire, medicament.Pret, medicament.Categorie, medicament.Forma, medicament.ProducatoriAsString);
                lstMedicamente.Items.Add(linieTabel);
                comboBoxMedicamente.Items.Add(linieTabel);
            }
        }

       

        private void formaNouaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formaNoua = new NewFormFarmacie();
            formaNoua.Show();
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gpbProgrameStudiu_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewMedicamente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Farmacie_Load(object sender, EventArgs e)
        {

        }

        private void lblUtilitare_Click(object sender, EventArgs e)
        {

        }

        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coroama Betuela Madalina Grupa: 3123A");
        }

        private void informatiiAutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coroama Betuela Madalina Grupa: 3123A");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coroama Betuela Madalina Grupa: 3123A");
        }
    }
}
