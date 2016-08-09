using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stylet;

namespace BloodBank.ViewModel {

    public interface IViewModel<TModel> : IScreen {
        TModel Model { get; }
        bool IsInitialized { get; }
    }
}
