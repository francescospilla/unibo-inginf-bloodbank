using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Donatori;
using BloodBank.Model.Indagini;

namespace BloodBank.Model.Tests
{
    public abstract class ListaVoci : Test
    {
        private readonly List<Voce> _listaVoci;

        protected ListaVoci(Donatore donatore, string descrizioneBreve, DateTime data, List<Voce> listaVoci)
            : base(donatore, data, descrizioneBreve)
        {
            _listaVoci = listaVoci;
            Idoneità = _listaVoci.Select(e => e.Idoneità).CalculateIdoneitàFromList();
        }

        public IEnumerable<Voce> Voci => _listaVoci;
        public override Idoneità Idoneità { get; }

        protected bool Equals(ListaVoci other)
        {
            return base.Equals(other) && Equals(_listaVoci, other._listaVoci);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ListaVoci) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (_listaVoci?.GetHashCode() ?? 0);
            }
        }
    }
}