﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.Components {

    [ImplementPropertyChanged]
    public abstract class ViewModel<TModel> : Screen where TModel : class{
        protected IEventAggregator EventAggregator;
        private TModel _model;

        protected ViewModel(IEventAggregator eventAggregator, IModelValidator validator = null) : base(validator) {
            EventAggregator = eventAggregator;
        }

        public virtual TModel Model {
            get { return _model; }
            set {
                _model = value;
                SyncModelToViewModel();
            }
        }

        public bool IsInitialized { get { return Model != null; } }

        protected abstract void SyncModelToViewModel();
    }
}