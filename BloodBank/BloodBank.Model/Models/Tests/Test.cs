using System;
using BloodBank.Model.Models.Persone;

namespace BloodBank.Model.Models.Tests {

    public abstract class Test {

        protected Test(Donatore donatore, DateTime data, string descrizioneBreve) {
            if (donatore.Idoneità == Idoneità.NonIdoneo)
                throw new ArgumentException("Non si può effettuare il test se il donatore è " + Idoneità.NonIdoneo);
            
            DescrizioneBreve = descrizioneBreve;
            Data = data;
            Donatore = donatore;

            Donatore.AggiungiTest(this);
        }

        public Donatore Donatore { get; }
        public string DescrizioneBreve { get; }
        public DateTime Data { get; }
        public abstract Idoneità Idoneità { get; }

        protected bool Equals(Test other) {
            return Equals(Donatore, other.Donatore) && string.Equals(DescrizioneBreve, other.DescrizioneBreve) && Data.Equals(other.Data);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            Test other = obj as Test;
            return other != null && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = Donatore?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (DescrizioneBreve?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ Data.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() {
            return "Donatore: " + Donatore + ", Data: " + Data + ", " + DescrizioneBreve;
        }
    }
}