using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;

namespace BloodBank.Model.Models.Tests {

    public abstract class ListaVoci : Test {
        protected ListaVoci(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce> listaVoci)
            : base(donatore, data, descrizioneBreve) {
            Voci = listaVoci;
            Idoneità = Voci.Select(e => e.Idoneità).CalculateIdoneitàFromList();
        }

        public IEnumerable<Voce> Voci { get; }

        public override Idoneità Idoneità { get; }

        protected bool Equals(ListaVoci other) {
            return base.Equals(other) && Equals(Voci, other.Voci);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ListaVoci)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (base.GetHashCode() * 397) ^ (Voci?.GetHashCode() ?? 0);
            }
        }

        public abstract class ListaVociFactory<U> : IListaVociFactory<U> where U : ListaVoci {
            private readonly IDataService<U> _dataService;

            protected ListaVociFactory(IDataService<U> dataService) {
                _dataService = dataService;
            }

            public U CreateModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<U>> listaVoci) {
                var model = CreateActualModel(donatore, descrizioneBreve, data, listaVoci);
                donatore.AggiungiTest(model);
                _dataService.AddModel(model);
                return model;
            }

            protected abstract U CreateActualModel(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<U>> listaVoci);
        }
    }

}