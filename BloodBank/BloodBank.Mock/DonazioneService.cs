using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Service;
using static BloodBank.Mock.DonatoreService;
using static BloodBank.Mock.ListaVociAnalisiService;
using static BloodBank.Mock.ListaVociQuestionarioService;
using static BloodBank.Mock.VisitaMedicaService;
using static BloodBank.Model.Models.Donazioni.TipoDonazione;

namespace BloodBank.Mock
{
    public class DonazioneService : DataService<Donazione>
    {
        // internal static Donazione Donazione1 = new Donazione(D1, Piastrinoaferesi, DateTime.Now.AddMinutes(-1), V1, A1, Q1);
        internal static Donazione Donazione2 = new Donazione(D2, SangueIntero, new DateTime(2016, 08, 23, 12, 00, 00), V2, A2, Q2);
        internal static Donazione Donazione3 = new Donazione(D3, Plasmaferesi, new DateTime(2016, 05, 15, 18, 30, 00), V3, A3, Q3);
        internal static Donazione Donazione4 = new Donazione(D4, SangueIntero, new DateTime(2016, 07, 02, 15, 45, 00), V4, A4, Q4);

        private static readonly IList<Donazione> Items = new List<Donazione>()
        {
            /*Donazione1,*/ Donazione2, Donazione3, Donazione4
        };

        public DonazioneService() : base(Items.OrderBy(donazione => donazione.Data).ToList())
        {
        }
    }
}
