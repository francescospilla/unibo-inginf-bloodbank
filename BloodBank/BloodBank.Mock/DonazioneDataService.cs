using System;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Service;
using static BloodBank.Model.Models.Donazioni.TipoDonazione;

namespace BloodBank.Mock {
    public sealed class DonazioneDataService : DataService<Donazione> {
        public DonazioneFactory DonazioneFactory { get; set; }

        internal Donazione Donazione2;
        internal Donazione Donazione3;
        internal Donazione Donazione4;

        public DonazioneDataService(DonatoreDataService d, VisitaMedicaDataService v, ListaVociAnalisiDataService a, ListaVociQuestionarioDataService q, SaccaSangueDataService s) {
            _models = new ObservableCollection<Donazione>();

            DonazioneFactory = new DonazioneFactory(this, s);
            Donazione2 = DonazioneFactory.CreateModel(d.D2, SangueIntero, new DateTime(2016, 08, 23, 12, 00, 00), v.V2, a.A2, q.Q2);
            Donazione3 = DonazioneFactory.CreateModel(d.D3, Plasmaferesi, new DateTime(2016, 05, 15, 18, 30, 00), v.V3, a.A3, q.Q3);
            Donazione4 = DonazioneFactory.CreateModel(d.D4, SangueIntero, new DateTime(2016, 07, 02, 15, 45, 00), v.V4, a.A4, q.Q4);

            _models = new ObservableCollection<Donazione>(_models.OrderBy(donazione => donazione.Data));
        }

    }
}
