using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using PropertyChanged;

namespace BloodBank.Model.Models.Tests
{
    [ImplementPropertyChanged]
	public class Questionario : ListaVoci<Questionario> {

        public Questionario(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce> listaIndagini)
            : base(donatore, descrizioneBreve, data, listaIndagini)
        {
        }
    }
}