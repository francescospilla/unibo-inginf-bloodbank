using BloodBank.Model.Sangue;

namespace BloodBank.Model.Donatori {

    public interface IDonatore : IContatto {
        GruppoSanguigno GruppoSanguigno { get; }
        Idoneità? Idoneità { get; }
        bool Attivo { get; }
    }
}