using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Mock.Indagini {
    public sealed class IndagineAnalisiMockDataService : IndagineMockDataService<Analisi> {

        internal IndagineRange<Analisi, double> A1;
        internal IndagineRange<Analisi, int> A2;
        internal IndagineBoolean<Analisi> A3;
        internal IndagineBoolean<Analisi> A4;
        internal IndagineBoolean<Analisi> A5;
        internal IndagineBoolean<Analisi> A6;

        public IndagineAnalisiMockDataService() {
            A1 = new IndagineRange<Analisi, double>("Esame emocromocitometrico completo (milioni per ml di sangue)", Idoneità.Sospeso, 3.8, 5.9);
            A2 = new IndagineRange<Analisi, int>("Transaminasi ALT con metodo ottimizzato (U/I)", Idoneità.NonIdoneo, 40, int.MaxValue);
            A3 = new IndagineBoolean<Analisi>("Sierodiagnosi per la Lue (per sifilide)", Idoneità.NonIdoneo, false);
            A4 = new IndagineBoolean<Analisi>("HBsAg (per l'epatite B)", Idoneità.NonIdoneo, false);
            A5 = new IndagineBoolean<Analisi>("HIVAb 1-2 (per l'AIDS)", Idoneità.NonIdoneo, false);
            A6 = new IndagineBoolean<Analisi>("HCVAb e costituenti virali (per l'epatite C)", Idoneità.NonIdoneo, false);

            _models = new ObservableCollection<Indagine<Analisi>> { A1, A2, A3, A4, A5, A6 };
        }

    }
}