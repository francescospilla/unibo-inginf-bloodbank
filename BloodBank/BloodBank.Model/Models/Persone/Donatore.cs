﻿using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Models.Persone {

    public class Donatore {
        public static readonly Tuple<int, int> RangeEtà = new Tuple<int, int>(16, 80);

        private readonly List<Donazione> _listaDonazioni;
        private readonly List<Test> _listaTest;

        public Contatto Contatto { get; }

        #region Contatto delegated properties

        public string Città {
            get { return Contatto.Città; }
            set { Contatto.Città = value; }
        }

        public string CodiceFiscale {
            get { return Contatto.CodiceFiscale; }
        }

        public string CodicePostale {
            get { return Contatto.CodicePostale; }
            set { Contatto.CodicePostale = value; }
        }

        public string Cognome {
            get { return Contatto.Cognome; }
        }

        public DateTime DataNascita {
            get { return Contatto.DataNascita; }
        }

        public string Email {
            get { return Contatto.Email; }
            set { Contatto.Email = value; }
        }

        public string Indirizzo {
            get { return Contatto.Indirizzo; }
            set { Contatto.Indirizzo = value; }
        }

        public string Nome {
            get { return Contatto.Nome; }
        }

        public Sesso Sesso {
            get { return Contatto.Sesso; }
        }

        public string Stato {
            get { return Contatto.Stato; }
            set { Contatto.Stato = value; }
        }

        public string Telefono {
            get { return Contatto.Telefono; }
            set { Contatto.Telefono = value; }
        }

        #endregion Contatto delegated properties

        public Donatore(Contatto contatto, GruppoSanguigno gruppoSanguigno, bool attivo) {
            Contatto = contatto;
            GruppoSanguigno = gruppoSanguigno;
            Attivo = attivo;
            _listaTest = new List<Test>();
            _listaDonazioni = new List<Donazione>();
        }

        public GruppoSanguigno GruppoSanguigno { get; }
        public Idoneità? Idoneità => _listaTest.LastOrDefault()?.Idoneità;
        public bool Attivo { get; set; }

        public IEnumerable<Test> ListaTest => _listaTest;
        public IEnumerable<Donazione> ListaDonazioni => _listaDonazioni;

        #region Overrides

        private bool Equals(Donatore other) {
            return Equals(Contatto, other.Contatto);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Donatore) && Equals((Donatore)obj);
        }

        public override int GetHashCode() {
            return Contatto?.GetHashCode() ?? 0;
        }

        public override string ToString() {
            return Contatto.ToString();
        }

        #endregion Overrides

        public void AggiungiTest(Test test)
        {
            _listaTest.Add(test);
        }
    }
}