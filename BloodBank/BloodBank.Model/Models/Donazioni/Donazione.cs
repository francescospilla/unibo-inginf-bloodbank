﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using PropertyChanged;

namespace BloodBank.Model.Models.Donazioni {

    [ImplementPropertyChanged]
    public class Donazione {

        private Donazione(Donatore donatore, TipoDonazione tipoDonazione, DateTime data, VisitaMedica visitaMedica,
            Analisi analisi, Questionario questionario) {

            if (donatore == null || data == null || visitaMedica == null || analisi == null || questionario == null)
                throw new ArgumentException("Almeno un parametro non-opzionale del costruttore è null.");

            if (donatore.Idoneità != Idoneità.Idoneo)
                throw new ArgumentException("Non si può effettuare la donazione se il donatore non è " + Idoneità.Idoneo + ".");
            if (!donatore.Attivo)
                throw new ArgumentException("Non si può effettuare la donazione se il donatore non è attivo.");

            if (data >= DateTime.Now)
                throw new ArgumentException("La data della donazione non può essere futura");
            if (data <= donatore.ListaDonazioni.LastOrDefault()?.Data)
                throw new ArgumentException("Sono già presenti donazioni successive a questa data.");
            if (!AreDateTestValide(data, visitaMedica.Data, analisi.Data, questionario.Data))
                throw new ArgumentException("Non si può effettuare la donazione se i test associati non sono stati effettuati il giorno stesso.");
            if (donatore.DataProssimaDonazioneConsentita.HasValue && data <= donatore.DataProssimaDonazioneConsentita)
                throw new ArgumentException("Non è possibile effettuare una donazione se non si è superata DataProssimaDonazioneConsentita.");

            Donatore = donatore;
            TipoDonazione = tipoDonazione;
            Data = data;
            VisitaMedica = visitaMedica;
            Analisi = analisi;
            Questionario = questionario;
            _saccheSangue = new List<SaccaSangue>();
            DataProssimaDonazioneConsentita = data.AddDays(tipoDonazione.GiorniDiRiposo);
        }

        public Donatore Donatore { get; }
        public DateTime Data { get; }
        public TipoDonazione TipoDonazione { get; }
        public VisitaMedica VisitaMedica { get; }
        public Analisi Analisi { get; }
        public Questionario Questionario { get; }

        private readonly List<SaccaSangue> _saccheSangue;
        public IEnumerable<SaccaSangue> SaccheSangue => new ReadOnlyCollection<SaccaSangue>(_saccheSangue);

        public DateTime DataProssimaDonazioneConsentita { get; }

        private void EffettuaPrelievo(ISaccaSangueFactory saccaSangueFactory) {

            foreach (ComponenteEmatico componente in TipoDonazione.ComponentiDerivati)
                for (int i = 0; i < TipoDonazione.QuantitàComponente(componente); i++)
                    saccaSangueFactory.CreateModel(this, Donatore.GruppoSanguigno, componente, Data);

        }

        public void AggiungiSaccaSangue(SaccaSangue saccaSangue) {
            _saccheSangue.Add(saccaSangue);
        }

        private static bool AreDateTestValide(DateTime dataDonazione, params DateTime[] dateTest) {
            return dateTest.All(data => data.Date.Equals(dataDonazione.Date) && data.CompareTo(dataDonazione) < 0);
        }

        protected bool Equals(Donazione other) {
            return Equals(Donatore, other.Donatore) && Data.Date.Equals(other.Data.Date);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            Donazione other = obj as Donazione;
            return other != null && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                return ((Donatore?.GetHashCode() ?? 0) * 397) ^ Data.Date.GetHashCode();
            }
        }

        public override string ToString() {
            return "Donatore: " + Donatore + ", Data: " + Data + ", Tipo: " + TipoDonazione;
        }

        public class DonazioneFactory : IDonazioneFactory {
            private readonly IDataService<Donazione> _dataService;
            private readonly ISaccaSangueFactory _saccaSangueFactory;

            public DonazioneFactory(IDataService<Donazione> dataService, SaccaSangue.SaccaSangueFactory saccaSangueFactory) {
                _dataService = dataService;
                _saccaSangueFactory = saccaSangueFactory;
            }

            public Donazione CreateModel(Donatore donatore, TipoDonazione tipoDonazione, DateTime data, VisitaMedica visitaMedica,
                Analisi analisi, Questionario questionario) {
                var model = new Donazione(donatore, tipoDonazione, data, visitaMedica, analisi, questionario);
                model.EffettuaPrelievo(_saccaSangueFactory);
                donatore.AggiungiDonazione(model);
                _dataService.AddModel(model);
                return model;
            }
        }
    }


}