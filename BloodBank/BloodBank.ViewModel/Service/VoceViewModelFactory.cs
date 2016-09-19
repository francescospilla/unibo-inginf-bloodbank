using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.ViewModel.Validation;
using BloodBank.ViewModel.ViewModels.Indagini;
using StructureMap;
using Stylet;
using Stylet.FluentValidation;

namespace BloodBank.ViewModel.Service {
    public class VoceViewModelFactory<U> where U : ListaVoci {
        private readonly IEventAggregator _eventAggregator;
        private readonly Container _container;

        public VoceViewModelFactory(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;
            _container = new Container(config => {
                config.ConfigureForFluentValidation(typeof (ValidatorExtensions));
            });

            //Debug.WriteLine(_container.WhatDoIHave());
        }

        public IEnumerable<VoceViewModel> CreateViewModelsFrom(ListaIndaginiViewModel<U> selectedListaIndagini) {
            return selectedListaIndagini.Model.Cast<Indagine<U>>().Select(CreateViewModelFrom).ToList();
        }

        private VoceViewModel CreateViewModelFrom(Indagine<U> indagine){

            Type[] genericTypeArguments = indagine.GetType().BaseType.GenericTypeArguments;
            Type viewModelType = typeof (VoceViewModel<,>).MakeGenericType(genericTypeArguments);

            Type voceViewModelType = typeof (VoceViewModel<>).MakeGenericType(genericTypeArguments[1]);
            IModelValidator validator = _container.ForGenericType(typeof(IModelValidator<>)).WithParameters(voceViewModelType).GetInstanceAs<IModelValidator>();

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