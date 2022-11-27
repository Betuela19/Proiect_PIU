using System;
using System.Drawing;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;
using System.Collections.Generic;
using System.IO;

namespace InterfataUtilizator_WindowsForms
{
    public partial class NewFormFarmacie : Form
    {
        IStocareData adminMedicamente;
        public NewFormFarmacie()
        {
            InitializeComponent();
            adminMedicamente = StocareFactory.GetAdministratorStocare();
        }

        private void btnAfisare_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            lstMedicamente.Items.Clear();

            var antetTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", "Id", "Denumire", "Pret", "Categorie", "Forma", "Producator");

            List<Medicament> medicamente = adminMedicamente.GetMedicamente();
            foreach (Medicament medicament in medicamente)
            {
                var linieTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", medicament.IdMedicament, medicament.Denumire, medicament.Pret, medicament.Categorie, medicament.Forma, medicament.ProducatoriAsString);
                lstMedicamente.Items.Add(linieTabel);
                comboBox1.Items.Add(linieTabel);
            }
        }

        private void btnFiltrare_Click(object sender, EventArgs e)
        {
            List<Medicament> medicamente = adminMedicamente.GetMedicamente();
            List<Medicament> medicamenteFiltrare = new List<Medicament>();
            foreach (Medicament medicament in medicamente)
            {
                if (medicament.Pret >= 10)
                {
                    medicamenteFiltrare.Add(medicament);
                }
            }
            lstMedicamente.Items.Clear();

            foreach(Medicament medicament in medicamenteFiltrare)
            {
                var linieTabel = String.Format("{0} {1} {2} {3} {4} {5}\n", medicament.IdMedicament, medicament.Denumire, medicament.Pret, medicament.Categorie, medicament.Forma, medicament.ProducatoriAsString);
                lstMedicamente.Items.Add(linieTabel);
            }
        }

        private void NewFormFarmacie_Load(object sender, EventArgs e)
        {

        }
    }
}
