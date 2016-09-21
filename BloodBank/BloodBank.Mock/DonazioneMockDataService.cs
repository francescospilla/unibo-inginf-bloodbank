using System;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;
using Ninject;
using Ninject.Parameters;
using static BloodBank.Model.Models.Donazioni.TipoDonazione;

namespace BloodBank.Mock {
    public sealed class DonazioneMockDataService : MockDataService<Donazione> {

        internal Donazione Donazione2;
        internal Donazione Donazione3;
        internal Donazione Donazione4;

        public DonazioneMockDataService(DonatoreMockDataService d, VisitaMedicaMockDataService v, AnalisiMockDataService a, QuestionarioMockDataService q, IKernel kernel) {
            _models = new ObservableCollection<object>();

            IDonazioneFactory factory = kernel.Get<IDonazioneFactory>(new ConstructorArgument("dataService", this));
            
            Donazione2 = factory.CreateModel(d.D2, SangueIntero, new DateTime(2016, 08, 23, 12, 00, 00), v.V2, a.A2, q.Q2);
            Donazione3 = factory.CreateModel(d.D3, Plasmaferesi, new DateTime(2016, 05, 15, 18, 30, 00), v.V3, a.A3, q.Q3);
            Donazione4 = factory.CreateModel(d.D4, SangueIntero, new DateTime(2016, 07, 02, 15, 45, 00), v.V4, a.A4, q.Q4);
        }

    }
}
