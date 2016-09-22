using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Service;
using PropertyChanged;

namespace BloodBank.Model.Models.Sangue
{

    [ImplementPropertyChanged]
    public class SaccaSangue
    {

        private SaccaSangue(Donazione donazione, GruppoSanguigno gruppo, ComponenteEmatico componente, DateTime dataPrelievo)
        {
            Id = Guid.NewGuid();
            Donazione = donazione;
            DataPrelievo = dataPrelievo;
            Gruppo = gruppo;
            Componente = componente;
            Disponibile = true;
            DataScadenza = Componente.CalculateDataScadenza(DataPrelievo.Date);
        }

        public Guid Id { get; }
        public Donazione Donazione { get; }
        public DateTime DataPrelievo { get; }
        public DateTime DataScadenza { get; }
        public GruppoSanguigno Gruppo { get; }
        public ComponenteEmatico Componente { get; }
        public bool Disponibile { get; private set; }
        public bool Scaduta => DateTime.Now >= DataScadenza;

        public void Preleva()
        {
            if (!Disponibile)
                throw new AccessViolationException("La sacca di sangue è già stata prelevata");
            if (Scaduta)
                throw new AccessViolationException("La sacca di sangue è già scaduta");

            Disponibile = false;
        }

        protected bool Equals(SaccaSangue other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            SaccaSangue other = obj as SaccaSangue;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id + ", " + Componente + " " + Gruppo + " (" + DataPrelievo + ")";
        }

        public class SaccaSangueFactory : ISaccaSangueFactory {
            private readonly IDataService<SaccaSangue> _dataService;

            public SaccaSangueFactory(IDataService<SaccaSangue> dataService) {
                _dataService = dataService;
            }

            public SaccaSangue CreateModel(Donazione donazione, GruppoSanguigno gruppo, ComponenteEmatico componente, DateTime dataPrelievo) {
                var model = new SaccaSangue(donazione, gruppo, componente, dataPrelievo);
                donazione.AggiungiSaccaSangue(model);
                _dataService.AddModel(model);
                return model;
            }
        }
    }
}