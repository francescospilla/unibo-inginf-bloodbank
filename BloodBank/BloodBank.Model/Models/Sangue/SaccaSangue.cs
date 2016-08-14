﻿using BloodBank.Model.Donazioni;
using System;

namespace BloodBank.Model.Sangue {

    public class SaccaSangue {

        public SaccaSangue(Donazione donazione, GruppoSanguigno gruppo, ComponenteEmatico componente, DateTime dataPrelievo,
            int quantitàFrazionaria) {
            Id = Guid.NewGuid();
            Donazione = donazione;
            DataPrelievo = dataPrelievo;
            Gruppo = gruppo;
            Componente = componente;
            QuantitàFrazionaria = quantitàFrazionaria;
            Disponibile = true;
            DataScadenza = Componente.CalculateDataScadenza(DataPrelievo.Date);
        }

        public Guid Id { get; }
        public Donazione Donazione { get; }
        public DateTime DataPrelievo { get; }
        public DateTime DataScadenza { get; }
        public GruppoSanguigno Gruppo { get; }
        public ComponenteEmatico Componente { get; }
        public bool Disponibile { get; private set; }
        public int QuantitàFrazionaria { get; }

        public void Preleva() {
            if (!Disponibile)
                throw new AccessViolationException("La sacca di sangue è già stata prelevata");
            if (DateTime.Now >= DataScadenza)
                throw new AccessViolationException("La sacca di sangue è già scaduta");

            Disponibile = false;
        }

        protected bool Equals(SaccaSangue other) {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            SaccaSangue other = obj as SaccaSangue;
            return other != null && Equals(other);
        }

        public override int GetHashCode() {
            return Id.GetHashCode();
        }

        public override string ToString() {
            return Id + ", " + Componente + " " + Gruppo + " (" + DataPrelievo + ")";
        }
    }
}