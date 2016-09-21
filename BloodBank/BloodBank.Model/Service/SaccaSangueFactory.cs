using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Sangue;

namespace BloodBank.Model.Service {
    public class SaccaSangueFactory : IFactory<SaccaSangue> {
        private readonly IDataService<SaccaSangue> _dataService;

        public SaccaSangueFactory(IDataService<SaccaSangue> dataService) {
            _dataService = dataService;
        }

        public SaccaSangue CreateModel(Donazione donazione, GruppoSanguigno gruppo, ComponenteEmatico componente, DateTime dataPrelievo) {
            var model = new SaccaSangue(donazione, gruppo, componente, dataPrelievo);
            donazione.SaccheSangue.Add(model);
            _dataService.AddModel(model);
            return model;
        }
    }
}