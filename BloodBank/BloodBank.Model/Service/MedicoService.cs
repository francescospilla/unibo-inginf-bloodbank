using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Persone;

namespace BloodBank.Model.Service
{
    public class MedicoService : DataService<Medico>
    {

        private static readonly IList<Medico> Items = new List<Medico>()
        {
            new Medico(
                new Contatto("Marta", "Cafiero", Sesso.Femmina, new DateTime(1971, 12, 24), "DLCSRN36T14A704A",
                    "Via Capo di Monte, 33", "Bologna", "Italia", "12345")),
            new Medico(
                new Contatto("Marco", "Rossi", Sesso.Maschio, new DateTime(1994, 06, 12), "NIUYTG69C71H501J",
                    "Sotto a un ponte", "Bologna", "Italia", "12341")),
            new Medico(
                new Contatto("Sara", "Paoli", Sesso.Femmina, new DateTime(1994, 06, 12), "ZVRVSZ41L41H679X",
                    "Sotto a un ponte", "Bologna", "Italia", "12341")),
            new Medico(
                new Contatto("Nicola", "Bianchi", Sesso.Maschio, new DateTime(1994, 06, 12), "BMONRJ71B06L229S",
                    "Sotto a un ponte", "Bologna", "Italia", "12341") ),
            new Medico(
                new Contatto("Gino", "Verdi", Sesso.Maschio, new DateTime(1994, 06, 12), "JLDHDW45C14S951E",
                    "Sotto a un ponte", "Bologna", "Italia", "12341")),
        };

        public MedicoService(IList<Medico> models) : base(Items)
        {
        }
    }
}
