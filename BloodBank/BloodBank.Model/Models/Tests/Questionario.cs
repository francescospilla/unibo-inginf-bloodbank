using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;

namespace BloodBank.Model.Models.Tests {

    public class Questionario : ListaVoci {

        public Questionario(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce> listaIndagini)
            : base(donatore, descrizioneBreve, data, listaIndagini) {
        }
    }
}