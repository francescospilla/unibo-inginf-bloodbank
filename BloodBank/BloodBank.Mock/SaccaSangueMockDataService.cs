using System.Collections.ObjectModel;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public sealed class SaccaSangueMockDataService : MockDataService<SaccaSangue> {
        
        public SaccaSangueMockDataService() {
            _models = new ObservableCollection<object>();
        }
        
    }
}
