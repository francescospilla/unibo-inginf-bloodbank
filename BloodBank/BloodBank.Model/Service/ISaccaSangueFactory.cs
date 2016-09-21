using System;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Sangue;

namespace BloodBank.Model.Service {
    public interface ISaccaSangueFactory {
        SaccaSangue CreateModel(Donazione donazione, GruppoSanguigno gruppo, ComponenteEmatico componente, DateTime dataPrelievo);
    }
}