using System;

namespace BloodBank.Model.Indagini {

    public abstract class Voce {
        public abstract Idoneit‡ Idoneit‡ { get; }
        public abstract string TestoIndagine { get; }
        public abstract string TestoRisultato { get; }
    }

    public class Voce<T> : Voce where T : IComparable<T> {

        public Voce(Indagine<T> indagine, T risultato) {
            Indagine = indagine;
            Risultato = risultato;
            Idoneit‡ = Indagine.GetIdoneit‡FromRisultato(risultato);
        }

        private Indagine<T> Indagine { get; }
        private T Risultato { get; }

        public override Idoneit‡ Idoneit‡ { get; }
        public override string TestoIndagine => Indagine.Testo;
        public override string TestoRisultato => Risultato.ToString();

        public override string ToString() {
            return "Voce: " + TestoIndagine + ", Risultato: " + TestoRisultato;
        }
    }
}