using System.Collections.ObjectModel;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Mock.Indagini {
    public sealed class ListaIndaginiQuestionarioMockDataService : MockDataService<ListaIndagini<Questionario>> {

        internal static ListaIndagini<Questionario> Liq1;
        internal static ListaIndagini<Questionario> Liq2;
        internal static ListaIndagini<Questionario> Liq3;
        internal static ListaIndagini<Questionario> Liq4;
        internal static ListaIndagini<Questionario> Liq5;

        public ListaIndaginiQuestionarioMockDataService(IndagineQuestionarioMockDataService iq) {
            Liq1 = new ListaIndagini<Questionario>("Questionario Parziale 1") { iq.Q1, iq.Q2, iq.Q3, iq.Q4, iq.Q5, iq.Q6, iq.Q7, iq.Q8 };
            Liq2 = new ListaIndagini<Questionario>("Questionario Parziale 2") { iq.Q9, iq.Q10, iq.Q11, iq.Q12 };
            Liq3 = new ListaIndagini<Questionario>("Questionario Completo") { iq.Q1, iq.Q2, iq.Q3, iq.Q4, iq.Q5, iq.Q6, iq.Q7, iq.Q8, iq.Q9, iq.Q10, iq.Q11, iq.Q12 };
            Liq4 = new ListaIndagini<Questionario>("Questionario Parziale 3") { iq.Q1, iq.Q2, iq.Q3, iq.Q4, iq.Q5, iq.Q6, iq.Q7, iq.Q8 };
            Liq5 = new ListaIndagini<Questionario>("Questionario Parziale 4") { iq.Q1, iq.Q2, iq.Q4, iq.Q6, iq.Q8 };

            _models = new ObservableCollection<ListaIndagini<Questionario>> { Liq1, Liq2, Liq3, Liq4, Liq5 };
        }


    }
}