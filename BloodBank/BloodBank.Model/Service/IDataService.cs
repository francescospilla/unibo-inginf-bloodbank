﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BloodBank.Model.Service {

    public interface IDataService<out TModel> where TModel : class {

        void AddModel(object model);

        ObservableCollection<object> GetObservableCollection();

        IEnumerable<TModel> GetModels();
    }

    public static class DataServiceExtension {

        public static IEnumerable<TModel> PoolAllModels<TModel>(this IEnumerable<IDataService<TModel>> dataServices) where TModel : class {
            return dataServices.Aggregate(new List<TModel>(), (list, service) => {
                list.AddRange(service.GetModels());
                return list;
            });
        }

        public static IEnumerable<TModel> PoolAllModels<TModel>(params IDataService<TModel>[] dataServices) where TModel : class {
            return dataServices.PoolAllModels();
        }
    }
}