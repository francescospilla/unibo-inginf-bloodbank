﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Donazioni;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class SaccaSangueViewModel : ViewModel<SaccaSangue> {

        #region Constructors
        public SaccaSangueViewModel(IEventAggregator eventAggregator) : base(eventAggregator) {
        }
        #endregion

        #region Properties

        public new string DisplayName => IsInitialized ? IdSacca : "Nuova sacca";

        public string IdSacca => Id.ToString();

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        [Searchable]
        public Guid Id { get; set; }
        [Searchable]
        public Donazione Donazione { get; set; }
        [Searchable]
        public DateTime DataPrelievo { get; set; }
        [Searchable]
        public DateTime DataScadenza { get; set; }
        [Searchable]
        public GruppoSanguigno Gruppo { get; set; }
        [Searchable]
        public ComponenteEmatico Componente { get; set; }
        [Searchable]
        public bool Disponibile { get; set; }

        #endregion

        public IEnumerable<GruppoSanguigno> GruppoSanguignoEnumerable { get; } = EnumExtensions.Values<GruppoSanguigno>();
        public IEnumerable<bool> DisponibileEnumerable { get; } = new[] { true, false };
        public IEnumerable<ComponenteEmatico> ComponenteEmaticoEnumerable { get; } = ComponenteEmatico.Values;

        #region Mappings

        protected override void SyncModelToViewModel() {
            Id = Model.Id;
            Donazione = Model.Donazione;
            DataPrelievo = Model.DataPrelievo;
            DataScadenza = Model.DataScadenza;
            Gruppo = Model.Gruppo;
            Componente = Model.Componente;
            Disponibile = Model.Disponibile;
        }

        #endregion

        #region Actions

        public bool CanPrelevaSacca => Disponibile;
        public void PrelevaSacca() {
            Model.Preleva();
            SyncModelToViewModel();
        }

        #endregion
    }
}
