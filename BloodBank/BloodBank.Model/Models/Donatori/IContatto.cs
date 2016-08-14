using System;

namespace BloodBank.Model.Donatori {

    public interface IContatto {
        string Nome { get; }
        string Cognome { get; }
        Sesso Sesso { get; }
        string CodiceFiscale { get; }
        DateTime DataNascita { get; }
        string Indirizzo { get; }
        string Città { get; }
        string Stato { get; }
        string CodicePostale { get; }
        string Telefono { get; }
        string Email { get; }
    }
}