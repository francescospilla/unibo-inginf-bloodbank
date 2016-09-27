using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Core.Extensions;

namespace BloodBank.Model.Models.Sangue {

    public sealed class ComponenteEmatico {

        #region Private Constructor

        private ComponenteEmatico(string nome, int durataGiorni,
            Dictionary<GruppoSanguigno, IReadOnlyCollection<GruppoSanguigno>> compatibilità) {

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException(nameof(nome));
            if (durataGiorni <= 0)
                throw new ArgumentOutOfRangeException("Il parametro " + nameof(durataGiorni) + " deve essere un intero positivo.");
            if (compatibilità != null && !compatibilità.Keys.Any())
                throw new ArgumentException("Il dizionario della compatibilità, se non null, deve essere non vuoto");
            if (compatibilità != null && EnumExtensions.Values<GruppoSanguigno>().Except(compatibilità.Keys).Any())
                throw new ArgumentException("Il dizionario della compatibilità, se non null, deve contenere come chiavi tutti i GruppiSanguigni.");

            Nome = nome;
            DurataGiorni = durataGiorni;
            _compatibilità = compatibilità;
            ValuesSet.Add(this);
        }

        #endregion Private Constructor

        #region Static Members (Values)

        private static readonly HashSet<ComponenteEmatico> ValuesSet = new HashSet<ComponenteEmatico>();
        public static IReadOnlyCollection<ComponenteEmatico> Values => ValuesSet;

        #endregion Static Members (Values)

        #region Instance Members

        public string Nome { get; }
        private int DurataGiorni { get; }
        private readonly Dictionary<GruppoSanguigno, IReadOnlyCollection<GruppoSanguigno>> _compatibilità;

        #endregion Instance Members

        #region Methods

        public DateTime CalculateDataScadenza(DateTime dataAcquisizione) => dataAcquisizione.AddDays(DurataGiorni);

        public IReadOnlyCollection<GruppoSanguigno> GetCompatibili(GruppoSanguigno gruppo)
            =>
                _compatibilità != null
                    ? _compatibilità[gruppo]
                    : Enum.GetValues(typeof(GruppoSanguigno)).Cast<GruppoSanguigno>().ToArray();

        public override string ToString() => Nome;

        #endregion Methods

        #region Public Static Instances

        public static readonly ComponenteEmatico GlobuliRossi = new ComponenteEmatico("Globuli Rossi", 30,
            new Dictionary<GruppoSanguigno, IReadOnlyCollection<GruppoSanguigno>>
            {
                {
                    GruppoSanguigno.O_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg
                    }
                },
                {
                    GruppoSanguigno.O_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.O_Pos
                    }
                },
                {
                    GruppoSanguigno.A_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.A_Neg
                    }
                },
                {
                    GruppoSanguigno.A_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.O_Pos,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.A_Pos
                    }
                },
                {
                    GruppoSanguigno.B_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.B_Neg
                    }
                },
                {
                    GruppoSanguigno.B_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.O_Pos,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.B_Pos
                    }
                },
                {
                    GruppoSanguigno.AB_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.AB_Neg
                    }
                },
                {
                    GruppoSanguigno.AB_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.O_Pos,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.A_Pos,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.B_Pos,
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos
                    }
                }
            });

        public static readonly ComponenteEmatico Plasma = new ComponenteEmatico("Plasma", 60,
            new Dictionary<GruppoSanguigno, IReadOnlyCollection<GruppoSanguigno>>
            {
                {
                    GruppoSanguigno.AB_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos
                    }
                },
                {
                    GruppoSanguigno.AB_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos
                    }
                },
                {
                    GruppoSanguigno.A_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.A_Pos
                    }
                },
                {
                    GruppoSanguigno.A_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.A_Pos
                    }
                },
                {
                    GruppoSanguigno.B_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.B_Pos
                    }
                },
                {
                    GruppoSanguigno.B_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.B_Pos
                    }
                },
                {
                    GruppoSanguigno.O_Neg,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.A_Pos,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.B_Pos,
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.O_Pos
                    }
                },
                {
                    GruppoSanguigno.O_Pos,
                   new HashSet<GruppoSanguigno>
                    {
                        GruppoSanguigno.AB_Neg,
                        GruppoSanguigno.AB_Pos,
                        GruppoSanguigno.A_Neg,
                        GruppoSanguigno.A_Pos,
                        GruppoSanguigno.B_Neg,
                        GruppoSanguigno.B_Pos,
                        GruppoSanguigno.O_Neg,
                        GruppoSanguigno.O_Pos
                    }
                }
            });

        public static readonly ComponenteEmatico Piastrine = new ComponenteEmatico("Piastrine", 72, null);

        #endregion Public Static Instances
    }
}