﻿using System;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;
using PropertyChanged;

namespace BloodBank.Model.Models.Tests
{

    [ImplementPropertyChanged]
    public class VisitaMedica : Test
    {

        private VisitaMedica(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, Medico medico, string referto)
            : base(donatore, data, descrizioneBreve)
        {
            if (medico == null || string.IsNullOrWhiteSpace(referto))
                throw new ArgumentException("Almeno un parametro non-opzionale del costruttore è null o vuoto.");

            Idoneità = idoneità;
            Medico = medico;
            Referto = referto;
        }

        public override Idoneità Idoneità { get; }
        public Medico Medico { get; }
        public string Referto { get; }

        public class VisitaMedicaFactory : IVisitaMedicaFactory {
            private readonly IDataService<VisitaMedica> _dataService;

            public VisitaMedicaFactory(IDataService<VisitaMedica> dataService) {
                _dataService = dataService;
            }

            public VisitaMedica CreateModel(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, Medico medico, string referto) {
                var model = new VisitaMedica(donatore, descrizioneBreve, data, idoneità, medico, referto);
                donatore.AggiungiTest(model);
                _dataService.AddModel(model);
                return model;
            }
        }
    }
}