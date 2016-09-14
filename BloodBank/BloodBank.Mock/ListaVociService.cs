using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using static BloodBank.Mock.DonatoreService;
using static BloodBank.Mock.VoceAnalisiService;
using static BloodBank.Mock.VoceQuestionarioService;

namespace BloodBank.Mock
{
    public abstract class ListaVociService<U> : DataService<ListaVoci<U>> where U : ListaVoci
    {
        protected ListaVociService(IList<ListaVoci<U>> items) : base(items)
        {
        }
    }

    // Lista di analisi già compilate Lva = lista voci analisi
    public class ListaVociAnalisiService : ListaVociService<Analisi>
    {
        // liste di voci generiche
        internal static IEnumerable<Voce<Analisi>> Lva1 = new List<Voce<Analisi>>()
        {
            Va1, Va6, Va8, Va12
        };
        internal static IEnumerable<Voce<Analisi>> Lva2 = new List<Voce<Analisi>>()
        {
            Va1, Va4, Va6, Va8, Va10, Va12
        };
        internal static IEnumerable<Voce<Analisi>> Lva3 = new List<Voce<Analisi>>()
        {
            Va1, Va8
        };
        // Questa lista di voci ha risposte errate
        internal static IEnumerable<Voce<Analisi>> Lva4 = new List<Voce<Analisi>>()
        {
            Va2, Va3, Va7, Va8, Va10
        };

        // analisi specifiche per donatori
        internal static Analisi A1 = new Analisi(D1, "Descrizione 1", DateTime.Today, Lva1);
        internal static Analisi A2 = new Analisi(D2, "Descrizione 2", new DateTime(2016, 08, 23), Lva2);
        internal static Analisi A3 = new Analisi(D3, "Descrizione 3", new DateTime(2016, 05, 15), Lva3);
        internal static Analisi A4 = new Analisi(D4, "Descrizione 4", new DateTime(2016, 07, 02), Lva1);

        private static readonly IList<ListaVoci<Analisi>> Items = new List<ListaVoci<Analisi>>()
        {
            A1, A2, A3, A4
        };

        public ListaVociAnalisiService() : base(Items)
        {
        }
    }

    // Lista di questionari già compilati
    public class ListaVociQuestionarioService : ListaVociService<Questionario>
    {
        // liste di voci generiche
        internal static IEnumerable<Voce<Questionario>> Lvq1 = new List<Voce<Questionario>>()
        {
            Vq1, Vq3, Vq6, Vq10, Vq8
        };
        internal static IEnumerable<Voce<Questionario>> Lvq2 = new List<Voce<Questionario>>()
        {
            Vq3, Vq8, Vq6, Vq10
        };
        internal static IEnumerable<Voce<Questionario>> Lvq3 = new List<Voce<Questionario>>()
        {
            Vq3, Vq8, Vq6, Vq10, Vq12
        };
        internal static IEnumerable<Voce<Questionario>> Lvq4 = new List<Voce<Questionario>>()
        {
            Vq1, Vq3, Vq6, Vq10, Vq8, Vq12
        };
        // Questa lista di voci contiene delle risposte errate
        internal static IEnumerable<Voce<Questionario>> Lvq5 = new List<Voce<Questionario>>()
        {
            Vq1, Vq3, Vq5, Vq9, Vq11, Vq7
        };

        // questionari specifici per donatori
        internal static Questionario Q1 = new Questionario(D1, "Descrizione questionario 1", DateTime.Today, Lvq1);
        internal static Questionario Q2 = new Questionario(D2, "Descrizione questionario 1", new DateTime(2016, 08, 23), Lvq2);
        internal static Questionario Q3 = new Questionario(D3, "Descrizione questionario 1", new DateTime(2016, 05, 15), Lvq3);
        internal static Questionario Q4 = new Questionario(D4, "Descrizione questionario 1", new DateTime(2016, 07, 02), Lvq4);
        internal static Questionario Q5 = new Questionario(D5, "Descrizione questionario 1", new DateTime(2016, 09, 14), Lvq1);

        private static readonly IList<ListaVoci<Questionario>> Items = new List<ListaVoci<Questionario>>()
        {
            Q1, Q2, Q3, Q4, Q5
        };

        public ListaVociQuestionarioService() : base(Items)
        {
        }
    }
}
