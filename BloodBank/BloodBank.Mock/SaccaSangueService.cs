using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public class SaccaSangueService : DataService<SaccaSangue> {

        public SaccaSangueFactory SaccaSangueFactory { get; set; }
        
        public SaccaSangueService() : base() {
            SaccaSangueFactory = new SaccaSangueFactory(this);
            _models = new ObservableCollection<SaccaSangue>() {};
        }
        
    }
}
