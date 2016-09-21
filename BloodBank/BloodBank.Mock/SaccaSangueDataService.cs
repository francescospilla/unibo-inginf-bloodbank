using System.Collections.ObjectModel;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public sealed class SaccaSangueDataService : DataService<SaccaSangue> {

        public SaccaSangue.SaccaSangueFactory SaccaSangueFactory { get; set; }
        
        public SaccaSangueDataService() {
            SaccaSangueFactory = new SaccaSangue.SaccaSangueFactory(this);
            _models = new ObservableCollection<object>();
        }
        
    }
}
