using System;

namespace BloodBank.Model.Indagini
{
    public abstract class Indagine
    {
        public string Testo { get; }
        protected Idoneità IdoneitàFallimento { get; }

        protected Indagine(string testo, Idoneità idoneitàFallimento) {
            Testo = testo;
            IdoneitàFallimento = idoneitàFallimento;
        }

        protected bool Equals(Indagine other)
        {
            return string.Equals(Testo, other.Testo, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Indagine) obj);
        }

        public override int GetHashCode()
        {
            return Testo != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Testo) : 0;
        }

        public override string ToString()
        {
            return Testo;
        }
    }

    public abstract class Indagine<T> : Indagine where T : IComparable<T>
    {
        internal abstract Idoneità GetIdoneitàFromRisultato(T risultato);

        protected Indagine(string testo, Idoneità idoneitàFallimento) : base(testo, idoneitàFallimento)
        {
        }
    }
}