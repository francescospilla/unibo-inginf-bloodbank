using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using PropertyChanged;

namespace BloodBank.Model.Models.Tests
{

    [ImplementPropertyChanged]
    public class Questionario : ListaVoci
    {

        public Questionario(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce> listaIndagini)
            : base(donatore, descrizioneBreve, data, listaIndagini)
        {
        }
    }
}