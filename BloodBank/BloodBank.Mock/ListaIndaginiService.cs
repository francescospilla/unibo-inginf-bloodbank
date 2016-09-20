using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;

namespace BloodBank.Mock {

    public abstract class ListaIndaginiService<U> : DataService<ListaIndagini<U>> where U : ListaVoci {

        protected ListaIndaginiService() : base() {
        }
    }

    public class ListaIndaginiAnalisiService : ListaIndaginiService<Analisi> {

        internal static ListaIndagini<Analisi> Lia1;
        internal static ListaIndagini<Analisi> Lia2;
        internal static ListaIndagini<Analisi> Lia3;

        public ListaIndaginiAnalisiService(IndagineAnalisiService ia) : base() {
            Lia1 = new ListaIndagini<Analisi>("Analisi parziali 1") { ia.A1, ia.A2, ia.A3, ia.A4 };
            Lia2 = new ListaIndagini<Analisi>("Analisi complete") { ia.A1, ia.A2, ia.A3, ia.A4, ia.A5 };
            Lia3 = new ListaIndagini<Analisi>("Analisi parziali 1") { ia.A1, ia.A2 };

            _models = new List<ListaIndagini<Analisi>>() { Lia1, Lia2, Lia3 };
        }

    }

    public class ListaIndaginiQuestionarioService : ListaIndaginiService<Questionario> {

        internal static ListaIndagini<Questionario> Liq1;
        internal static ListaIndagini<Questionario> Liq2;
        internal static ListaIndagini<Questionario> Liq3;
        internal static ListaIndagini<Questionario> Liq4;
        internal static ListaIndagini<Questionario> Liq5;

        public ListaIndaginiQuestionarioService(IndagineQuestionarioService iq) : base() {
            Liq1 = new ListaIndagini<Questionario>("Questionario Parziale 1") { iq.Q1, iq.Q2, iq.Q3, iq.Q4, iq.Q5, iq.Q6, iq.Q7, iq.Q8 };
            Liq2 = new ListaIndagini<Questionario>("Questionario Parziale 2") { iq.Q9, iq.Q10, iq.Q11, iq.Q12 };
            Liq3 = new ListaIndagini<Questionario>("Questionario Completo") { iq.Q1, iq.Q2, iq.Q3, iq.Q4, iq.Q5, iq.Q6, iq.Q7, iq.Q8, iq.Q9, iq.Q10, iq.Q11, iq.Q12 };
            Liq4 = new ListaIndagini<Questionario>("Questionario Parziale 3") { iq.Q1, iq.Q2, iq.Q3, iq.Q4, iq.Q5, iq.Q6, iq.Q7, iq.Q8 };
            Liq5 = new ListaIndagini<Questionario>("Questionario Parziale 4") { iq.Q1, iq.Q2, iq.Q4, iq.Q6, iq.Q8 };

            _models = new List<ListaIndagini<Questionario>>() { Liq1, Liq2, Liq3, Liq4, Liq5 };
        }


    }
}