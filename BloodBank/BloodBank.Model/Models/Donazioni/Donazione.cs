using System;
using System.Collections.Generic;
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
            // Contract.Requires<ArgumentNullException>(donatore != null && data != null && visitaMedica != null && analisi != null && questionario != null, "Tutti i parametri devono essere diversi da null.");

            if (donatore.Idoneità != Idoneità.Idoneo)
                throw new ArgumentException("Non si può effettuare la donazione se il donatore non è " + Idoneità.Idoneo);
            if (!donatore.Attivo)
                throw new ArgumentException("Non si può effettuare la donazione se il donatore non è attivo");

            if (data <= donatore.ListaDonazioni.LastOrDefault()?.Data)
                throw new ArgumentException("Sono già presenti donazioni successive a questa data");
            if (!AreDateTestValide(data, visitaMedica.Data, analisi.Data, questionario.Data))
                throw new ArgumentException("Non si può effettuare la donazione se i test associati non sono stati effettuati il giorno stesso");

            Donatore = donatore;
            TipoDonazione = tipoDonazione;
            Data = data;
            VisitaMedica = visitaMedica;
            Analisi = analisi;
            Questionario = questionario;
            SaccheSangue = new List<SaccaSangue>();
            DataProssimaDonazioneConsentita = data.AddDays(tipoDonazione.GiorniDiRiposo);

            //Donatore.AggiungiDonazione(this);
        }

        public Donatore Donatore { get; }
        public DateTime Data { get; }
        public TipoDonazione TipoDonazione { get; }
        public VisitaMedica VisitaMedica { get; }
        public Analisi Analisi { get; }
        public Questionario Questionario { get; }
        public List<SaccaSangue> SaccheSangue { get; }

        public DateTime DataProssimaDonazioneConsentita { get; }

        public void EffettuaPrelievo(SaccaSangue.SaccaSangueFactory saccaSangueFactory) {
            // Contract.Requires<InvalidOperationException>(SaccheSangue.Count == 0, "SaccheSangue.Count == 0");

            foreach (ComponenteEmatico componente in TipoDonazione.ComponentiDerivati)
                for (int i = 0; i < TipoDonazione.QuantitàComponente(componente); i++)
                    saccaSangueFactory.CreateModel(this, Donatore.GruppoSanguigno, componente, Data);

            // Contract.Ensures(SaccheSangue.Count > 0, "SaccheSangue.Count > 0");
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

        public class DonazioneFactory : IFactory<Donazione> {
            private readonly IDataService<Donazione> _dataService;
            private readonly SaccaSangue.SaccaSangueFactory _saccaSangueFactory;

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