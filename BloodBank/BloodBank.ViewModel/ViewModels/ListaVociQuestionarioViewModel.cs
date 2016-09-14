using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Tests;
using Stylet;

namespace BloodBank.ViewModel.ViewModels
{
   public class ListaVociQuestionarioViewModel : ListaVociViewModel<Questionario>
    {
       public ListaVociQuestionarioViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
       {
       }
    }
}
