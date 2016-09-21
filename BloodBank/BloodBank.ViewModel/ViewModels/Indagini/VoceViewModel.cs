using System;
using System.Collections.Generic;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Indagini {

    [ImplementPropertyChanged]
    [AssociatedView("VoceView")]
    public abstract class VoceViewModel : Screen {
        protected readonly IEventAggregator _eventAggregator;

        protected VoceViewModel(IEventAggregator eventAggregator, IModelValidator validator)
            : base(validator) {
            _eventAggregator = eventAggregator;

            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
        }

        #region Save

        protected override void OnValidationStateChanged(IEnumerable<string> changedProperties) {
            base.OnValidationStateChanged(changedProperties);
            // Fody can't weave other assemblies, so we have to manually raise this
            NotifyOfPropertyChange(() => CanSave);
        }

        public bool CanSave => !HasErrors;

        public Voce Save() {
            if (Validator != null && !Validate()) return null;
            return CreateModelFromViewModel();

        }

        protected abstract Voce CreateModelFromViewModel();

        #endregion

    }

    public abstract class VoceViewModel<T> : VoceViewModel where T : struct {
        protected VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel<T>> validator) : base(eventAggregator, validator) {
        }
        
        public T? Risposta { get; set; }

    }


    [ImplementPropertyChanged]
    public class VoceViewModel<U, T> : VoceViewModel<T> where T : struct, IComparable<T> where U : ListaVoci {

        #region Constructor

        public VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel<T>> validator, Indagine<U, T> indagine) : base(eventAggregator, validator) {
            Indagine = indagine;
        }

        public VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel<T>> validator, Indagine<U> indagine) : this(eventAggregator, validator, indagine as Indagine<U, T>) {
        }

        #endregion

        #region Properties

        public Indagine<U, T> Indagine { get; }

        #endregion

        public IEnumerable<T> RisultatoEnumerable => typeof(T).Enumerable() as IEnumerable<T>;

        #region Overrides of VoceViewModel<T>

        protected override Voce CreateModelFromViewModel() {
            return new Voce<U, T>(Indagine, Risposta.GetValueOrDefault());
        }

        #endregion
    }

}
