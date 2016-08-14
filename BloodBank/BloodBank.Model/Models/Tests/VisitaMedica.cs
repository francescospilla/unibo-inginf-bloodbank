using BloodBank.Model.Donatori;
using System;

namespace BloodBank.Model.Tests {

    public class VisitaMedica : Test {

        public VisitaMedica(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità)
            : base(donatore, data, descrizioneBreve) {
            Idoneità = idoneità;
        }

        public override Idoneità Idoneità { get; }
    }
}