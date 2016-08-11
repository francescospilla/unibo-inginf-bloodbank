﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    [ImplementPropertyChanged]
    public class ListaIndaginiViewModel<T> : EditableViewModel<ListaIndagini<T>>, IListaIndagini where T : ListaVoci {
        private readonly IDataService<Indagine> _indagineDataService;

        public ListaIndaginiViewModel(IEventAggregator eventAggregator, IDataService<Indagine> indagineDataService,
            IDataService<ListaIndagini<T>> dataService, IModelValidator<IListaIndagini> validator, ListaIndagini<T> model = null)
            : base(eventAggregator, dataService, validator, model) {
            _indagineDataService = indagineDataService;

            RefreshCollections();
            NotifyOfPropertyChangedOnCollectionChanged();
        }

        #region Private Methods
        private void NotifyOfPropertyChangedOnCollectionChanged() {
            IndaginiNonSelezionateSelectedItems.CollectionChanged += (sender, args) => {
                NotifyOfPropertyChange(() => CanTrasferisciIndaginiDa);
            };
            IndaginiSelectedItems.CollectionChanged += (sender, args) => {
                NotifyOfPropertyChange(() => CanTrasferisciIndaginiA);
                NotifyOfPropertyChange(() => CanMoveUpIndagini);
                NotifyOfPropertyChange(() => CanMoveDownIndagini);
            };
            _indagini.CollectionChanged += (sender, args) => {
                NotifyOfPropertyChange(() => CanMoveUpIndagini);
                NotifyOfPropertyChange(() => CanMoveDownIndagini);
                IsChanged = true;
                ValidateProperty(() => Indagini);
            };
        }
        #endregion

        public override void AddModel(ListaIndagini<T> model) {
            DataService.AddModel(model);
            // TODO:
        }

        #region Model Properties
        public string Nome { get; set; }
        private readonly BindableCollection<Indagine> _indagini = new BindableCollection<Indagine>();
        public IEnumerable<Indagine> Indagini {
            get { return _indagini; }
        }

        public DateTime DataCreazione { get; private set; }
        public DateTime DataUltimaModifica { get; private set; }
        #endregion

        #region Other Properties
        public string Type => typeof(T).ToString().Split('.').Last();
        public BindableCollection<Indagine> IndaginiNonSelezionate { get; } = new BindableCollection<Indagine>();

        // Necessarie perchè WPF non supporta il binding su SelectedItems delle ListBox. Si rimedia con il MultiSelectionBehavior.
        public ObservableCollection<Indagine> IndaginiSelectedItems { get; } = new BindableCollection<Indagine>();
        public ObservableCollection<Indagine> IndaginiNonSelezionateSelectedItems { get; } = new BindableCollection<Indagine>();
        #endregion

        #region Actions

        #region TrasferisciIndagini

        public bool CanTrasferisciIndaginiDa => CanExecuteTrasferisciIndagini(IndaginiNonSelezionateSelectedItems);

        public void TrasferisciIndaginiDa() {
            ExecuteTrasferisciIndagini(IndaginiNonSelezionate, _indagini, IndaginiNonSelezionateSelectedItems);
        }

        public bool CanTrasferisciIndaginiA => CanExecuteTrasferisciIndagini(IndaginiSelectedItems);

        public void TrasferisciIndaginiA() {
            ExecuteTrasferisciIndagini(_indagini, IndaginiNonSelezionate, IndaginiSelectedItems);
        }

        private bool CanExecuteTrasferisciIndagini(ICollection<Indagine> selected) {
            return selected?.Count > 0;
        }

        private void ExecuteTrasferisciIndagini(ICollection<Indagine> collectionFrom, ICollection<Indagine> collectionTo,
            IEnumerable<Indagine> selected) {
            foreach (Indagine oi in selected.ToList()) {
                collectionFrom.Remove(oi);
                collectionTo.Add(oi);
            }
        }

        #endregion

        #region MoveIndagini

        public bool CanMoveUpIndagini {
            get { return CanExecuteMoveIndagini(IndaginiSelectedItems, true); }
        }

        public void MoveUpIndagini() {
            ExecuteMoveIndagini(IndaginiSelectedItems, true);
        }

        public bool CanMoveDownIndagini {
            get { return CanExecuteMoveIndagini(IndaginiSelectedItems, false); }
        }

        public void MoveDownIndagini() {
            ExecuteMoveIndagini(IndaginiSelectedItems, false);
        }

        private void ExecuteMoveIndagini(IList<Indagine> selected, bool toUp) {
            if (toUp) {
                for (int index = 0; index < selected.Count; index++) {
                    Indagine oi = selected[index];
                    int oldIndex = _indagini.IndexOf(oi);

                    _indagini.Move(oldIndex, oldIndex - 1);
                }
            } else {
                for (int index = selected.Count - 1; 0 < index + 1; index--) {
                    Indagine oi = selected[index];
                    int oldIndex = _indagini.IndexOf(oi);

                    _indagini.Move(oldIndex, oldIndex + 1);
                }
            }
        }

        private bool CanExecuteMoveIndagini(ICollection<Indagine> selected, bool toUp) {
            if (selected == null)
                return false;

            return selected.Count > 0 &&
                   !selected.Select(oi => _indagini.IndexOf(oi))
                       .Any(oldIndex => toUp ? oldIndex - 1 < 0 : oldIndex + 1 > _indagini.Count - 1);
        }

        #endregion

        #endregion

        #region Mappings

        private void RefreshCollections() {
            IndaginiNonSelezionate.Clear();
            _indagini.Clear();

            IndaginiNonSelezionate.AddRange(_indagineDataService.GetModels());

            if (Model?.Indagini == null) return;
            foreach (Indagine indagine in Model.Indagini) {
                _indagini.Add(indagine);
                IndaginiNonSelezionate.Remove(indagine);
            }
        }

        protected override void SyncModelToViewModel() {
            Nome = Model.Nome;
            DataCreazione = Model.DataCreazione;
            DataUltimaModifica = Model.DataUltimaModifica;
            RefreshCollections();
        }

        protected override ListaIndagini<T> CreateModelFromViewModel() {
            ListaIndagini<T> model = new ListaIndagini<T>(Nome);
            model.Clear();
            model.AddRange(Indagini);
            return model;
        }

        protected override void SyncViewModelToModel() {
            Model.Nome = Nome;
            Model.Clear();
            Model.AddRange(Indagini);
        }
        #endregion
    }
}