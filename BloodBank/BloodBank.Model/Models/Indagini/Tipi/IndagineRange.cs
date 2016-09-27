using System;
using BloodBank.Model.Models.Tests;
using PropertyChanged;

namespace BloodBank.Model.Models.Indagini.Tipi {

    [ImplementPropertyChanged]
    public class IndagineRange<U, T> : Indagine<U, T> where T : IComparable<T> where U : ListaVoci {

        public IndagineRange(string testo, Idoneità idoneitàFallimento, T rangeMin, T rangeMax) : base(testo, idoneitàFallimento) {
            if (rangeMin.CompareTo(rangeMax) >= 0)
                throw new ArgumentException("Il valore minimo del range deve essere strettamente inferiore al valore massimo.");

            RangeMin = rangeMin;
            RangeMax = rangeMax;
        }

        private T RangeMin { get; }
        private T RangeMax { get; }

        internal override Idoneità GetIdoneitàFromRisultato(T risultato) {
            return risultato.CompareTo(RangeMin) >= 0 && risultato.CompareTo(RangeMax) <= 0
                ? Idoneità.Idoneo
                : IdoneitàFallimento;
        }
    }
}