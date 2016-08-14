using BloodBank.Model.Donatori;
using BloodBank.Model.Indagini;
using System;
using System.Collections.Generic;

namespace BloodBank.Model.Tests {

    public class Questionario : ListaVoci {

        public Questionario(Donatore donatore, string descrizioneBreve, DateTime data, List<Voce> listaIndagini)
            : base(donatore, descrizioneBreve, data, listaIndagini) {
        }
    }
}