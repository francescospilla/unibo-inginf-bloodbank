using System;
using System.Collections.Generic;
using BloodBank.Model.Donatori;
using BloodBank.Model.Indagini;

namespace BloodBank.Model.Tests
{
    public class Analisi : ListaVoci
    {
        public Analisi(Donatore donatore, string descrizioneBreve, DateTime data, List<Voce> listaIndagini)
            : base(donatore, descrizioneBreve, data, listaIndagini)
        {
        }
    }
}