using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;

namespace BloodBank.Mock.Indagini {
    public abstract class IndagineMockDataService<U> : MockDataService<Indagine<U>>, IDataService<Indagine> where U : ListaVoci {
        #region Implementation of IDataService<Indagine>

        void IDataService<Indagine>.AddModel(Indagine model) {
            Indagine<U> indagine = model as Indagine<U>;
            if (indagine == null)
                throw new InvalidOperationException();

            AddModel(indagine);
        }

        ObservableCollection<Indagine> IDataService<Indagine>.GetObservableCollection() {
            return new ObservableCollection<Indagine>(GetObservableCollection());
        }

        IEnumerable<Indagine> IDataService<Indagine>.GetModels() {
            return GetModels();
        }
        #endregion
    }
}