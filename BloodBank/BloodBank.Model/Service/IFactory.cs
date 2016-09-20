using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public interface IFactory<TModel> {     

    }

    public class DonazioneFactory : IFactory<Donazione> {
        private readonly IDataService<Donazione> _dataService;

        public DonazioneFactory(IDataService<Donazione> dataService) {
            _dataService = dataService;
        }

        public Donazione CreateModel(Donatore donatore, TipoDonazione tipoDonazione, DateTime data, VisitaMedica visitaMedica,
            Analisi analisi, Questionario questionario) {
            var model = new Donazione(donatore, tipoDonazione, data, visitaMedica, analisi, questionario);
            model.EffettuaPrelievo();
            donatore.AggiungiDonazione(model);
            _dataService.AddModel(model);
            return model;
        }
    }

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
