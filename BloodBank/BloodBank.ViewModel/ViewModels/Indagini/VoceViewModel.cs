using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels.Indagini {

    public abstract class VoceViewModel<U> : Screen where U : ListaVoci {
        
    }

    [ImplementPropertyChanged]
    public abstract class VoceViewModel<U, T> : VoceViewModel<U> where T : struct, IComparable<T> where U : ListaVoci {

        #region Constructor

        protected VoceViewModel(Indagine<U, T> indagine) {
            Indagine = indagine;
        }

        #endregion

        #region Properties

        public Indagine<U, T> Indagine { get; set; }
        public T? Risultato { get; set; }

        #endregion

        public abstract IEnumerable<T> RisultatoEnumerable { get; }


    }


    #region Voce???ViewModel<U> where U : ListaVoci

    public class VoceBooleanViewModel<U> : VoceViewModel<U, bool> where U : ListaVoci
    {
        public VoceBooleanViewModel(IndagineBoolean<U> indagine) : base(indagine)
        {
        }
        
        public override IEnumerable<bool> RisultatoEnumerable => new [] { true, false };
        
    }

    public class VoceRangeIntViewModel<U> : VoceViewModel<U, int> where U : ListaVoci {
        public VoceRangeIntViewModel(IndagineRange<U, int> indagine) : base(indagine)
        {
        }

        public override IEnumerable<int> RisultatoEnumerable =>  Enumerable.Range(-1000, 2001).ToList();

    }

    public class VoceRangeDoubleViewModel<U> : VoceViewModel<U, double> where U : ListaVoci {
        public VoceRangeDoubleViewModel(IndagineRange<U, double> indagine) : base(indagine) {
        }

        public override IEnumerable<double> RisultatoEnumerable {
            get {
                List<double> lista = Enumerable.Range(-10000, 20001).Select(i => (double)i / 10).ToList();
                lista.Insert(0, double.NegativeInfinity);
                lista.Add(double.PositiveInfinity);
                return lista;
            }
        }

    }

    #endregion

    public class VoceBooleanQuestionarioViewModel : VoceBooleanViewModel<Questionario> {
        public VoceBooleanQuestionarioViewModel(IndagineBoolean<Questionario> indagine) : base(indagine)
        {
        }
    }

    public class VoceBooleanAnalisiViewModel : VoceBooleanViewModel<Analisi> {
        public VoceBooleanAnalisiViewModel(IndagineBoolean<Analisi> indagine) : base(indagine) {
        }
    }

    public class VoceRangeIntQuestionarioViewModel : VoceRangeIntViewModel<Questionario> {
        public VoceRangeIntQuestionarioViewModel(IndagineRange<Questionario, int> indagine) : base(indagine)
        {
        }
    }

    public class VoceRangeIntAnalisiViewModel : VoceRangeIntViewModel<Analisi> {
        public VoceRangeIntAnalisiViewModel(IndagineRange<Analisi, int> indagine) : base(indagine) {
        }
    }


}
