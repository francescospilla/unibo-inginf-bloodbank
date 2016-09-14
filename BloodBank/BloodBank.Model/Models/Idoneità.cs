using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BloodBank.Model.Models {

    public enum Idoneità {
        Idoneo = 0,
        Sospeso = 1,

        [Display(Name = "Non idoneo")]
        NonIdoneo = 2
    }

    public static class IdoneitàHelper {

        public static Idoneità CalculateIdoneitàFromList(this IEnumerable<Idoneità> lista) {
            return lista.Max();
        }
    }
}