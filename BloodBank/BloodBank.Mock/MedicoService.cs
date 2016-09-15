﻿using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{
    public class MedicoService : DataService<Medico>
    {
        internal static Medico M1 = new Medico(
            new Contatto("Rita", "Colombo", Sesso.Femmina, new DateTime(1971, 12, 24), "DLCSRN36T14A704A",
                "Via Capo di Monte, 33", "Bologna", "Italia", "12345"));

        internal static Medico M2 = new Medico(
            new Contatto("Marco", "Rossi", Sesso.Maschio, new DateTime(1981, 09, 04), "NIUYTG69C71H501J",
                "Sotto a un ponte", "Bologna", "Italia", "12341"));

        internal static Medico M3 = new Medico(
            new Contatto("Sara", "Rizzo", Sesso.Femmina, new DateTime(1976, 11, 23), "ZVRVSZ41L41H679X",
                "Sotto a un ponte", "Bologna", "Italia", "12341"));

        internal static Medico M4 = new Medico(
            new Contatto("Nicola", "Bianchi", Sesso.Maschio, new DateTime(1966, 04, 01), "BMONRJ71B06L229S",
                "Sotto a un ponte", "Bologna", "Italia", "12341"));

        internal static Medico M5 = new Medico(
            new Contatto("Renzo", "Verdi", Sesso.Maschio, new DateTime(1960, 08, 12), "JLDHDW45C14S951E",
                "Sotto a un ponte", "Bologna", "Italia", "12341"));

        private static readonly IList<Medico> Items = new List<Medico>()
        {
            M1, M2, M3, M4, M5
        };

        public MedicoService(IList<Medico> models) : base(Items)
        {
        }
    }
}