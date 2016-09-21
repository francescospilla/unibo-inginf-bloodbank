using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public interface IListaVociFactory<U> where U : ListaVoci {
        U CreateModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<U>> listaVoci);
    }
}