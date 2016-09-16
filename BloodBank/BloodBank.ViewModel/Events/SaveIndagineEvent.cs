using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.ViewModel.Events
{
    public class SaveIndagineEvent
    {
        public SaveIndagineEvent(object indagine)
        {
            Indagine = indagine;
        }
        public object Indagine { get; }
    }
}
