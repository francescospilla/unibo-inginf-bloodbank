using System.Collections.Generic;
using BloodBank.Model;
using BloodBank.Model.Indagini;
using BloodBank.Model.Indagini.Tipi;

namespace BloodBank.ViewModel.Services {
    public class IndagineService : DataService<Indagine> {
        private static readonly IList<Indagine> Items = new List<Indagine>() {
                new IndagineBoolean("Domanda 1", Idoneità.NonIdoneo, true),
                new IndagineBoolean("Domanda 2", Idoneità.Idoneo, true),
                new IndagineBoolean("Domanda 3", Idoneità.Sospeso, false),
                new IndagineBoolean("Domanda 4", Idoneità.NonIdoneo, true),
                new IndagineRange<int>("Domanda 5", Idoneità.NonIdoneo, 0, 10)
            };

        public IndagineService() : base(Items){}
    }
}
