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

    public abstract class DataService<TModel> : IDataService<TModel> where TModel : class {
        private readonly IList<TModel> _models;

        protected DataService(IList<TModel> models) {
            _models = models;
        }

        public void AddModel(TModel model) {
            _models.Add(model);
        }

        public IEnumerable<TModel> GetModels() {
            return new ReadOnlyCollection<TModel>(_models);
        }
    }
}
