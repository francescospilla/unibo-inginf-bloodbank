using System.Collections.ObjectModel;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Events;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Indagini
{

    [ImplementPropertyChanged]
    public class IndaginiViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IDataService<Indagine<Analisi>> _indagineAnalisiDataService;
        private readonly IDataService<Indagine<Questionario>> _indagineQuestionarioDataService;
        private readonly IModelValidator<NuovaIndagineBooleanDialogViewModel> _nuovaIndagineBooleanDialogValidator;
        private readonly IModelValidator<NuovaIndagineRangeDialogViewModel<int>> _nuovaIndagineAnalisiIntDialogValidator;
        private readonly IModelValidator<NuovaIndagineRangeDialogViewModel<double>> _nuovaIndagineAnalisiDoubleDialogValidator;

        #region Constructor

        public IndaginiViewModel(IEventAggregator eventAggregator, IDataService<Indagine<Analisi>> indagineAnalisiDataService, IDataService<Indagine<Questionario>> indagineQuestionarioDataService, IModelValidator<NuovaIndagineBooleanDialogViewModel> nuovaIndagineBooleanDialogValidator, IModelValidator<NuovaIndagineRangeDialogViewModel<int>> nuovaIndagineAnalisiIntDialogValidator, IModelValidator<NuovaIndagineRangeDialogViewModel<double>> nuovaIndagineAnalisiDoubleDialogValidator)
        {
            _eventAggregator = eventAggregator;
            _indagineAnalisiDataService = indagineAnalisiDataService;
            _indagineQuestionarioDataService = indagineQuestionarioDataService;
            _nuovaIndagineBooleanDialogValidator = nuovaIndagineBooleanDialogValidator;
            _nuovaIndagineAnalisiIntDialogValidator = nuovaIndagineAnalisiIntDialogValidator;
            _nuovaIndagineAnalisiDoubleDialogValidator = nuovaIndagineAnalisiDoubleDialogValidator;

            IndaginiAnalisi = _indagineAnalisiDataService.GetObservableCollection();
            IndaginiQuestionario = _indagineQuestionarioDataService.GetObservableCollection();

            IndaginiAnalisi.CollectionChanged += (sender, e) => NotifyOfPropertyChange(() => IndaginiAnalisi);
            IndaginiQuestionario.CollectionChanged += (sender, e) => NotifyOfPropertyChange(() => IndaginiQuestionario);

        }
        #endregion

        #region Properties

        public ObservableCollection<Indagine<Analisi>> IndaginiAnalisi { get; set; }
        public ObservableCollection<Indagine<Questionario>> IndaginiQuestionario { get; set; }

        #endregion

        #region Actions

        public void OpenNavMenu()
        {
            _eventAggregator.Publish(new NavMenuEvent(NavMenuEvent.NavMenuStates.Open));
        }

        #region NuovaIndagineButton

        public void OpenNewDialog(IScreen dialog)
        {
            DialogEvent e = new DialogEvent(true, dialog);
            _eventAggregator.Publish(e);
        }

        public void OpenNewIndagineBooleanAnalisiDialog()
        {
            var dialog = new NuovaIndagineBooleanDialogViewModel<Analisi>(_eventAggregator, _indagineAnalisiDataService, _nuovaIndagineBooleanDialogValidator);
            OpenNewDialog(dialog);
        }

        public void OpenNewIndagineBooleanQuestionarioDialog()
        {
            var dialog = new NuovaIndagineBooleanDialogViewModel<Questionario>(_eventAggregator, _indagineQuestionarioDataService, _nuovaIndagineBooleanDialogValidator);
            OpenNewDialog(dialog);
        }


        public void OpenNewIndagineRangeIntAnalisiDialog()
        {
            var dialog = new NuovaIndagineRangeDialogViewModel<Analisi, int>(_eventAggregator, _indagineAnalisiDataService,_nuovaIndagineAnalisiIntDialogValidator);
            OpenNewDialog(dialog);
        }


        public void OpenNewIndagineRangeDoubleAnalisiDialog()
        {
            var dialog = new NuovaIndagineRangeDialogViewModel<Analisi, double>(_eventAggregator, _indagineAnalisiDataService, _nuovaIndagineAnalisiDoubleDialogValidator);
            OpenNewDialog(dialog);
        }

        public void OpenNewIndagineRangeIntQuestionarioDialog()
        {
            var dialog = new NuovaIndagineRangeDialogViewModel<Questionario, int>(_eventAggregator, _indagineQuestionarioDataService, _nuovaIndagineAnalisiIntDialogValidator);
            OpenNewDialog(dialog);
        }

        public void OpenNewIndagineRangeDoubleQuestionarioDialog()
        {
            var dialog = new NuovaIndagineRangeDialogViewModel<Questionario, double>(_eventAggregator, _indagineQuestionarioDataService, _nuovaIndagineAnalisiDoubleDialogValidator);
            OpenNewDialog(dialog);
        }


        #endregion
        
        #endregion Actions
    }
}
