using System.Collections.ObjectModel;
using BloodBank.Model.Models.Sangue;

namespace BloodBank.Mock.Sangue
{
    public sealed class SaccaSangueMockDataService : MockDataService<SaccaSangue> {
        
        public SaccaSangueMockDataService() {
            _models = new ObservableCollection<object>();
        }
        
    }
}
