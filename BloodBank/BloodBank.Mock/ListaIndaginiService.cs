using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using static BloodBank.Mock.IndagineAnalisiService;
using static BloodBank.Mock.IndagineQuestionarioService;

namespace BloodBank.Mock
{

    public abstract class ListaIndaginiService<U> : DataService<ListaIndagini<U>> where U : ListaVoci
    {

        protected ListaIndaginiService(IList<ListaIndagini<U>> items) : base(items)
        {
        }
    }

    // Lista di indagini (Analisi) Lia = lista indagini analisi
    public class ListaIndaginiAnalisiService : ListaIndaginiService<Analisi>
    {
        internal static ListaIndagini<Analisi> Lia1 = new ListaIndagini<Analisi>("Analisi parziali 1")
        {
            A1, A2, A3, A4
        };
        internal static ListaIndagini<Analisi> Lia2 = new ListaIndagini<Analisi>("Analisi complete")
        {
            A1, A2, A3, A4, A5
        };
        internal static ListaIndagini<Analisi> Lia3 = new ListaIndagini<Analisi>("Analisi parziali 1")
        {
            A1, A2
        };

        private static readonly IList<ListaIndagini<Analisi>> Items = new List<ListaIndagini<Analisi>>()
        {
            Lia1, Lia2, Lia3
        };

        public ListaIndaginiAnalisiService() : base(Items)
        {
        }
    }

    // Lista di indagini (Questionario) Liq = lista indagini questionario
    public class ListaIndaginiQuestionarioService : ListaIndaginiService<Questionario>
    {
        internal static ListaIndagini<Questionario> Liq1 = new ListaIndagini<Questionario>("Questionario Parziale 1")
        {
            Q1, Q2, Q3, Q4, Q5, Q6, Q7,Q8
        };
        internal static ListaIndagini<Questionario> Liq2 = new ListaIndagini<Questionario>("Questionario Parziale 2")
        {
            Q9, Q10, Q11, Q12
        };
        internal static ListaIndagini<Questionario> Liq3 = new ListaIndagini<Questionario>("Questionario Completo")
        {
            Q1, Q2, Q3, Q4, Q5, Q6, Q7,Q8, Q9, Q10, Q11, Q12
        };
        internal static ListaIndagini<Questionario> Liq4 = new ListaIndagini<Questionario>("Questionario Parziale 3")
        {
            Q1, Q2, Q3, Q4, Q5, Q6, Q7,Q8
        };
        internal static ListaIndagini<Questionario> Liq5 = new ListaIndagini<Questionario>("Questionario Parziale 4")
        {
            Q1, Q2, Q4, Q6, Q8
        };

        private static readonly IList<ListaIndagini<Questionario>> Items = new List<ListaIndagini<Questionario>>()
        {
            Liq1, Liq2, Liq3, Liq4, Liq5
        };

        public ListaIndaginiQuestionarioService() : base(Items)
        {
        }
    }
}