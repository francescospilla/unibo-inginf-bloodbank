using BloodBank.Model.Indagini;
using BloodBank.Model.Indagini.Tipi;
using System.Collections.Generic;

namespace BloodBank.Model.Service {

    public class IndagineService : DataService<Indagine> {

        private static readonly IList<Indagine> Items = new List<Indagine>() {
                new IndagineBoolean("Domanda 1", Idoneità.NonIdoneo, true),
                new IndagineBoolean("Domanda 2", Idoneità.Idoneo, true),
                new IndagineBoolean("Domanda 3", Idoneità.Sospeso, false),
                new IndagineRange<int>("Domanda 4", Idoneità.NonIdoneo, 0, 10),
                new IndagineBoolean("Domanda 5", Idoneità.NonIdoneo, true),
                new IndagineRange<int>("Domanda 6", Idoneità.NonIdoneo, 0, 10),
                new IndagineBoolean("Domanda 7", Idoneità.Idoneo, true),
                new IndagineBoolean("Domanda 8", Idoneità.Sospeso, false),
                new IndagineBoolean("Domanda 9", Idoneità.NonIdoneo, true),
                new IndagineRange<int>("Domanda 10", Idoneità.NonIdoneo, 0, 10),
            };

        public IndagineService() : base(Items) {
        }
    }
}