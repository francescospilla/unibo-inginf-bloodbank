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
using BloodBank.ViewModel.Validation.Indagini;
using PropertyChanged;
using Stylet;
using Stylet.FluentValidation;

namespace BloodBank.ViewModel.ViewModels
{

    [ImplementPropertyChanged]
    public class IndaginiViewModel : Screen, IHandle<NuovaIndagineEvent>
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

            _eventAggregator.Subscribe(this);

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
            var dialog = new NuovaIndagineBooleanAnalisiDialogViewModel(_eventAggregator, _nuovaIndagineBooleanDialogValidator);
            OpenNewDialog(dialog);
        }

        public void OpenNewIndagineBooleanQuestionarioDialog()
        {
            var dialog = new NuovaIndagineBooleanQuestionarioDialogViewModel(_eventAggregator, _nuovaIndagineBooleanDialogValidator);
            OpenNewDialog(dialog);
        }


        public void OpenNewIndagineRangeIntAnalisiDialog()
        {
            var dialog = new NuovaIndagineRangeIntAnalisiDialogViewModel(_eventAggregator, _nuovaIndagineAnalisiIntDialogValidator);
            OpenNewDialog(dialog);
        }


        public void OpenNewIndagineRangeDoubleAnalisiDialog()
        {
            var dialog = new NuovaIndagineRangeDoubleAnalisiDialogViewModel(_eventAggregator, _nuovaIndagineAnalisiDoubleDialogValidator);
            OpenNewDialog(dialog);
        }

        public void OpenNewIndagineRangeIntQuestionarioDialog()
        {
            var dialog = new NuovaIndagineRangeIntQuestionarioDialogViewModel(_eventAggregator, _nuovaIndagineAnalisiIntDialogValidator);
            OpenNewDialog(dialog);
        }


        public void OpenNewIndagineRangeDoubleQuestionarioDialog()
        {
            var dialog = new NuovaIndagineRangeDoubleQuestionarioDialogViewModel(_eventAggregator, _nuovaIndagineAnalisiDoubleDialogValidator);
            OpenNewDialog(dialog);
        }


        #endregion

        #region NuovaIndagineEvent

        public void Handle(NuovaIndagineEvent e)
        {
            _eventAggregator.Publish(new DialogEvent(false, null));

            Indagine<Analisi> indagineAnalisi = e.Indagine as Indagine<Analisi>;
            if (indagineAnalisi != null)
            {
                IndaginiAnalisi.Add(indagineAnalisi);
                _indagineAnalisiDataService.AddModel(indagineAnalisi);
                NotifyOfPropertyChange(() => IndaginiAnalisi);
            }

            Indagine<Questionario> indagineQuestionario = e.Indagine as Indagine<Questionario>;
            if (indagineQuestionario != null)
            {
                IndaginiQuestionario.Add(indagineQuestionario);
                _indagineQuestionarioDataService.AddModel(indagineQuestionario);
                NotifyOfPropertyChange(() => IndaginiQuestionario);
            }
        }

        #endregion

        #endregion Actions
    }
}
