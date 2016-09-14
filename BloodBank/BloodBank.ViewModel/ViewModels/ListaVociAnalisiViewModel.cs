using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
   public class ListaVociAnalisiViewModel : ListaVociViewModel<Analisi>
    {
       public ListaVociAnalisiViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
       {
       }
    }
}
