using BloodBank.Model.Models.Tests;

namespace BloodBank.ViewModel.Events {
    public class NuovaListaVociEvent<U> where U : ListaVoci {

        public NuovaListaVociEvent(U listaVoci) {
            ListaVoci = listaVoci;
        }

        public U ListaVoci { get; }
    }
}