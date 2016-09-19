using BloodBank.Model.Models.Tests;

namespace BloodBank.ViewModel.Events {
    public class NuovaListaVociEvent<U> where U : ListaVoci {

        public NuovaListaVociEvent(ListaVoci<U> listaVoci) {
            ListaVoci = listaVoci;
        }

        public ListaVoci<U> ListaVoci { get; }
    }
}