using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using static BloodBank.Mock.DonatoreService;
using static BloodBank.Mock.MedicoService;
using static BloodBank.Model.Models.Idoneità;

namespace BloodBank.Mock
{
    public class VisitaMedicaService : DataService<VisitaMedica>
    {
        internal static VisitaMedica V1 = new VisitaMedica(D1, "Descrizione breve", DateTime.Now.AddHours(-1), Idoneo, M1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
        internal static VisitaMedica V2 = new VisitaMedica(D2, "Descrizione brevissima", new DateTime(2016, 08,23, 10, 11, 10), Idoneo, M2, "Lorem ipsum dolor sit amet.");
        internal static VisitaMedica V3 = new VisitaMedica(D3, "Descrizione corta", new DateTime(2016, 05, 15, 07, 32, 55), Idoneo, M3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?");
        internal static VisitaMedica V4 = new VisitaMedica(D4, "Descrizione breve", new DateTime(2016, 07, 02, 12, 07, 27), Idoneo, M5, "Lorem ipsum dolor sit amet.");
        internal static VisitaMedica V5 = new VisitaMedica(D5, "Descrizione impercettibile", new DateTime(2016, 05, 15, 07, 28, 11), Idoneo, M2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?");
        internal static VisitaMedica V6 = new VisitaMedica(D6, "Descrizione minuscola", new DateTime(2016, 02, 16, 09, 21, 00), NonIdoneo, M5, "Lorem ipsum dolor sit amet.");
        internal static VisitaMedica V7 = new VisitaMedica(D7, "Descrizione breve", new DateTime(2015, 12, 09, 18, 08, 03), NonIdoneo, M3, "Va tutto bene.");
        internal static VisitaMedica V8 = new VisitaMedica(D8, "Descrizione corta", new DateTime(2015, 10, 30, 19, 31, 57), Sospeso, M5, "Ma questo non credo.");
        internal static VisitaMedica V9 = new VisitaMedica(D9, "Descrizione", new DateTime(2016, 09, 17, 16, 08, 52), NonIdoneo, M1, "Non credo vada proprio bene così però.");
        internal static VisitaMedica V10 = new VisitaMedica(D10, "Descrizione superbreve", new DateTime(2016, 04, 13, 14, 37, 43), NonIdoneo, M2, "Facciamo che torni un'altra volta.");

        private static readonly IList<VisitaMedica> Items = new List<VisitaMedica>() { 
            V1, V2, V3, V4, V5, V6, V7, V8, V9, V10
            };
        public VisitaMedicaService() : base(Items)
        {
        }
    }
}
