using System.Collections.ObjectModel;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Mock.Indagini {
    
    public sealed class ListaIndaginiAnalisiMockDataService : MockDataService<ListaIndagini<Analisi>> {

        internal static ListaIndagini<Analisi> Lia1;
        internal static ListaIndagini<Analisi> Lia2;
        internal static ListaIndagini<Analisi> Lia3;

        public ListaIndaginiAnalisiMockDataService(IndagineAnalisiMockDataService ia) {
            Lia1 = new ListaIndagini<Analisi>("Analisi parziali 1") { ia.A1, ia.A2, ia.A3, ia.A4 };
            Lia2 = new ListaIndagini<Analisi>("Analisi complete") { ia.A1, ia.A2, ia.A3, ia.A4, ia.A5 };
            Lia3 = new ListaIndagini<Analisi>("Analisi parziali 2") { ia.A1, ia.A2 };

            _models = new ObservableCollection<ListaIndagini<Analisi>> { Lia1, Lia2, Lia3 };
        }

    }
}