using System;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public class VisitaMedicaFactory : IFactory<VisitaMedica> {
        private readonly IDataService<VisitaMedica> _dataService;

        public VisitaMedicaFactory(IDataService<VisitaMedica> dataService) {
            _dataService = dataService;
        }

        public VisitaMedica CreateModel(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, Medico medico, string referto) {
            var model = new VisitaMedica(donatore, descrizioneBreve, data, idoneità, medico, referto);
            donatore.AggiungiTest(model);
            _dataService.AddModel(model);
            return model;
        }
    }
}