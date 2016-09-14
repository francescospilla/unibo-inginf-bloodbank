﻿using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Sangue;

namespace BloodBank.Model.Models {

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
                        sacca.Componente.GetCompatibili(sacca.Gruppo).Contains(gruppo)).ToList();
        }
    }
}