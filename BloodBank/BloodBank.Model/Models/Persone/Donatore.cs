using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BloodBank.Core.Extensions;
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

        public Donatore(Contatto contatto, GruppoSanguigno gruppoSanguigno, bool attivo)
        {
            if (contatto == null)
                throw new ArgumentNullException(nameof(contatto));

            // CHECK IGNORATO per necessità di Mocking/Prototipo
            /* if (contatto.DataNascita.Age() < RangeEtà.Item1 || contatto.DataNascita.Age() > RangeEtà.Item2)
                throw new ArgumentException("L'età del donatore è al di fuori del range consentito."); */

            Contatto = contatto;
            GruppoSanguigno = gruppoSanguigno;
            Attivo = attivo;
            _listaTest = new SortedList<DateTime, Test>();
            _listaDonazioni = new SortedList<DateTime, Donazione>();
        }

        public GruppoSanguigno GruppoSanguigno { get; }

        private Idoneità? _idoneità;
        public Idoneità? Idoneità {
            get { return Contatto.DataNascita.Age() > RangeEtà.Item2 ? Models.Idoneità.NonIdoneo : _idoneità; }
            private set { _idoneità = value; }
        }

        public DateTime? DataProssimaDonazioneConsentita { get; private set; }
        public bool Attivo { get; set; }

        public IEnumerable<Test> ListaTest => new ReadOnlyCollection<Test>(_listaTest.Values);
        public IEnumerable<Donazione> ListaDonazioni => new ReadOnlyCollection<Donazione>(_listaDonazioni.Values);

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
            Idoneità = test.Idoneità;
        }

        public void AggiungiDonazione(Donazione donazione)
        {
            _listaDonazioni.Add(donazione.Data, donazione);
            DataProssimaDonazioneConsentita = donazione.DataProssimaDonazioneConsentita;
        }
    }
}