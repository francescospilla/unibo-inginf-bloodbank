using System;
using System.Linq;
using BloodBank.Model.Donatori;

namespace BloodBank.Model.Tests
{
    public abstract class Test
    {
        protected Test(Donatore donatore, DateTime data, string descrizioneBreve)
        {
            if (donatore.Idoneità == Idoneità.NonIdoneo)
                throw new ArgumentException("Non si può effettuare il test se il donatore è " + Idoneità.NonIdoneo);

            if (data <= donatore.ListaTest.LastOrDefault()?.Data)
                throw new ArgumentException("Sono già presenti test successivi a questa data");

            DescrizioneBreve = descrizioneBreve;
            Data = data;
            Donatore = donatore;
        }

        public Donatore Donatore { get; }
        public string DescrizioneBreve { get; }
        public DateTime Data { get; }
        public abstract Idoneità Idoneità { get; }

        protected bool Equals(Test other)
        {
            return Equals(Donatore, other.Donatore) && string.Equals(DescrizioneBreve, other.DescrizioneBreve) && Data.Equals(other.Data);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            Test other = obj as Test;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Donatore?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (DescrizioneBreve?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ Data.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return "Donatore: " + Donatore + ", Data: " + Data + ", " + DescrizioneBreve;
        }
    }
}