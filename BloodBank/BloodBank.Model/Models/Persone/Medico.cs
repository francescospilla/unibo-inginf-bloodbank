using System;
using PropertyChanged;

namespace BloodBank.Model.Models.Persone {
    [ImplementPropertyChanged]
    public class Medico {

        public Contatto Contatto { get; }

        public Medico(Contatto contatto) {
            Contatto = contatto;
        }

        #region Overrides

        public override string ToString() {
            return Contatto.ToString();
        }

        #endregion Overrides
    }
}
