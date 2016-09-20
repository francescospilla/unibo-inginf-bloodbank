﻿using System;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using static BloodBank.Mock.DonatoreService;
using static BloodBank.Mock.MedicoService;
using static BloodBank.Model.Models.Idoneità;

namespace BloodBank.Mock {
    public class VisitaMedicaService : DataService<VisitaMedica> {
        internal VisitaMedica V1;
        internal VisitaMedica V2;
        internal VisitaMedica V3;
        internal VisitaMedica V4;
        internal VisitaMedica V5;
        internal VisitaMedica V6;
        internal VisitaMedica V7;
        internal VisitaMedica V8;
        internal VisitaMedica V9;
        internal VisitaMedica V10;
        
        public VisitaMedicaService(DonatoreService d, MedicoService m) : base() {
            V1 = new VisitaMedica(d.D1, "Descrizione breve", DateTime.Now.AddMinutes(-2), Idoneo, m.M1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
            V2 = new VisitaMedica(d.D2, "Descrizione brevissima", new DateTime(2016, 08, 23, 11, 30, 10), Idoneo, m.M2, "Lorem ipsum dolor sit amet.");
            V3 = new VisitaMedica(d.D3, "Descrizione corta", new DateTime(2016, 05, 15, 17, 32, 55), Idoneo, m.M3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?");
            V4 = new VisitaMedica(d.D4, "Descrizione breve", new DateTime(2016, 07, 02, 15, 30, 27), Idoneo, m.M5, "Lorem ipsum dolor sit amet.");
            V5 = new VisitaMedica(d.D5, "Descrizione impercettibile", new DateTime(2016, 05, 15, 07, 28, 11), Idoneo, m.M2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?");
            V6 = new VisitaMedica(d.D6, "Descrizione minuscola", new DateTime(2016, 02, 16, 09, 21, 00), NonIdoneo, m.M5, "Lorem ipsum dolor sit amet.");
            V7 = new VisitaMedica(d.D7, "Descrizione breve", new DateTime(2015, 12, 09, 18, 08, 03), NonIdoneo, m.M3, "Va tutto bene.");
            V8 = new VisitaMedica(d.D8, "Descrizione corta", new DateTime(2015, 10, 30, 19, 31, 57), Sospeso, m.M5, "Ma questo non credo.");
            V9 = new VisitaMedica(d.D9, "Descrizione", new DateTime(2016, 09, 17, 16, 08, 52), NonIdoneo, m.M1, "Non credo vada proprio bene così però.");
            V10 = new VisitaMedica(d.D10, "Descrizione superbreve", new DateTime(2016, 04, 13, 14, 37, 43), NonIdoneo, m.M2, "Facciamo che torni un'altra volta.");

            _models = new List<VisitaMedica>() { V1, V2, V3, V4, V5, V6, V7, V8, V9, V10 }.OrderBy(visitaMedica => visitaMedica.Data).ToList();
        }
        
    }
}
