using System.Collections.ObjectModel;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public sealed class SaccaSangueMockDataService : MockDataService<SaccaSangue> {

        public SaccaSangue.SaccaSangueFactory SaccaSangueFactory { get; set; }
        
        public SaccaSangueMockDataService() {
            SaccaSangueFactory = new SaccaSangue.SaccaSangueFactory(this);
            _models = new ObservableCollection<object>();
        }
        
    }
}
