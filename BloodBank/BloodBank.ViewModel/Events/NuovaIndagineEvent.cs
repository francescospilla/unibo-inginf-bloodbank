using BloodBank.Model.Models.Indagini;

namespace BloodBank.ViewModel.Events
{
    public class NuovaIndagineEvent
    {
        public NuovaIndagineEvent(Indagine indagine)
        {
            Indagine = indagine;
        }
        public Indagine Indagine { get; }
    }
}
