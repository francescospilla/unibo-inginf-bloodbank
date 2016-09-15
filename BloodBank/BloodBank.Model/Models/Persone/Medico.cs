using System;
using PropertyChanged;

namespace BloodBank.Model.Models.Persone
{
    [ImplementPropertyChanged]
    public class Medico
    {

        public Contatto Contatto { get; }

        #region Contatto delegated properties

        public string Città
        {
            get { return Contatto.Città; }
            set { Contatto.Città = value; }
        }

        public string CodiceFiscale
        {
            get { return Contatto.CodiceFiscale; }
        }

        public string CodicePostale
        {
            get { return Contatto.CodicePostale; }
            set { Contatto.CodicePostale = value; }
        }

        public string Cognome
        {
            get { return Contatto.Cognome; }
        }

        public DateTime DataNascita
        {
            get { return Contatto.DataNascita; }
        }

        public string Email
        {
            get { return Contatto.Email; }
            set { Contatto.Email = value; }
        }

        public string Indirizzo
        {
            get { return Contatto.Indirizzo; }
            set { Contatto.Indirizzo = value; }
        }

        public string Nome
        {
            get { return Contatto.Nome; }
        }

        public Sesso Sesso
        {
            get { return Contatto.Sesso; }
        }

        public string Stato
        {
            get { return Contatto.Stato; }
            set { Contatto.Stato = value; }
        }

        public string Telefono
        {
            get { return Contatto.Telefono; }
            set { Contatto.Telefono = value; }
        }

        #endregion Contatto delegated properties

        public Medico(Contatto contatto)
        {
            Contatto = contatto;
        }

        #region Overrides

        public override string ToString()
        {
            return Contatto.ToString();
        }

        #endregion Overrides
    }
}
