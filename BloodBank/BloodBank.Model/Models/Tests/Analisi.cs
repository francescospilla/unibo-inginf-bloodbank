using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using PropertyChanged;


namespace BloodBank.Model.Models.Tests {
    
    [ImplementPropertyChanged]
	public class Analisi : ListaVoci {

        public Analisi(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<Analisi>> listaVoci)
            : base(donatore, descrizioneBreve, data, listaVoci)
        {
        }
    }
}