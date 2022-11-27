using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddMedicament(Medicament e);
        List<Medicament> GetMedicamente();
		Medicament GetMedicament(string denumire);
        Medicament GetMedicament(int index);
        bool UpdateMedicament(Medicament e);
    }
}
