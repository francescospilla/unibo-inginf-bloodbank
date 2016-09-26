using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels
{
    [ImplementPropertyChanged]
    [AssociatedView("NuovaIndagineBooleanDialogView")]
    public abstract class NuovaIndagineBooleanDialogViewModel : NuovaIndagineDialogViewModel
    {
        protected NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator) {
        }

        #region Properties

        public bool RisultatoCorretto { get; set; }

        #endregion Properties

        public IEnumerable<bool> RisultatoCorrettoEnumerable => typeof (bool).Enumerable() as IEnumerable<bool>;
    }

    [ImplementPropertyChanged]
    public class NuovaIndagineBooleanDialogViewModel<U> : NuovaIndagineBooleanDialogViewModel where U : ListaVoci
    {
        private readonly IDataService<Indagine<U>> _dataService;

        public NuovaIndagineBooleanDialogViewModel(IEventAggregator eventAggregator, IDataService<Indagine<U>> dataService, IModelValidator<NuovaIndagineBooleanDialogViewModel> validator) : base(eventAggregator, validator) {
            _dataService = dataService;
        }

        public string Type => typeof(U).ToString().Split('.').Last();
        
        protected override Indagine CreateModelFromViewModel()
        {
            return new IndagineBoolean<U>(Testo, IdoneitaFallimento, RisultatoCorretto);
        }

        protected override void AddModel(Indagine model) {
            _dataService.AddModel((Indagine<U>) model);
        }
    }
}