﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank.Model.Sangue {
    public sealed class ComponenteEmatico {
        #region Private Constructor

        private ComponenteEmatico(string nome, int durataGiorni,
            Dictionary<GruppoSanguigno, IReadOnlyCollection<GruppoSanguigno>> compatibilità) {
            Nome = nome;
            DurataGiorni = durataGiorni;
            _compatibilità = compatibilità;
            ValuesSet.Add(this);
        }

        #endregion

        #region Static Members (Values)

        private static readonly HashSet<ComponenteEmatico> ValuesSet = new HashSet<ComponenteEmatico>();
        public static IReadOnlyCollection<ComponenteEmatico> Values => ValuesSet;

        #endregion

        #region Instance Members

        public string Nome { get; }
        private int DurataGiorni { get; }
        private readonly Dictionary<GruppoSanguigno, IReadOnlyCollection<GruppoSanguigno>> _compatibilità;

        #endregion

        #region Methods

        public DateTime CalculateDataScadenza(DateTime dataAcquisizione) => dataAcquisizione.AddDays(DurataGiorni);

        public IReadOnlyCollection<GruppoSanguigno> GetCompatibili(GruppoSanguigno gruppo)
            =>
                _compatibilità != null
                    ? _compatibilità[gruppo]
                    : Enum.GetValues(typeof(GruppoSanguigno)).Cast<GruppoSanguigno>().ToArray();

        public override string ToString() => Nome;

        #endregion

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

        #endregion
    }
}