using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Donazioni;

namespace BloodBank.ViewModel.Events
{
    public class NuovaDonazioneEvent
    {
        public NuovaDonazioneEvent(Donazione donazione)
        {
            Donazione = donazione;
        }
        public Donazione Donazione { get; }
    }
}
