using System;
using BloodBank.ViewModel.Services;
using PropertyChanged;
using Stylet;

namespace BloodBank.ViewModel.ViewModels {

    // TODO: FixMe?
    // Shameful hack dovuta al fatto che per qualche ragione la libreria Stylet lancia NullArgumentException a caso quando uno Screen
    // che usa i servizi di validazione offerti dalla libreria stessa è inserito in un TabControl o controllo simile con più figli.

    [ImplementPropertyChanged]
    public class TabWrapperViewModel : Conductor<IScreen> {

        #region Overrides

        protected bool Equals(TabWrapperViewModel other)
        {
            return Equals(ActiveItem, other.ActiveItem);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TabWrapperViewModel) obj);
        }

        public override int GetHashCode()
        {
            return (ActiveItem != null ? ActiveItem.GetHashCode() : 0);
        }

        #endregion

    }
    
}
