using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.ViewModels;
using Stylet;

namespace BloodBank.ViewModel.Services {
    public abstract class DataService<TModel, TViewModel> : IDataService<TModel, TViewModel>, IDataService where TModel : class where TViewModel : IViewModel<TModel> {
        private readonly BindableCollection<TViewModel> _viewModels;
        private readonly IEventAggregator _eventAggregator;
        private readonly IModelValidator<TViewModel> _validator;

        protected DataService(IEnumerable<TModel> models) {
            _eventAggregator = IoC.Get<IEventAggregator>();
            _validator = IoC.Get<IModelValidator<TViewModel>>();
            _viewModels = new BindableCollection<TViewModel>(models.Select(CreateInstance));
        }

        private TViewModel CreateInstance(TModel model) {
            return (TViewModel)Activator.CreateInstance(typeof(TViewModel), _eventAggregator, this, _validator, model);
        }

        #region IDataService Non-Generic Implementation

        void IDataService.AddNewModel(object model) {
            AddNewModel(model as TModel);
        }

        IEnumerable<object> IDataService.GetModels() {
            return GetModels();
        }

        IEnumerable<object> IDataService.GetViewModels() {
            return GetViewModels().Cast<object>();
        }

        #endregion

        public void AddNewModel(TModel model) {
            _viewModels.Add(CreateInstance(model));
        }

        public ReadOnlyCollection<TModel> GetModels() { return new ReadOnlyCollection<TModel>(_viewModels.Select(vm => vm.Model).ToList()); }

        public BindableCollection<TViewModel> GetViewModels() {
            return _viewModels;
        }

    }
}
