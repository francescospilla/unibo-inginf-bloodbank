using System;
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
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    public class SaccaSangueViewModel : EditableViewModel<SaccaSangue> {

        #region Constructors
        public SaccaSangueViewModel(IEventAggregator eventAggregator, IDataService<SaccaSangue, EditableViewModel<SaccaSangue>> dataService, IModelValidator validator) : base(eventAggregator, dataService, validator) {
        }
        #endregion

        #region Properties

        public new string DisplayName => IsInitialized ? IdSacca : "Nuovo sacca";

        public string IdSacca => Id.ToString();

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        [Searchable]
        public Guid Id { get; set; }
        [Searchable]
        public Donazione Donazione { get; }
        [Searchable]
        public DateTime DataPrelievo { get; }
        [Searchable]
        public DateTime DataScadenza { get; }
        [Searchable]
        public GruppoSanguigno Gruppo { get; }
        [Searchable]
        public ComponenteEmatico Componente { get; }
        [Searchable]
        public bool Disponibile { get; private set; }
        [Searchable]
        public int QuantitàFrazionaria { get; }

        #endregion

        public IEnumerable<GruppoSanguigno> GruppoSanguignoEnumerable { get; } = EnumExtensions.Values<GruppoSanguigno>();
        public IEnumerable<bool> DisponibileEnumerable { get; } = new[] { true, false };
        public IEnumerable<ComponenteEmatico> ComponenteEmaticoEnumerable { get; } = EnumExtensions.Values<ComponenteEmatico>();

        #region Mappings

        protected override void SyncModelToViewModel()
        {
            Id = Model.Id;
            throw new InvalidOperationException();
        }

        protected override SaccaSangue CreateModelFromViewModel() {
            return new SaccaSangue(Donazione, Gruppo, Componente, DataPrelievo, QuantitàFrazionaria);
        }

        protected override void SyncViewModelToModel() {
            throw new InvalidOperationException();
        }

        #endregion
    }
}
