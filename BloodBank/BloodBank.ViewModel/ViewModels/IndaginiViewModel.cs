using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class IndaginiViewModel : Screen {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Indagine<Analisi>> _indagineAnalisiDataService;
        private readonly IDataService<Indagine<Questionario>> _indagineQuestionarioDataService;
        
        #region Constructor

        public IndaginiViewModel(IEventAggregator eventAggregator, IDataService<Indagine<Analisi>> indagineAnalisiDataService, IDataService<Indagine<Questionario>> indagineQuestionarioDataService) {
            _eventAggregator = eventAggregator;
            _indagineAnalisiDataService = indagineAnalisiDataService;
            _indagineQuestionarioDataService = indagineQuestionarioDataService;

            DisplayName = typeof(Indagine).Name;

            IndaginiAnalisi = new BindableCollection<Indagine<Analisi>>(_indagineAnalisiDataService.GetModels());
            IndaginiQuestionario = new BindableCollection<Indagine<Questionario>>(_indagineQuestionarioDataService.GetModels());
        }
        #endregion
        
        #region Properties

        public BindableCollection<Indagine<Analisi>> IndaginiAnalisi { get; set; }
        public BindableCollection<Indagine<Questionario>> IndaginiQuestionario { get; set; }

        #endregion

        #region Actions

        public void OpenNavMenu() {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        #endregion Actions
    }
}
