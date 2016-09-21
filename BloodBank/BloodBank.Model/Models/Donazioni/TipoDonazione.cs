using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using BloodBank.Model.Models.Sangue;

namespace BloodBank.Model.Models.Donazioni {

    public sealed class TipoDonazione {

        #region Private Constructor

        private TipoDonazione(string nome, int giorniDiRiposo, IDictionary<ComponenteEmatico, int> componentiDerivati) {
            //Contract.Requires<ArgumentOutOfRangeException>(giorniDiRiposo > 0, "Il parametro " + nameof(giorniDiRiposo) + " deve essere un intero positivo.");
           // Contract.Requires<ArgumentOutOfRangeException>(componentiDerivati.Values.All(quantità => quantità > 0), "Ogni parametro " + nameof(componentiDerivati.Values) + " deve essere un intero positivo.");

            Nome = nome;
            GiorniDiRiposo = giorniDiRiposo;
            _componentiDerivati = new ReadOnlyDictionary<ComponenteEmatico, int>(componentiDerivati);
            ValuesSet.Add(this);
        }

        #endregion Private Constructor

        #region Static Members (Values)

        private static readonly HashSet<TipoDonazione> ValuesSet = new HashSet<TipoDonazione>();
        public static IReadOnlyCollection<TipoDonazione> Values => ValuesSet;

        #endregion Static Members (Values)

        #region Instance Members

        public string Nome { get; }
        public int GiorniDiRiposo { get; }
        private readonly ReadOnlyDictionary<ComponenteEmatico, int> _componentiDerivati;

        #endregion Instance Members

        #region Methods

        public IEnumerable<ComponenteEmatico> ComponentiDerivati => _componentiDerivati.Keys;

        public int QuantitàComponente(ComponenteEmatico componente) => _componentiDerivati[componente];

        #endregion Methods

        #region Public Static Instances

        public static readonly TipoDonazione SangueIntero = new TipoDonazione("Sangue Intero", 90, new Dictionary<ComponenteEmatico, int>
            {
                {ComponenteEmatico.GlobuliRossi, 1},
                {ComponenteEmatico.Plasma, 1},
                {ComponenteEmatico.Piastrine, 1}
            });

        public static readonly TipoDonazione Plasmaferesi = new TipoDonazione("Plasmaferesi", 14, new Dictionary<ComponenteEmatico, int>
            {
                {ComponenteEmatico.Plasma, 2}
            });

        public static readonly TipoDonazione Piastrinoaferesi = new TipoDonazione("Piastrinoaferesi", 30, new Dictionary<ComponenteEmatico, int>
            {
                {ComponenteEmatico.Piastrine, 6}
            });

        #endregion Public Static Instances

        public override string ToString() => Nome;
    }
}