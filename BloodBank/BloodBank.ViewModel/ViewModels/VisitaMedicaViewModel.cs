using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Service;
using Stylet;
using BloodBank.Model.Donatori;
using BloodBank.Model.Service;

namespace BloodBank.ViewModel.ViewModels
{
    public class VisitaMedicaViewModel : EditableViewModel<VisitaMedica>
    {
        private readonly IDataService<Donatore> _donatoreDataService;

        #region Constructors

        public VisitaMedicaViewModel(IEventAggregator eventAggregator, IDataService<Donatore> donatoreDataService, IDataService<VisitaMedica, EditableViewModel<VisitaMedica>> dataService, IModelValidator validator) : base(eventAggregator, dataService, validator)
        {
            _donatoreDataService = donatoreDataService;
        }

        #endregion Constructors

        #region Properties

        public string StringaRicerca => this.PropertyList(typeof(SearchableAttribute));

        [Searchable]
        public Donatore Donatore { get; set; }
        public string DescrizioneBreve { get; set;  }
        public DateTime Data { get; set;  }
        public Idoneità Idoneità { get; set;  }

        #endregion Properties

        public IEnumerable<Idoneità> IdoneitàEnumerable { get; } = EnumExtensions.Values<Idoneità>();
        public IEnumerable<Donatore> DonatoreEnumerable { get; } = EnumExtensions.Values<Donatore>();

        #region Mappings

        protected override void SyncModelToViewModel()
        {
            Donatore = Model.Donatore;
            DescrizioneBreve = Model.DescrizioneBreve;
            Data = Model.Data;
            Idoneità = Model.Idoneità;
        }

        protected override VisitaMedica CreateModelFromViewModel()
        {
            return new VisitaMedica(Donatore, DescrizioneBreve, Data, Idoneità);
        }

        protected override void SyncViewModelToModel()
        {
            throw new InvalidOperationException();
        }

        #endregion Mappings
    }
}
