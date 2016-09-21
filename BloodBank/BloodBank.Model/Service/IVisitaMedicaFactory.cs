using System;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {
    public interface IVisitaMedicaFactory {
        VisitaMedica CreateModel(Donatore donatore, string descrizioneBreve, DateTime data, Idoneità idoneità, Medico medico, string referto);
    }
}