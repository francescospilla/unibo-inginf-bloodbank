using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.ViewModels;
using Stylet;

namespace BloodBank.ViewModel.Services {
    public abstract class DataService<TModel, TViewModel> : IDataService<TModel, TViewModel> where TViewModel : ValidatingModelBase
    {
        public abstract IEnumerable<TModel> GetModels();

        public IEnumerable<TViewModel> GetViewModels() {
            IModelValidator<TModel> validator = IoC.Get<IModelValidator<TModel>>();
            return
                GetModels()
                    .Select(model => Activator.CreateInstance(typeof(TViewModel), new object[] { validator, model })).Cast<TViewModel>()
                    .ToList();
        }
    }
}
