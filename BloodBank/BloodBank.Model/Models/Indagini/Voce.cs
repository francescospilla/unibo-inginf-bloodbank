using System;
using BloodBank.Model.Models.Tests;
using PropertyChanged;

namespace BloodBank.Model.Models.Indagini
{

    public abstract class Voce
    {
        public abstract Idoneit‡ Idoneit‡ { get; }
        public abstract string TestoIndagine { get; }
        public abstract string TestoRisultato { get; }
    }

    public abstract class Voce<U> : Voce where U : ListaVoci
    { }

    [ImplementPropertyChanged] public class Voce<U, T> : Voce<U> where T : IComparable<T> where U : ListaVoci
    {

        public Voce(Indagine<U, T> indagine, T risultato)
        {
            Indagine = indagine;
            Risultato = risultato;
            Idoneit‡ = Indagine.GetIdoneit‡FromRisultato(risultato);
        }

        private Indagine<U, T> Indagine { get; }
        private T Risultato { get; }

        public override Idoneit‡ Idoneit‡ { get; }
        public override string TestoIndagine => Indagine.Testo;
        public override string TestoRisultato => Risultato.ToString();

        public override string ToString()
        {
            return "Voce: " + TestoIndagine + ", Risultato: " + TestoRisultato;
        }
    }
}