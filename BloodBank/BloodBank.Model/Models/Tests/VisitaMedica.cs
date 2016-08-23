﻿using System;
using BloodBank.Model.Models.Persone;

namespace BloodBank.Model.Models.Tests {

    public class VisitaMedica : Test {

        public VisitaMedica(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, Medico medico)
            : base(donatore, data, descrizioneBreve) {
            Idoneità = idoneità;
            Medico = medico;
            }

        public override Idoneità Idoneità { get; }
        public Medico Medico { get; }
    }
}