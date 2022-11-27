using System;
using System.Collections.Generic;

namespace LibrarieModele
{
    public class Medicament
    {
        // constante
        private const bool SUCCES = true;
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int ID = 0;
        private const int DENUMIRE = 1;
        private const int PRET = 2;
        private const int CATEGORIE = 3;
        private const int FORMA = 4;
        private const int PRODUCATOR = 5;

        // proprietati auto-implemented
        public int IdMedicament { get; set; }
        public static int IdLastMedicament { get; set; } = 0;
        public string Denumire { get; set; }
        public float Pret { get; set; }
        public string Forma { get; set; }
        public CategorieMed Categorie { get; set; }
        public List<string> ProducatoriMedicamente { get; set; }

        // adaugare producatori
        public string ProducatoriAsString
        {
            get
            {
                string sProducatori = string.Empty;

                foreach (string producator in ProducatoriMedicamente)
                {
                    if (sProducatori != string.Empty)
                    {
                        sProducatori += SEPARATOR_SECUNDAR_FISIER;
                    }
                    sProducatori += producator;
                }

                return sProducatori;
            }
        }

        #region _Constructori_
        // contructor implicit
        public Medicament()
        {
            Denumire = string.Empty;
            IdLastMedicament++;
            IdMedicament = IdLastMedicament;

            ProducatoriMedicamente = new List<string>();
        }
        // constructor care are 2 parametri 
        public Medicament(string _denumire, float pret)
        {
            Denumire = _denumire;
            Pret = pret;
            IdLastMedicament++;
            IdMedicament = IdLastMedicament;
            ProducatoriMedicamente = new List<string>();
        }
        // constructor care foloseste un sir din fisier 
        public Medicament(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            IdMedicament = Convert.ToInt32(dateFisier[ID]);
            Denumire = dateFisier[DENUMIRE];
            Pret = float.Parse(dateFisier[PRET]);
            Categorie = (CategorieMed)Enum.Parse(typeof(CategorieMed), dateFisier[CATEGORIE]);
            Forma = dateFisier[FORMA];
            ProducatoriMedicamente = new List<string>();
            ProducatoriMedicamente.AddRange(dateFisier[PRODUCATOR].Split(SEPARATOR_SECUNDAR_FISIER));

            IdLastMedicament = IdMedicament;
        }
        #endregion
        public string ConversieLaSir_PentruAfisare()
        {
            string sir = $"{IdMedicament.ToString()} {Denumire ?? " NECUNOSCUT "} {Pret.ToString() ?? " NECUNOSCUT "} {Categorie.ToString() ?? " NECUNOSCUT "} {Forma ?? " NECUNOSCUT "} {ProducatoriAsString ?? " NECUNOSCUT "}";
            return sir;
        }

        public string ConversieLaSir_PentruScriereInFisier()
        {
            string sir = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                            SEPARATOR_PRINCIPAL_FISIER, IdMedicament.ToString(), Denumire, Pret, Categorie, Forma, ProducatoriAsString);
            return sir;
        }

        // supradefinirea operatorului < din tema de laborator 
        public static Medicament operator < (Medicament medicament, float pret)
        {
            medicament.Pret -= pret;

            return medicament;
        }

        // supradefinirea operatorului > din tema de laborator 
        public static Medicament operator > (Medicament medicament, float pret)
        {
            medicament.Pret += pret;

            return medicament;
        }
    }
}
