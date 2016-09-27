using System;
using PropertyChanged;

namespace BloodBank.Model.Models.Persone {

    public enum Sesso {
        Maschio,
        Femmina
    }

    [ImplementPropertyChanged]
    public class Contatto {

        public Contatto(string nome, string cognome, Sesso sesso, DateTime dataNascita, string codiceFiscale, string indirizzo, string città, string stato, string codicePostale, string telefono = null, string email = null) {

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cognome) || string.IsNullOrWhiteSpace(codiceFiscale) || string.IsNullOrWhiteSpace(indirizzo) ||
                string.IsNullOrWhiteSpace(città) || string.IsNullOrWhiteSpace(stato) || string.IsNullOrWhiteSpace(codicePostale))
                throw new ArgumentException("Almeno un parametro non-opzionale del costruttore è null o vuoto.");
            if (dataNascita > DateTime.Now)
                throw new ArgumentException("La data di nascita non può essere futura.");

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