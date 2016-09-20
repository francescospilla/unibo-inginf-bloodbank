using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using static BloodBank.Mock.DonatoreService;
using static BloodBank.Mock.VoceAnalisiService;
using static BloodBank.Mock.VoceQuestionarioService;

namespace BloodBank.Mock {
    public abstract class ListaVociService<U> : DataService<ListaVoci<U>> where U : ListaVoci {
        protected ListaVociService() : base() {
        }
    }

    // Lista di analisi già compilate Lva = lista voci analisi
    public class ListaVociAnalisiService : ListaVociService<Analisi> {
        // liste di voci generiche
        internal IEnumerable<Voce<Analisi>> Lva1;
        internal IEnumerable<Voce<Analisi>> Lva2;
        internal IEnumerable<Voce<Analisi>> Lva3;
        // Questa lista di voci ha risposte errate
        internal IEnumerable<Voce<Analisi>> Lva4;

        // analisi specifiche per donatori
        internal Analisi A1;
        internal Analisi A2;
        internal Analisi A3;
        internal Analisi A4;

        public ListaVociAnalisiService(DonatoreService d, VoceAnalisiService va) : base() {
            // liste di voci generiche
            Lva1 = new List<Voce<Analisi>>() { va.Va1, va.Va6, va.Va8, va.Va12 };
            Lva2 = new List<Voce<Analisi>>() { va.Va1, va.Va4, va.Va6, va.Va8, va.Va10, va.Va12 };
            Lva3 = new List<Voce<Analisi>>() { va.Va1, va.Va8 };
            // Questa lista di voci ha risposte errate
            Lva4 = new List<Voce<Analisi>>() { va.Va2, va.Va3, va.Va7, va.Va8, va.Va10 };

            // analisi specifiche per donatori
            A1 = new Analisi(d.D1, "Descrizione 1", DateTime.Now.AddMinutes(-3), Lva1);
            A2 = new Analisi(d.D2, "Descrizione 2", new DateTime(2016, 08, 23, 11, 00, 30), Lva2);
            A3 = new Analisi(d.D3, "Descrizione 3", new DateTime(2016, 05, 15, 17, 03, 00), Lva3);
            A4 = new Analisi(d.D4, "Descrizione 4", new DateTime(2016, 07, 02, 15, 00, 12), Lva1);

            _models = new List<ListaVoci<Analisi>>() { A1, A2, A3, A4 }.OrderBy(analisi => analisi.Data).ToList();
        }


    }

    // Lista di questionari già compilati
    public class ListaVociQuestionarioService : ListaVociService<Questionario> {
        // liste di voci generiche
        internal IEnumerable<Voce<Questionario>> Lvq1;
        internal IEnumerable<Voce<Questionario>> Lvq2;
        internal IEnumerable<Voce<Questionario>> Lvq3;
        internal IEnumerable<Voce<Questionario>> Lvq4;
        // Questa lista di voci contiene delle risposte errate
        internal IEnumerable<Voce<Questionario>> Lvq5;

        // questionari specifici per donatori
        internal Questionario Q1;
        internal Questionario Q2;
        internal Questionario Q3;
        internal Questionario Q4;
        internal Questionario Q5;

        public ListaVociQuestionarioService(DonatoreService d, VoceQuestionarioService vq) : base() {
            // liste di voci generiche
            Lvq1 = new List<Voce<Questionario>>() { vq.Vq1, vq.Vq4, vq.Vq6, vq.Vq10, vq.Vq8 };
            Lvq2 = new List<Voce<Questionario>>() { vq.Vq3, vq.Vq8, vq.Vq6, vq.Vq10 };
            Lvq3 = new List<Voce<Questionario>>() { vq.Vq3, vq.Vq8, vq.Vq6, vq.Vq10, vq.Vq12 };
            Lvq4 = new List<Voce<Questionario>>() { vq.Vq1, vq.Vq3, vq.Vq6, vq.Vq10, vq.Vq8, vq.Vq12 };
            // Questa lista di voci contiene delle risposte errate
            Lvq5 = new List<Voce<Questionario>>() { vq.Vq1, vq.Vq3, vq.Vq5, vq.Vq9, vq.Vq11, vq.Vq7 };

            // questionari specifici per donatori
            Q1 = new Questionario(d.D1, "Descrizione questionario 1", DateTime.Now.AddMinutes(-4), Lvq1);
            Q2 = new Questionario(d.D2, "Descrizione questionario 1", new DateTime(2016, 08, 23, 10, 30, 12), Lvq2);
            Q3 = new Questionario(d.D3, "Descrizione questionario 1", new DateTime(2016, 05, 15, 16, 45, 36), Lvq3);
            Q4 = new Questionario(d.D4, "Descrizione questionario 1", new DateTime(2016, 07, 02, 14, 40, 00), Lvq4);
            Q5 = new Questionario(d.D5, "Descrizione questionario 1", new DateTime(2016, 09, 14, 09, 25, 00), Lvq1);

            _models = new List<ListaVoci<Questionario>>() { Q1, Q2, Q3, Q4, Q5 }.OrderBy(questionario => questionario.Data).ToList();

        }


    }
}
