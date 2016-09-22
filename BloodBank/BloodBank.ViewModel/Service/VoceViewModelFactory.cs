using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.ViewModels.Indagini;
using Ninject;
using Stylet;
using StyletIoC;

namespace BloodBank.ViewModel.Service {
    public class VoceViewModelFactory<U> where U : ListaVoci {
        private readonly IKernel _kernel;
        private readonly IEventAggregator _eventAggregator;

        public VoceViewModelFactory(IKernel kernel, IEventAggregator eventAggregator) {
            _kernel = kernel;
            _eventAggregator = eventAggregator;
        }

        public IEnumerable<VoceViewModel> CreateViewModelsFrom(ListaIndagini<U> selectedListaIndagini) {
            return selectedListaIndagini.Cast<Indagine<U>>().Select(CreateViewModelFrom).ToList();
        }

        private VoceViewModel CreateViewModelFrom(Indagine<U> indagine){

            Type[] genericTypeArguments = indagine.GetType().BaseType.GenericTypeArguments;
            Type viewModelType = typeof (VoceViewModel<,>).MakeGenericType(genericTypeArguments);

            Type voceViewModelType = typeof (VoceViewModel<>).MakeGenericType(genericTypeArguments[1]);

            Type validatorType = typeof (IModelValidator<>).MakeGenericType(voceViewModelType);
            IModelValidator validator = (IModelValidator) _kernel.Get(validatorType);

            object viewModel = Activator.CreateInstance(viewModelType, _eventAggregator, validator, indagine);
            return viewModel as VoceViewModel;
        }

        public IEnumerable<Voce<U>> GetModelsFromViewModels(IEnumerable<VoceViewModel> vociViewModels) {
            if (vociViewModels == null || !vociViewModels.Any() || vociViewModels.Any(vm => !vm.CanSave))
                throw new InvalidOperationException("At least one viewModel in the collection has errors.");

            return vociViewModels.Select(vm => (Voce<U>) vm.Save()).ToList();
        }
    }
}