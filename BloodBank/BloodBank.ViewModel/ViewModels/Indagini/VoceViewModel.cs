using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Indagini {

    [ImplementPropertyChanged]
    [AssociatedView("VoceView")]
    public abstract class VoceViewModel : Screen {
        private readonly IEventAggregator _eventAggregator;

        protected VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel> validator)
            : base(validator) {
            _eventAggregator = eventAggregator;

            if (validator != null) {
                AutoValidate = true;
                Validate();
            }
        }

        public abstract object Risultato { get; set; }
    }

    public abstract class VoceViewModel<U> : VoceViewModel where U : ListaVoci {
        protected VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel> validator) : base(eventAggregator, validator) {
        }
    }


    // TODO: Deve ritornare T?
    [ImplementPropertyChanged]
    public class VoceViewModel<U, T> : VoceViewModel<U> where T : IComparable<T> where U : ListaVoci {

        #region Constructor

        public VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel> validator, Indagine<U, T> indagine) : base(eventAggregator, validator) {
            Indagine = indagine;
        }

        public VoceViewModel(IEventAggregator eventAggregator, IModelValidator<VoceViewModel> validator, Indagine<U> indagine) : this(eventAggregator, validator, indagine as Indagine<U, T>) {
        }

        #endregion

        #region Properties

        public Indagine<U, T> Indagine { get; }

        public T RisultatoTyped { get; set; }

        public override object Risultato {
            get { return RisultatoTyped; }
            set { RisultatoTyped = (T) value; }
        }


        #endregion

        public IEnumerable<T> RisultatoEnumerable => (IEnumerable<T>)typeof(T).Enumerable();

        #region Overrides of VoceViewModel<U>


        #endregion
    }

}
