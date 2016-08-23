using System;
using BloodBank.Model.Models.Donatori;

namespace BloodBank.Model.Models.Tests {

    public class VisitaMedica : Test {

        public VisitaMedica(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, string nomeMedico)
            : base(donatore, data, descrizioneBreve) {
            Idoneità = idoneità;
            _nomeMedico = nomeMedico;
            }

        public override Idoneità Idoneità { get; }
        public string _nomeMedico { get; }
    }
}