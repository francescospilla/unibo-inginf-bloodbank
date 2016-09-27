using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BloodBank.Core.Attributes;
using BloodBank.Core.Extensions;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Components;
using BloodBank.ViewModel.Events;
using BloodBank.ViewModel.Service;
using BloodBank.ViewModel.ViewModels.Persone;
using PropertyChanged;
using Stylet;
using Stylet.DictionaryViewManager;

namespace BloodBank.ViewModel.ViewModels.Indagini {

    [ImplementPropertyChanged]
    [AssociatedView("ListaIndaginiView")]
    public class ListaIndaginiViewModel<U> : EditableViewModel<ListaIndagini<U>>, IListaIndagini where U : ListaVoci {
        private readonly IDataService<Indagine<U>> _indagineDataService;

        public ListaIndaginiViewModel(IEventAggregator eventAggregator, IDataService<Indagine<U>> indagineDataService,
            IDataService<ListaIndagini<U>> dataService, IModelValidator<IListaIndagini> validator)
            : base(eventAggregator, dataService, validator) {
            _indagineDataService = indagineDataService;

            _indagineDataService.GetObservableCollection().CollectionChanged += (sender, args) => {
                foreach (Indagine<U> item in args.NewItems) {
                    IndaginiNonSelezionate.Add(item);
                }
            };

            RefreshCollections();
            NotifyPropertyChangedOnCollectionChanged();
        }

        protected override void PublishViewModel() {
            EventAggregator.Publish(new ViewModelCollectionChangedEvent<ListaIndaginiViewModel<U>>(this));
        }

        protected override void SyncFromModelOnPropertyChanged(object sender, PropertyChangedEventArgs args) {
            DataUltimaModifica = Model.DataUltimaModifica;
        }

        #region Private Methods

        private void NotifyPropertyChangedOnCollectionChanged() {
            _indagini.CollectionChanged += (sender, args) => {
                NotifyOfPropertyChange(() => CanMoveUpIndagini);
                NotifyOfPropertyChange(() => CanMoveDownIndagini);
                NotifyOfPropertyChange(() => CountElementi);
                IsChanged = true;
                ValidateProperty(() => Indagini);
            };
        }

        #endregion Private Methods

        #region Model Properties

        [Searchable]
        public string Nome { get; set; }
        private readonly BindableCollection<Indagine> _indagini = new BindableCollection<Indagine>();

        [Searchable]
        public IEnumerable<Indagine> Indagini {
            get { return _indagini; }
        }

        public DateTime DataCreazione { get; private set; } = DateTime.Now;
        public DateTime DataUltimaModifica { get; private set; } = DateTime.Now;

        #endregion Model Properties

        #region Other Properties

        public string StringaRicerca => this.PropertyList(typeof (SearchableAttribute));
        public string Type => typeof(U).ToString().Split('.').Last();
        public BindableCollection<Indagine> IndaginiNonSelezionate { get; } = new BindableCollection<Indagine>();

        [DoNotSetChanged]
        public IList IndaginiSelectedItems { get; set; }
        [DoNotSetChanged]
        public IList IndaginiNonSelezionateSelectedItems { get; set; }

        public int CountElementi => Indagini.Count();

        #endregion Other Properties

        #region Actions

        public void NotifySelectionChanged(object sender, EventArgs e) {
            NotifyOfPropertyChange(() => CanTrasferisciIndaginiDa);
            NotifyOfPropertyChange(() => CanTrasferisciIndaginiA);
            NotifyOfPropertyChange(() => CanMoveUpIndagini);
            NotifyOfPropertyChange(() => CanMoveDownIndagini);
        }

        #region TrasferisciIndagini

        public bool CanTrasferisciIndaginiDa => CanExecuteTrasferisciIndagini(IndaginiNonSelezionateSelectedItems);

        public void TrasferisciIndaginiDa() {
            ExecuteTrasferisciIndagini(IndaginiNonSelezionate, _indagini, IndaginiNonSelezionateSelectedItems.Cast<Indagine>().ToList());
        }

        public bool CanTrasferisciIndaginiA => CanExecuteTrasferisciIndagini(IndaginiSelectedItems);

        public void TrasferisciIndaginiA() {
            ExecuteTrasferisciIndagini(_indagini, IndaginiNonSelezionate, IndaginiSelectedItems.Cast<Indagine>().ToList());
        }

        private bool CanExecuteTrasferisciIndagini(IList selected) {
            return selected?.Count > 0;
        }

        private void ExecuteTrasferisciIndagini(ICollection<Indagine> collectionFrom, ICollection<Indagine> collectionTo,
            List<Indagine> selected) {
            var indexedItems = collectionFrom.Select((item, index) => new KeyValuePair<int, Indagine>(index, item)); // indexed items of the original collection
            selected = selected.OrderBy(t => indexedItems.Single(t2 => t2.Value.Equals(t)).Key).ToList(); // selected items in the subcollection in the right order

            foreach (Indagine oi in selected) {
                collectionFrom.Remove(oi);
                collectionTo.Add(oi);
            }
        }

        #endregion TrasferisciIndagini

        #region MoveIndagini

        public bool CanMoveUpIndagini {
            get { return CanExecuteMoveIndagini(IndaginiSelectedItems, true); }
        }

        public void MoveUpIndagini() {
            ExecuteMoveIndagini(IndaginiSelectedItems.Cast<Indagine>().ToList(), true);
        }

        public bool CanMoveDownIndagini {
            get { return CanExecuteMoveIndagini(IndaginiSelectedItems, false); }
        }

        public void MoveDownIndagini() {
            ExecuteMoveIndagini(IndaginiSelectedItems.Cast<Indagine>().ToList(), false);
        }

        private void ExecuteMoveIndagini(List<Indagine> selected, bool toUp) {
            var indexedItems = Indagini.Select((item, index) => new KeyValuePair<int, Indagine>(index, item)); // indexed items of the original collection
            selected = selected.OrderBy(t => indexedItems.Single(t2 => t2.Value.Equals(t)).Key).ToList(); // selected items in the subcollection in the right order

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

        private bool CanExecuteMoveIndagini(IList selected, bool toUp) {
            if (selected == null)
                return false;

            IEnumerable<Indagine> enumerable = selected.Cast<Indagine>().ToList();

            return enumerable.Any() &&
                   !enumerable.Select(oi => _indagini.IndexOf(oi))
                       .Any(oldIndex => toUp ? oldIndex - 1 < 0 : oldIndex + 1 > _indagini.Count - 1);
        }

        #endregion MoveIndagini

        #endregion Actions

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

        protected override ListaIndagini<U> CreateModelFromViewModel(out bool isModelAlreadyRegistered) {
            ListaIndagini<U> model = new ListaIndagini<U> {Nome = Nome};
            model.Clear();
            model.AddRange(Indagini);
            isModelAlreadyRegistered = false;
            return model;
        }

        protected override void SyncViewModelToModel() {
            Model.Nome = Nome;
            Model.Clear();
            Model.AddRange(Indagini);
        }

        #endregion Mappings
    }
}