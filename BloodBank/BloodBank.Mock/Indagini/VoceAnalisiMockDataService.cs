using System.Collections.ObjectModel;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Mock.Indagini {
    public sealed class VoceAnalisiMockDataService : MockDataService<Voce<Analisi>> {

        internal Voce<Analisi> Va1;
        internal Voce<Analisi> Va2;
        internal Voce<Analisi> Va3;
        internal Voce<Analisi> Va4;
        internal Voce<Analisi> Va5;
        internal Voce<Analisi> Va6;
        internal Voce<Analisi> Va7;
        internal Voce<Analisi> Va8;
        internal Voce<Analisi> Va9;
        internal Voce<Analisi> Va10;
        internal Voce<Analisi> Va11;
        internal Voce<Analisi> Va12;

        public VoceAnalisiMockDataService(IndagineAnalisiMockDataService ia) {
            Va1 = new Voce<Analisi, double>(ia.A1, 4.2);
            Va2 = new Voce<Analisi, double>(ia.A1, 8.6);
            Va3 = new Voce<Analisi, int>(ia.A2, 25);
            Va4 = new Voce<Analisi, int>(ia.A2, 46);
            Va5 = new Voce<Analisi, bool>(ia.A3, true);
            Va6 = new Voce<Analisi, bool>(ia.A3, false);
            Va7 = new Voce<Analisi, bool>(ia.A4, true);
            Va8 = new Voce<Analisi, bool>(ia.A4, false);
            Va9 = new Voce<Analisi, bool>(ia.A5, true);
            Va10 = new Voce<Analisi, bool>(ia.A5, false);
            Va11 = new Voce<Analisi, bool>(ia.A6, true);
            Va12 = new Voce<Analisi, bool>(ia.A6, false);

            _models = new ObservableCollection<Voce<Analisi>> {Va1, Va2, Va3, Va4, Va5, Va6, Va7, Va8, Va9, Va10, Va11, Va12};
        }

    }
}