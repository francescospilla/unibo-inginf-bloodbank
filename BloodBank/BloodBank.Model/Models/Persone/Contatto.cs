using System;

namespace BloodBank.Model.Models.Persone {

    public enum Sesso {
        Maschio,
        Femmina
    }

    public class Contatto {

        public Contatto(string nome, string cognome, Sesso sesso, DateTime dataNascita, string codiceFiscale, string indirizzo, string città, string stato, string codicePostale, string telefono = null, string email = null) {
            Nome = nome;
            Cognome = cognome;
            Sesso = sesso;
            DataNascita = dataNascita.Date;
            CodiceFiscale = codiceFiscale;
            Indirizzo = indirizzo;
            Città = città;
            Stato = stato;
            CodicePostale = codicePostale;
            Telefono = telefono;
            Email = email;
        }

        public string Nome { get; }
        public string Cognome { get; }
        public Sesso Sesso { get; }
        public DateTime DataNascita { get; }
        public string CodiceFiscale { get; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public string Stato { get; set; }
        public string CodicePostale { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        #region Overrides

        private bool Equals(Contatto other) {
            return string.Equals(CodiceFiscale, other.CodiceFiscale);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Contatto)obj);
        }

        public override int GetHashCode() {
            return CodiceFiscale?.GetHashCode() ?? 0;
        }

        public override string ToString() {
            return Nome + " " + Cognome;
        }

        #endregion Overrides
    }
}