using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public abstract class ListaVociFactory<U> : IFactory<U> where U : ListaVoci {
        private readonly IDataService<ListaVoci> _dataService;

        protected ListaVociFactory(IDataService<ListaVoci> dataService) {
            _dataService = dataService;
        }

        public U CreateModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<U>> listaVoci) {
            var model = CreateActualModel(donatore, descrizioneBreve, data, listaVoci);
            donatore.AggiungiTest(model);
            _dataService.AddModel(model);
            return model;
        }

        protected abstract U CreateActualModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<U>> listaVoci);
    }
}