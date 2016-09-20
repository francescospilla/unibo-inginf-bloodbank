using System.Collections.Generic;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.Model.Models.Indagini;

namespace BloodBank.Mock
{

    public abstract class VoceService<U> : DataService<Voce<U>> where U : ListaVoci
    {
        protected VoceService(IList<Voce<U>> items) : base(items)
        {
        }
    }

    public class VoceQuestionarioService : VoceService<Questionario>
    {
        internal static Voce<Questionario> Vq1 = new Voce<Questionario,bool>(IndagineQuestionarioService.Q1, true);
        internal static Voce<Questionario> Vq2 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q1, false);
        internal static Voce<Questionario> Vq3 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q2, true);
        internal static Voce<Questionario> Vq4 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q2, false);
        internal static Voce<Questionario> Vq5 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q3, true);
        internal static Voce<Questionario> Vq6 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q3, false);
        internal static Voce<Questionario> Vq7 = new Voce<Questionario, int>(IndagineQuestionarioService.Q4, 47);
        internal static Voce<Questionario> Vq8 = new Voce<Questionario, int>(IndagineQuestionarioService.Q4, 80);
        internal static Voce<Questionario> Vq9 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q5, true);
        internal static Voce<Questionario> Vq10 = new Voce<Questionario, bool>(IndagineQuestionarioService.Q5, false);
        internal static Voce<Questionario> Vq11 = new Voce<Questionario, double>(IndagineQuestionarioService.Q6, 5.6);
        internal static Voce<Questionario> Vq12 = new Voce<Questionario, double>(IndagineQuestionarioService.Q6, 15.0);


        private static readonly List<Voce<Questionario>> Items = new List<Voce<Questionario>>()
        {
            Vq1, Vq1, Vq2, Vq3, Vq4, Vq5, Vq6, Vq7, Vq8, Vq9, Vq10, Vq11, Vq12
        };

        public VoceQuestionarioService() : base(Items)
        {
        }
    }

    public class VoceAnalisiService : VoceService<Analisi>
    {

        internal static Voce<Analisi> Va1 = new Voce<Analisi, double>(IndagineAnalisiService.A1, 4.2);
        internal static Voce<Analisi> Va2 = new Voce<Analisi, double>(IndagineAnalisiService.A1, 8.6);
        internal static Voce<Analisi> Va3 = new Voce<Analisi, int>(IndagineAnalisiService.A2, 25);
        internal static Voce<Analisi> Va4 = new Voce<Analisi, int>(IndagineAnalisiService.A2, 46);
        internal static Voce<Analisi> Va5 = new Voce<Analisi, bool>(IndagineAnalisiService.A3, true);
        internal static Voce<Analisi> Va6 = new Voce<Analisi, bool>(IndagineAnalisiService.A3, false);
        internal static Voce<Analisi> Va7 = new Voce<Analisi, bool>(IndagineAnalisiService.A4, true);
        internal static Voce<Analisi> Va8 = new Voce<Analisi, bool>(IndagineAnalisiService.A4, false);
        internal static Voce<Analisi> Va9 = new Voce<Analisi, bool>(IndagineAnalisiService.A5, true);
        internal static Voce<Analisi> Va10 = new Voce<Analisi, bool>(IndagineAnalisiService.A5, false);
        internal static Voce<Analisi> Va11 = new Voce<Analisi, bool>(IndagineAnalisiService.A6, true);
        internal static Voce<Analisi> Va12 = new Voce<Analisi, bool>(IndagineAnalisiService.A6, false);


        private static readonly List<Voce<Analisi>> Items = new List<Voce<Analisi>>()
        {
            Va1, Va2, Va3, Va4, Va5, Va6, Va7, Va8, Va9, Va10, Va11, Va12
        };

        public VoceAnalisiService() : base(Items)
        {
        }
    }
}
