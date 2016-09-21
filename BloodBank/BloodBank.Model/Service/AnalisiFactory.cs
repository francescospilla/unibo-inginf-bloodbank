using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public class AnalisiFactory : ListaVociFactory<Analisi> {
        public AnalisiFactory(IDataService<Analisi> dataService) : base(dataService) {
        }


        protected override Analisi CreateActualModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<Analisi>> listaVoci) {
            return new Analisi(donatore, descrizioneBreve, data, listaVoci);
        }

    }
}