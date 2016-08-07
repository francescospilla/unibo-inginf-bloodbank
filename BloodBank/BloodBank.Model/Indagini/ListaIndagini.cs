using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Tests;

namespace BloodBank.Model.Indagini {

    public abstract class ListaIndagini : IEnumerable<Indagine> {

        public List<Indagine> Indagini { get; }

        protected ListaIndagini(string nome) {
            Nome = nome;
            Indagini = new List<Indagine>();
            DataCreazione = DateTime.Now;
            DataUltimaModifica = DataCreazione;
        }

        public string Nome { get; set; }
        public DateTime DataCreazione { get; }
        public DateTime DataUltimaModifica { get; private set; }

        public bool Add(Indagine obj) {
            if (Indagini.Contains(obj))
                return false;

            Indagini.Add(obj);
            DataUltimaModifica = DateTime.Now;
            return true;
        }

        public bool AddRange(IEnumerable<Indagine> objs) {
            IEnumerable<Indagine> indagini = objs as IList<Indagine> ?? objs.ToList();

            if (indagini.All(obj => Indagini.Contains(obj)))
                return false;

            Indagini.AddRange(indagini);
            DataUltimaModifica = DateTime.Now;
            return true;
        }

        public bool Remove(Indagine obj) {
            if (!Indagini.Remove(obj))
                return false;

            DataUltimaModifica = DateTime.Now;
            return true;
        }

        public void Clear() {
            Indagini.Clear();
            DataUltimaModifica = DateTime.Now;
        }


        public IEnumerator<Indagine> GetEnumerator() => Indagini.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Indagini.GetEnumerator();

        protected bool Equals(ListaIndagini other) {
            return Indagini.Equals(other.Indagini);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ListaIndagini)obj);
        }

        public override int GetHashCode() {
            return Indagini.GetHashCode();
        }

        public override string ToString() {
            return Nome;
        }
    }

    public class ListaIndagini<T> : ListaIndagini where T : ListaVoci {
        public Type Tipo { get; } = typeof(T);

        public ListaIndagini(string nome) : base(nome) {
        }
    }

}