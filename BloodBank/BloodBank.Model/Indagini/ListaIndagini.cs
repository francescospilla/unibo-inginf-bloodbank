using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Tests;

namespace BloodBank.Model.Indagini {

    public abstract class ListaIndagini : IEnumerable<Indagine>, IListaIndagini {
        private readonly List<Indagine> _indagini;

        protected ListaIndagini(string nome = null) {
            Nome = nome;
            _indagini = new List<Indagine>();
            DataCreazione = DateTime.Now;
            DataUltimaModifica = DataCreazione;
        }

        public IEnumerable<Indagine> Indagini {
            get { return _indagini; }
        }

        public string Nome { get; set; }
        public DateTime DataCreazione { get; }
        public DateTime DataUltimaModifica { get; private set; }

        public bool Add(Indagine obj) {
            if (Indagini.Contains(obj))
                return false;

            _indagini.Add(obj);
            DataUltimaModifica = DateTime.Now;
            return true;
        }

        public bool AddRange(IEnumerable<Indagine> objs) {
            IEnumerable<Indagine> indagini = objs as IList<Indagine> ?? objs.ToList();

            if (indagini.All(obj => Indagini.Contains(obj)))
                return false;

            _indagini.AddRange(indagini);
            DataUltimaModifica = DateTime.Now;
            return true;
        }

        public bool Remove(Indagine obj) {
            if (!_indagini.Remove(obj))
                return false;

            DataUltimaModifica = DateTime.Now;
            return true;
        }

        public void Clear() {
            _indagini.Clear();
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

        public ListaIndagini(string nome = null) : base(nome) {
        }
    }

}