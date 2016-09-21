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

        public AnalisiMockDataService(DonatoreMockDataService d, VoceAnalisiMockDataService va, IKernel kernel) {
            _models = new ObservableCollection<Analisi>();

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

            _models = new ObservableCollection<Analisi>(_models.Cast<Analisi>().OrderBy(test => test.Data));
        }


    }
}
