using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Mock.Indagini;
using BloodBank.Mock.Persone;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using Ninject;
using Ninject.Parameters;

namespace BloodBank.Mock.Test {
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
        internal Questionario Q6;

        public QuestionarioMockDataService(DonatoreMockDataService d, VoceQuestionarioMockDataService vq, IKernel kernel) {
            _models = new ObservableCollection<Questionario>();

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
            Q6 = factory.CreateModel(d.D12, "Descrizione Questionario 6", new DateTime(2016, 09, 14, 09, 27, 00), Lvq5);

            _models = new ObservableCollection<Questionario>(_models.Cast<Questionario>().OrderBy(test => test.Data));

        }


    }
}