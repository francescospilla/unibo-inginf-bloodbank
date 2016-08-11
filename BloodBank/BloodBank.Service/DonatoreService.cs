using System;
using System.Collections.Generic;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;

namespace BloodBank.Model.Service {
    public class DonatoreService : DataService<Donatore> {
        private static readonly IList<Donatore> Items = new List<Donatore>() {
                new Donatore(new Contatto("Pasquale", "Cafiero", Sesso.Maschio, new DateTime(1971, 12, 24), "DQCSRN36T14A704A", "Via Capo di Monte, 33", "Bologna", "Italia", "12345" ), GruppoSanguigno.AB_Neg, true),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "NDUYTG69C71H501J", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Gino", "Paoli", Sesso.Maschio, new DateTime(1994, 06, 12), "ZVRVSZ41C41H679X", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Marco", "Bianchi", Sesso.Maschio, new DateTime(1994, 06, 12), "BMRNRJ71B06L229S", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Alfonso", "Verdi", Sesso.Maschio, new DateTime(1994, 06, 12), "JLDHDW45C14E951E", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Nicola", "Neri", Sesso.Maschio, new DateTime(1994, 06, 12), "NMGJLC61T67I168S", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Sara", "Secchi", Sesso.Femmina, new DateTime(1994, 06, 12), "BLEZNP50E45D006I", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Martina", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "DVHBZP42R20B292W", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Sara", "Secchi", Sesso.Femmina, new DateTime(1994, 06, 12), "DGVFFH91C56H432P", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Paola", "Ecchiara", Sesso.Femmina, new DateTime(1994, 06, 12), "ZDDPTY33T71Z731G", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Marco", "Tommasini", Sesso.Maschio, new DateTime(1994, 06, 12), "SCFGTX73E44G348S", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Tommaso", "DeLivorno", Sesso.Maschio, new DateTime(1994, 06, 12), "CXGHWD32R47G788H", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Marta", "La Farfalla", Sesso.Femmina, new DateTime(1994, 06, 12), "MOEXFV77A48L614A", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Xing", "Li", Sesso.Femmina, new DateTime(1994, 06, 12), "VXGFFM39D17F716B", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
            };

        public DonatoreService() : base(Items){}
    }
}
