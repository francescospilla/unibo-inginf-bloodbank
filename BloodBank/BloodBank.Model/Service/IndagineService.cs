using System.Collections.Generic;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {

    public abstract class IndagineService<U> : DataService<Indagine<U>> where U : ListaVoci {
        protected IndagineService(IList<Indagine<U>> items) : base(items) {
        }
    }

    public class IndagineQuestionarioService : IndagineService<Questionario> {
        private static readonly IList<Indagine<Questionario>> Items = new List<Indagine<Questionario>>()
        {
            new IndagineBoolean<Questionario>("Domanda 1", Idoneità.NonIdoneo, true),
            new IndagineBoolean<Questionario>("Domanda 2", Idoneità.Idoneo, true),
            new IndagineBoolean<Questionario>("Domanda 3", Idoneità.Sospeso, false),
            new IndagineRange<Questionario, int>("Domanda 4", Idoneità.NonIdoneo, 0, 10),
            new IndagineBoolean<Questionario>("Domanda 5", Idoneità.NonIdoneo, true),
            new IndagineRange<Questionario, int>("Domanda 6", Idoneità.NonIdoneo, 0, 10),
            new IndagineBoolean<Questionario>("Domanda 7", Idoneità.Idoneo, true),
            new IndagineBoolean<Questionario>("Domanda 8", Idoneità.Sospeso, false),
            new IndagineBoolean<Questionario>("Domanda 9", Idoneità.NonIdoneo, true),
            new IndagineRange<Questionario, int>("Domanda 10", Idoneità.NonIdoneo, 0, 10),
        };

        public IndagineQuestionarioService() : base(Items) {
        }
    }

    public class IndagineAnalisiService : IndagineService<Analisi> {
        private static readonly IList<Indagine<Analisi>> Items = new List<Indagine<Analisi>>()
        {
            new IndagineBoolean<Analisi>("Esame 1", Idoneità.NonIdoneo, true),
            new IndagineBoolean<Analisi>("Esame 2", Idoneità.Idoneo, true),
            new IndagineBoolean<Analisi>("Esame 3", Idoneità.Sospeso, false),
            new IndagineRange<Analisi, int>("Esame 4", Idoneità.NonIdoneo, 0, 10),
            new IndagineBoolean<Analisi>("Esame 5", Idoneità.NonIdoneo, true),
            new IndagineRange<Analisi, int>("Esame 6", Idoneità.NonIdoneo, 0, 10),
            new IndagineBoolean<Analisi>("Esame 7", Idoneità.Idoneo, true),
        };

        public IndagineAnalisiService() : base(Items) {
        }
    }

}