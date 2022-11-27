using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NivelAccesDate
{
    public class AdministrareMedicamente_FisierText : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareMedicamente_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void AddMedicament(Medicament medicament)
        {
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(medicament.ConversieLaSir_PentruScriereInFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public List<Medicament> GetMedicamente()
        {
            List<Medicament> medicamente = new List<Medicament>();
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string linieDinFisier;

                    // citeste cate o linie si creaza un obiect de tip Medicament pe baza datelor din linia citita
                    while ((linieDinFisier = sr.ReadLine()) != null)
                    {
                        Medicament medicamentDinFisier = new Medicament(linieDinFisier);
                        medicamente.Add(medicamentDinFisier);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return medicamente;
        }

        public Medicament GetMedicament(string _denumire)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string linieDinFisier;

                    // citeste cate o linie si creaza un obiect de tip Medicament pe baza datelor din linia citita
                    while ((linieDinFisier = sr.ReadLine()) != null)
                    {
                        Medicament medicament = new Medicament(linieDinFisier);
                        if (medicament.Denumire.Equals(_denumire))
                            return medicament;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }

        public Medicament GetMedicament(int idMedicament)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string linieDinFisier;
                    // citeste cate o linie si creaza un obiect de tip Medicament pe baza datelor din linia citita
                    while ((linieDinFisier = sr.ReadLine()) != null)
                    {
                        Medicament medicament = new Medicament(linieDinFisier);
                        if (medicament.IdMedicament == idMedicament + 1)
                        {
                            return medicament;
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }

        public bool UpdateMedicament(Medicament medicamentActualizat)
        {
            List<Medicament> medicamente = GetMedicamente();
            bool actualizareCuSucces = false;
            try
            {
                // instructiunea 'using' va apela la final swFisierText.Close();
                // al doilea parametru setat la 'false' al constructorului StreamWriter indica modul 'overwrite' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    foreach (Medicament medicament in medicamente)
                    {
                        Medicament medicamentPentruScrisInFisier = medicament;
                        // informatiile despre medicamentul actualizat vor fi preluate din parametrul "medicamentActualizat"
                        if (medicament.IdMedicament == medicamentActualizat.IdMedicament)
                        {
                            medicamentPentruScrisInFisier = medicamentActualizat;
                        }
                        swFisierText.WriteLine(medicamentPentruScrisInFisier.ConversieLaSir_PentruScriereInFisier());
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return actualizareCuSucces;
        }
    }
}
