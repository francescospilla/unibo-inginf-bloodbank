using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public class DonazioneFactory : IFactory<Donazione> {
        private readonly IDataService<Donazione> _dataService;
        private readonly IDataService<SaccaSangue> _saccaSangueDataService;

        public DonazioneFactory(IDataService<Donazione> dataService, IDataService<SaccaSangue> saccaSangueDataService) {
            _dataService = dataService;
            _saccaSangueDataService = saccaSangueDataService;
        }

        public Donazione CreateModel(Donatore donatore, TipoDonazione tipoDonazione, DateTime data, VisitaMedica visitaMedica,
            Analisi analisi, Questionario questionario) {
            var model = new Donazione(donatore, tipoDonazione, data, visitaMedica, analisi, questionario, _saccaSangueDataService);
            model.EffettuaPrelievo();
            donatore.AggiungiDonazione(model);
            _dataService.AddModel(model);
            return model;
        }
    }
}