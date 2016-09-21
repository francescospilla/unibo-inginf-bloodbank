using System.Collections.ObjectModel;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Mock.Indagini {
    
    public sealed class VoceQuestionarioMockDataService : MockDataService<Voce<Questionario>> {
        internal Voce<Questionario> Vq1;
        internal Voce<Questionario> Vq2;
        internal Voce<Questionario> Vq3;
        internal Voce<Questionario> Vq4;
        internal Voce<Questionario> Vq5;
        internal Voce<Questionario> Vq6;
        internal Voce<Questionario> Vq7;
        internal Voce<Questionario> Vq8;
        internal Voce<Questionario> Vq9;
        internal Voce<Questionario> Vq10;
        internal Voce<Questionario> Vq11;
        internal Voce<Questionario> Vq12;
        
        public VoceQuestionarioMockDataService(IndagineQuestionarioMockDataService iq) {

            Vq1 = new Voce<Questionario, bool>(iq.Q1, true);
            Vq2 = new Voce<Questionario, bool>(iq.Q1, false);
            Vq3 = new Voce<Questionario, bool>(iq.Q2, false);
            Vq4 = new Voce<Questionario, bool>(iq.Q2, false);
            Vq5 = new Voce<Questionario, bool>(iq.Q3, true);
            Vq6 = new Voce<Questionario, bool>(iq.Q3, false);
            Vq7 = new Voce<Questionario, int>(iq.Q4, 47);
            Vq8 = new Voce<Questionario, int>(iq.Q4, 80);
            Vq9 = new Voce<Questionario, bool>(iq.Q5, true);
            Vq10 = new Voce<Questionario, bool>(iq.Q5, false);
            Vq11 = new Voce<Questionario, double>(iq.Q6, 5.6);
            Vq12 = new Voce<Questionario, double>(iq.Q6, 15.0);

            _models = new ObservableCollection<object> {Vq1, Vq1, Vq2, Vq3, Vq4, Vq5, Vq6, Vq7, Vq8, Vq9, Vq10, Vq11, Vq12};
        }

    }
}
