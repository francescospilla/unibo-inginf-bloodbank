﻿using System;
using BloodBank.Model.Models.Persone;
using PropertyChanged;

namespace BloodBank.Model.Models.Tests
{

    [ImplementPropertyChanged]
    public class VisitaMedica : Test
    {

        public VisitaMedica(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, Medico medico, string referto)
            : base(donatore, data, descrizioneBreve)
        {
            Idoneità = idoneità;
            Medico = medico;
            Referto = referto;
        }

        public override Idoneità Idoneità { get; }
        public Medico Medico { get; }
        public string Referto { get; set; }
    }
}