using System.ComponentModel.DataAnnotations;

// ReSharper disable InconsistentNaming

namespace BloodBank.Model.Models.Sangue {

    public enum GruppoSanguigno {

        [Display(Name = "O Negativo")]
        O_Neg,

        [Display(Name = "O Positivo")]
        O_Pos,

        [Display(Name = "A Negativo")]
        A_Neg,

        [Display(Name = "A Positivo")]
        A_Pos,

        [Display(Name = "B Negativo")]
        B_Neg,

        [Display(Name = "B Positivo")]
        B_Pos,

        [Display(Name = "AB Negativo")]
        AB_Neg,

        [Display(Name = "AB Positivo")]
        AB_Pos
    }
}