using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    public class IndaginiQuestionarioViewModel : IndaginiViewModel<Questionario, bool> {
        public IndaginiQuestionarioViewModel(IEventAggregator eventAggregator, IDataService<Indagine<Questionario>> dataService) : base(eventAggregator, dataService) {
        }
    }
}
