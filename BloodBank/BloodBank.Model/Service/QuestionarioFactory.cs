using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public class QuestionarioFactory : ListaVociFactory<Questionario> {
        public QuestionarioFactory(IDataService<Questionario> dataService) : base(dataService) {
        }

        protected override Questionario CreateActualModel(Donatore donatore, string descrizioneBreve,
            DateTime data, IEnumerable<Voce<Questionario>> listaVoci) {
            return new Questionario(donatore, descrizioneBreve, data, listaVoci);
        }
    }
}