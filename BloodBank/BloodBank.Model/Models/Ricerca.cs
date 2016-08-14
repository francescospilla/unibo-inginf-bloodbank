using BloodBank.Model.Sangue;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank.Model {

    public static class Ricerca {

        public static IReadOnlyList<SaccaSangue> CercaSaccaSangueCompatibili(this SaccaSangue sacca,
            IReadOnlyList<SaccaSangue> listaSacche) {
            return CercaSaccaSangueCompatibili(listaSacche, sacca.Componente, sacca.Gruppo);
        }

        public static IReadOnlyList<SaccaSangue> CercaSaccaSangueCompatibili(IReadOnlyList<SaccaSangue> listaSacche, ComponenteEmatico componente, GruppoSanguigno gruppo) {
            return
                listaSacche.Where(
                    sacca =>
                        sacca.Disponibile && sacca.Componente == componente &&
                        sacca.Componente.GetCompatibili(sacca.Gruppo).Contains(gruppo) && sacca.QuantitàFrazionaria == 1).ToList();
        }
    }
}