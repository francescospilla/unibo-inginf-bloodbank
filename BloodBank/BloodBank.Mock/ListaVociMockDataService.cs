using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using Ninject;
using Ninject.Parameters;

namespace BloodBank.Mock {

    public sealed class AnalisiMockDataService : MockDataService<Analisi> {
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

        public AnalisiMockDataService(DonatoreMockDataService d, VoceMockAnalisiDataService va, IKernel kernel) {
            _models = new ObservableCollection<object>();

            IAnalisiFactory factory = kernel.Get<IAnalisiFactory>(new ConstructorArgument("dataService", this));

            // liste di voci generiche
            Lva1 = new List<Voce<Analisi>> { va.Va1, va.Va6, va.Va8, va.Va12 };
            Lva2 = new List<Voce<Analisi>> { va.Va1, va.Va4, va.Va6, va.Va8, va.Va10, va.Va12 };
            Lva3 = new List<Voce<Analisi>> { va.Va1, va.Va8 };
            // Questa lista di voci ha risposte errate
            Lva4 = new List<Voce<Analisi>> { va.Va2, va.Va3, va.Va7, va.Va8, va.Va10 };

            // analisi specifiche per donatori
            A1 = factory.CreateModel(d.D1, "Descrizione Analisi 1", DateTime.Now.AddMinutes(-3), Lva1);
            A2 = factory.CreateModel(d.D2, "Descrizione Analisi 2", new DateTime(2016, 08, 23, 11, 00, 30), Lva2);
            A3 = factory.CreateModel(d.D3, "Descrizione Analisi 3", new DateTime(2016, 05, 15, 17, 03, 00), Lva3);
            A4 = factory.CreateModel(d.D4, "Descrizione Analisi 4", new DateTime(2016, 07, 02, 15, 00, 12), Lva1);

            _models = new ObservableCollection<object>(_models.Cast<Analisi>().OrderBy(test => test.Data));
        }


    }

    public sealed class QuestionarioMockDataService : MockDataService<Questionario> {

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

        public QuestionarioMockDataService(DonatoreMockDataService d, VoceMockQuestionarioDataService vq, IKernel kernel) {
            _models = new ObservableCollection<object>();

            IQuestionarioFactory factory = kernel.Get<IQuestionarioFactory>(new ConstructorArgument("dataService", this));

            // liste di voci generiche
            Lvq1 = new List<Voce<Questionario>> { vq.Vq1, vq.Vq4, vq.Vq6, vq.Vq10, vq.Vq8 };
            Lvq2 = new List<Voce<Questionario>> { vq.Vq3, vq.Vq8, vq.Vq6, vq.Vq10 };
            Lvq3 = new List<Voce<Questionario>> { vq.Vq3, vq.Vq8, vq.Vq6, vq.Vq10, vq.Vq12 };
            Lvq4 = new List<Voce<Questionario>> { vq.Vq1, vq.Vq3, vq.Vq6, vq.Vq10, vq.Vq8, vq.Vq12 };
            // Questa lista di voci contiene delle risposte errate
            Lvq5 = new List<Voce<Questionario>> { vq.Vq1, vq.Vq3, vq.Vq5, vq.Vq9, vq.Vq11, vq.Vq7 };

            // questionari specifici per donatori
            Q1 = factory.CreateModel(d.D1, "Descrizione Questionario 1", DateTime.Now.AddMinutes(-4), Lvq1);
            Q2 = factory.CreateModel(d.D2, "Descrizione Questionario 2", new DateTime(2016, 08, 23, 10, 30, 12), Lvq2);
            Q3 = factory.CreateModel(d.D3, "Descrizione Questionario 3", new DateTime(2016, 05, 15, 16, 45, 36), Lvq3);
            Q4 = factory.CreateModel(d.D4, "Descrizione Questionario 4", new DateTime(2016, 07, 02, 14, 40, 00), Lvq4);
            Q5 = factory.CreateModel(d.D5, "Descrizione Questionario 5", new DateTime(2016, 09, 14, 09, 25, 00), Lvq1);

            _models = new ObservableCollection<object>(_models.Cast<Questionario>().OrderBy(test => test.Data));

        }


    }
}
