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
    public abstract class DataService<TModel, TViewModel> :  IDataService<TModel, TViewModel> {
        private readonly IList<TModel> _models;

        protected DataService(IList<TModel> models)
        {
            _models = models;
        }

        public ReadOnlyCollection<TModel> GetModels() { return new ReadOnlyCollection<TModel>(_models);}
        
        public IEnumerable<TViewModel> GetViewModels()
        {
            IEventAggregator eventAggregator = IoC.Get<IEventAggregator>();
            IDataService<TModel, TViewModel> dataService = IoC.Get<IDataService<TModel, TViewModel>>();
            IModelValidator<TModel> validator = IoC.Get<IModelValidator<TModel>>();

            return
                _models.Select(model => Activator.CreateInstance(typeof(TViewModel), new object[] {eventAggregator, dataService, validator, model }))
                .Cast<TViewModel>().ToList();
        }

        public void AddNewModel(TModel model) => _models.Add(model);
    }
}
