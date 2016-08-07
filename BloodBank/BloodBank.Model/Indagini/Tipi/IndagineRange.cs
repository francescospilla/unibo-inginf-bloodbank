using System;

namespace BloodBank.Model.Indagini.Tipi
{
    public class IndagineRange<T> : Indagine<T> where T : IComparable<T>
    {
        public IndagineRange(string testo, Idoneità idoneitàFallimento, T rangeMin, T rangeMax) : base (testo, idoneitàFallimento)
        {
            RangeMin = rangeMin;
            RangeMax = rangeMax;
        }

        private T RangeMin { get; }
        private T RangeMax { get; }

        internal override Idoneità GetIdoneitàFromRisultato(T risultato)
        {
            return risultato.CompareTo(RangeMin) >= 0 && risultato.CompareTo(RangeMax) <= 0
                ? Idoneità.Idoneo
                : IdoneitàFallimento;
        }
    }
}