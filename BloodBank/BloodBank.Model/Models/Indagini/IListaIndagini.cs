using System;
using System.Collections.Generic;

namespace BloodBank.Model.Indagini {
    public interface IListaIndagini {
        DateTime DataCreazione { get; }
        DateTime DataUltimaModifica { get; }
        IEnumerable<Indagine> Indagini { get; }
        string Nome { get; set; }
    }
}