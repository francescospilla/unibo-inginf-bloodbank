using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.Model.Tests;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace BloodBank.Model.Donazioni {

    public class Donazione {

        public Donazione(Donatore donatore, TipoDonazione tipoDonazione, DateTime data, VisitaMedica visitaMedica,
            Analisi analisi, Questionario questionario) {
            Contract.Requires<ArgumentNullException>(donatore != null && data != null && visitaMedica != null && analisi != null && questionario != null, "Tutti i parametri devono essere diversi da null.");

            if (donatore.Idoneità != Idoneità.Idoneo)
                throw new ArgumentException("Non si può effettuare la donazione se il donatore non è " + Idoneità.Idoneo);
            if (!donatore.Attivo)
                throw new ArgumentException("Non si può effettuare la donazione se il donatore non è attivo");

            if (data <= donatore.ListaDonazioni.LastOrDefault()?.Data)
                throw new ArgumentException("Sono già presenti donazioni successive a questa data");
            if (!AreDateTestValide(data, new[] { visitaMedica.Data, analisi.Data, questionario.Data }))
                throw new ArgumentException("Non si può effettuare la donazione se i test associati non sono stati effettuati il giorno stesso");

            Donatore = donatore;
            TipoDonazione = tipoDonazione;
            Data = data;
            VisitaMedica = visitaMedica;
            Analisi = analisi;
            Questionario = questionario;
            SaccheSangue = new List<SaccaSangue>();
            DataProssimaDonazioneConsentita = data.AddDays(tipoDonazione.GiorniDiRiposo);

            EffettuaPrelievo();
        }

        public Donatore Donatore { get; }
        public DateTime Data { get; }
        public TipoDonazione TipoDonazione { get; }
        public VisitaMedica VisitaMedica { get; }
        public Analisi Analisi { get; }
        public Questionario Questionario { get; }
        public List<SaccaSangue> SaccheSangue { get; }

        public DateTime DataProssimaDonazioneConsentita { get; }

        public void EffettuaPrelievo() {
            Contract.Requires<InvalidOperationException>(SaccheSangue.Count == 0, "SaccheSangue.Count == 0");

            foreach (ComponenteEmatico componente in TipoDonazione.ComponentiDerivati) {
                for(int i=0 ; i<TipoDonazione.QuantitàComponente(componente); i++)
                    SaccheSangue.Add(new SaccaSangue(this, Donatore.GruppoSanguigno, componente, Data));
            }

            Contract.Ensures(SaccheSangue.Count > 0, "SaccheSangue.Count > 0");
        }

        private static bool AreDateTestValide(DateTime dataDonazione, IEnumerable<DateTime> dateTest) {
            return dateTest.All(data => data.Date.Equals(dataDonazione.Date) && data.TimeOfDay < dataDonazione.TimeOfDay);
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
    }
}