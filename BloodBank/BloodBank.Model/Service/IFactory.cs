using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public interface IFactory<TModel> {

    }

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

    public class AnalisiFactory : ListaVociFactory<Analisi> {
        public AnalisiFactory(IDataService<Analisi> dataService) : base(dataService) {
        }


        protected override Analisi CreateActualModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<Analisi>> listaVoci) {
            return new Analisi(donatore, descrizioneBreve, data, listaVoci);
        }

    }

    public class QuestionarioFactory : ListaVociFactory<Questionario> {
        public QuestionarioFactory(IDataService<Questionario> dataService) : base(dataService) {
        }

        protected override Questionario CreateActualModel(Donatore donatore, string descrizioneBreve,
            DateTime data, IEnumerable<Voce<Questionario>> listaVoci) {
            return new Questionario(donatore, descrizioneBreve, data, listaVoci);
        }
    }

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
