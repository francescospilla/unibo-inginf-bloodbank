using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using PropertyChanged;

namespace BloodBank.Model.Models.Persone
{

    [ImplementPropertyChanged]
    public class Donatore
    {
        public static readonly Tuple<int, int> RangeEtà = new Tuple<int, int>(16, 80);

        private readonly SortedList<DateTime, Donazione> _listaDonazioni;
        private readonly SortedList<DateTime, Test> _listaTest;

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

        public Donatore(Contatto contatto, GruppoSanguigno gruppoSanguigno, bool attivo)
        {
            Contatto = contatto;
            GruppoSanguigno = gruppoSanguigno;
            Attivo = attivo;
            _listaTest = new SortedList<DateTime, Test>();
            _listaDonazioni = new SortedList<DateTime, Donazione>();
        }

        public GruppoSanguigno GruppoSanguigno { get; }
        public Idoneità? Idoneità { get; private set; }
        public bool Attivo { get; set; }

        public IEnumerable<Test> ListaTest => _listaTest.Values;
        public IEnumerable<Donazione> ListaDonazioni => _listaDonazioni.Values;

        #region Overrides

        private bool Equals(Donatore other)
        {
            return Equals(Contatto, other.Contatto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Donatore) && Equals((Donatore)obj);
        }

        public override int GetHashCode()
        {
            return Contatto?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return Contatto.ToString();
        }

        #endregion Overrides

        public void AggiungiTest(Test test)
        {
            _listaTest.Add(test.Data, test);
            Idoneità = _listaTest.LastOrDefault().Value?.Idoneità;
        }
    }
}