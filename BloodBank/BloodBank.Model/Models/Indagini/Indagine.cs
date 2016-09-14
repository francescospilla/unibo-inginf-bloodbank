using System;
using System.Threading;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Models.Indagini {

    public abstract class Indagine {
        private static int _staticCounter = 0;

        public int Id { get; }
        public string Testo { get; }
        protected Idoneità IdoneitàFallimento { get; }

        protected Indagine(string testo, Idoneità idoneitàFallimento)
        {
            Id = Interlocked.Increment(ref _staticCounter);
            Testo = testo;
            IdoneitàFallimento = idoneitàFallimento;
        }

        protected bool Equals(Indagine other) {
            return string.Equals(Testo, other.Testo, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Indagine)obj);
        }

        public override int GetHashCode() {
            return Testo != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Testo) : 0;
        }

        public override string ToString() {
            return Testo;
        }
    }

    public abstract class Indagine<U> : Indagine where U : ListaVoci {

        protected Indagine(string testo, Idoneità idoneitàFallimento) : base(testo, idoneitàFallimento)
        {
        }
    }

    public abstract class Indagine<U, T> : Indagine<U> where T : IComparable<T> where U : ListaVoci {

        internal abstract Idoneità GetIdoneitàFromRisultato(T risultato);

        protected Indagine(string testo, Idoneità idoneitàFallimento) : base(testo, idoneitàFallimento) {
        }
    }
}