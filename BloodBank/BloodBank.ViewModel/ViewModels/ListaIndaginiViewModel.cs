using BloodBank.Model.Indagini;
using BloodBank.Model.Service;
using BloodBank.Model.Tests;
using BloodBank.ViewModel.Service;
using PropertyChanged;
using Stylet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank.ViewModel {

    [ImplementPropertyChanged]
    public class ListaIndaginiViewModel<T> : EditableViewModel<ListaIndagini<T>>, IListaIndagini where T : ListaVoci {
        private readonly IDataService<Indagine> _indagineDataService;

        public ListaIndaginiViewModel(IEventAggregator eventAggregator, IDataService<Indagine> indagineDataService,
            IDataService<ListaIndagini<T>, EditableViewModel<ListaIndagini<T>>> dataService, IModelValidator<IListaIndagini> validator)
            : base(eventAggregator, dataService, validator) {
            _indagineDataService = indagineDataService;

            RefreshCollections();
            NotifyPropertyChangedOnCollectionChanged();
        }

        #region Private Methods

        private void NotifyPropertyChangedOnCollectionChanged() {
            _indagini.CollectionChanged += (sender, args) => {
                NotifyOfPropertyChange(() => CanMoveUpIndagini);
                NotifyOfPropertyChange(() => CanMoveDownIndagini);
                IsChanged = true;
                ValidateProperty(() => Indagini);
            };
        }

        #endregion Private Methods

        #region Model Properties

        public string Nome { get; set; }
        private readonly BindableCollection<Indagine> _indagini = new BindableCollection<Indagine>();

        public IEnumerable<Indagine> Indagini {
            get { return _indagini; }
        }

        public DateTime DataCreazione { get; private set; }
        public DateTime DataUltimaModifica { get; private set; }

        #endregion Model Properties

        #region Other Properties

        public string Type => typeof(T).ToString().Split('.').Last();
        public BindableCollection<Indagine> IndaginiNonSelezionate { get; } = new BindableCollection<Indagine>();

        public IList IndaginiSelectedItems { get; set; }
        public IList IndaginiNonSelezionateSelectedItems { get; set; }

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

        protected override ListaIndagini<T> CreateModelFromViewModel() {
            ListaIndagini<T> model = new ListaIndagini<T>();
            model.Nome = Nome;
            model.Clear();
            model.AddRange(Indagini);
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