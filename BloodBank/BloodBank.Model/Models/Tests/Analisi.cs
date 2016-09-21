using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;
using PropertyChanged;


namespace BloodBank.Model.Models.Tests {
    
    [ImplementPropertyChanged]
	public class Analisi : ListaVoci {

        private Analisi(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<Analisi>> listaVoci)
            : base(donatore, descrizioneBreve, data, listaVoci)
        {
        }

        public class AnalisiFactory : ListaVociFactory<Analisi> {
            public AnalisiFactory(IDataService<Analisi> dataService) : base(dataService) {
            }


            protected override Analisi CreateActualModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<Analisi>> listaVoci) {
                return new Analisi(donatore, descrizioneBreve, data, listaVoci);
            }

        }
    }
}