using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Donatori;
using BloodBank.Model.Models.Indagini;

namespace BloodBank.Model.Models.Tests {

    public class Analisi : ListaVoci {

        public Analisi(Donatore donatore, string descrizioneBreve, DateTime data, List<Voce> listaIndagini)
            : base(donatore, descrizioneBreve, data, listaIndagini) {
        }
    }
}