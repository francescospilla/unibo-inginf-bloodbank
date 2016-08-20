﻿using System.Collections.Generic;
using BloodBank.ViewModel.Components;

namespace BloodBank.ViewModel.Service {

    public interface IDataService<TModel, out TViewModel>
        where TModel : class
        where TViewModel : ViewModel<TModel> {

        void AddModel(TModel model);

        void AddModelAndCreatedViewModel(TModel model);

        void AddExistingViewModel(object viewModel);

        void AddModelAndExistingViewModel(TModel model, object viewModel);

        IEnumerable<TModel> GetModels();

        IEnumerable<TViewModel> GetViewModels();
    }
}