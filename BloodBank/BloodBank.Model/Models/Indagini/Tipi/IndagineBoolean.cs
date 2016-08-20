using BloodBank.Model.Tests;

namespace BloodBank.Model.Indagini.Tipi {

    public class IndagineBoolean<U> : Indagine<U, bool> where U : ListaVoci {

        public IndagineBoolean(string testo, Idoneità idoneitàFallimento, bool risultatoCorretto) : base(testo, idoneitàFallimento) {
            RisultatoCorretto = risultatoCorretto;
        }

        private bool RisultatoCorretto { get; }

        internal override Idoneità GetIdoneitàFromRisultato(bool risultato) {
            return risultato == RisultatoCorretto ? Idoneità.Idoneo : IdoneitàFallimento;
        }
    }
}