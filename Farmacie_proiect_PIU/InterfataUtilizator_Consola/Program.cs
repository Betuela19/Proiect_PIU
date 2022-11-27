using System;
using System.Collections;
using System.Collections.Generic;
using LibrarieModele;
using NivelAccesDate;

namespace InterfataUtilizator_Consola
{
    class Program
    {
        static void Main()
        {
            List<Medicament> medicamente;

            IStocareData adminMedicamente = StocareFactory.GetAdministratorStocare();
            medicamente = adminMedicamente.GetMedicamente();
            int nrMedicamente = medicamente.Count;
            Medicament.IdLastMedicament = nrMedicamente;

            Medicament aspirina = new Medicament("aspirina", 10);
            Medicament naproxen = new Medicament("naproxen", 20);
            aspirina.Forma = "pilule";
            naproxen.Forma = "pilule";
            aspirina.Categorie = CategorieMed.Antibiotice;
            naproxen.Categorie = CategorieMed.Antibiotice;

            List<string> producatori = new List<string>(new string[] { "BiofarmSA, LaborMed" });
            aspirina.ProducatoriMedicamente = producatori;

            string sirMedicament = "1; Medicament1; 10; Analgezice; Pilule; LaborMedPharma Biofarm";

            Medicament medicamentTastatura = new Medicament(sirMedicament);

            medicamente.Add(aspirina);
            medicamente.Add(naproxen);
            medicamente.Add(medicamentTastatura);

            for (int i = 0; i < medicamente.Count; i++)
                Console.WriteLine(medicamente[i].ConversieLaSir_PentruAfisare());

            Console.WriteLine("Scade / creste pretul unui medicament cu o valoare");

            Console.WriteLine((aspirina < 5).Pret);
            Console.WriteLine((aspirina > 10).Pret);
            Console.ReadKey();
        }
    }
}
