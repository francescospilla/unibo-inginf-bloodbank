using System;
using System.Collections.ObjectModel;
using BloodBank.Mock.Persone;
using BloodBank.Mock.Test;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Service;
using Ninject;
using Ninject.Parameters;

namespace BloodBank.Mock.Donazioni {
    public sealed class DonazioneMockDataService : MockDataService<Donazione> {

        internal Donazione Donazione2;
        internal Donazione Donazione3;
        internal Donazione Donazione4;

        public DonazioneMockDataService(DonatoreMockDataService d, VisitaMedicaMockDataService v, AnalisiMockDataService a, QuestionarioMockDataService q, IKernel kernel) {
            _models = new ObservableCollection<Donazione>();

            IDonazioneFactory factory = kernel.Get<IDonazioneFactory>(new ConstructorArgument("dataService", this));
            
            Donazione2 = factory.CreateModel(d.D2, TipoDonazione.SangueIntero, new DateTime(2016, 08, 23, 12, 00, 00), v.V2, a.A2, q.Q2);
            Donazione3 = factory.CreateModel(d.D3, TipoDonazione.Plasmaferesi, new DateTime(2016, 05, 15, 18, 30, 00), v.V3, a.A3, q.Q3);
            Donazione4 = factory.CreateModel(d.D4, TipoDonazione.SangueIntero, new DateTime(2016, 07, 02, 15, 45, 00), v.V4, a.A4, q.Q4);
        }

    }
}
