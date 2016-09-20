using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public class SaccaSangueService : DataService<SaccaSangue> {
        
        public SaccaSangueService() : base() {
            _models = new List<SaccaSangue>() {};
        }
        
    }
}
