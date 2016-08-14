using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Donatori;
using BloodBank.Model.Indagini;
using BloodBank.Model.Indagini.Tipi;

namespace BloodBank.Model.Tests {
    public class AnalisiMock {
        private int _count;

        public Analisi GetAnalisi(Donatore donatore)
        {
            _count++;
            DateTime data = !donatore.ListaTest.Any() ? DateTime.Now : donatore.ListaTest.Last().Data.AddDays(_count);

            return new Analisi(donatore, "Descrizione breve", data, new List<Voce>
            {
                    new Voce<bool>(new IndagineBoolean("Domanda1", Idoneità.NonIdoneo, true), true),
                    new Voce<bool>(new IndagineBoolean("Domanda2", Idoneità.NonIdoneo, true), true),
                    new Voce<bool>(new IndagineBoolean("Domanda3", Idoneità.NonIdoneo, true), true),
                    new Voce<bool>(new IndagineBoolean("Domanda4", Idoneità.NonIdoneo, true), true),
                    new Voce<bool>(new IndagineBoolean("Domanda5", Idoneità.NonIdoneo, true), true),
                    new Voce<bool>(new IndagineBoolean("Domanda6", Idoneità.NonIdoneo, true), true),
                    new Voce<bool>(new IndagineBoolean("Domanda7", Idoneità.NonIdoneo, true), true)
                });
        }
    }
}
