using System;
using System.Collections.ObjectModel;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;

namespace BloodBank.Mock.Persone {

    public sealed class DonatoreMockDataService : MockDataService<Donatore>, IDataService<Donatore> {
        internal Donatore D1;
        internal Donatore D2;
        internal Donatore D3;
        internal Donatore D4;
        internal Donatore D5;
        internal Donatore D6;
        internal Donatore D7;
        internal Donatore D8;
        internal Donatore D9;
        internal Donatore D10;
        internal Donatore D11;
        internal Donatore D12;
        // Questi donatori non sono idonei
        internal Donatore D13;
        internal Donatore D14;

        public DonatoreMockDataService() {
            D1 = new Donatore(new Contatto("Pasquale", "Cafiero", Sesso.Maschio, new DateTime(1971, 12, 24), "DQCSRN36T14A704A", "Via Capo di Monte, 33", "Bologna", "Italia", "40135"), GruppoSanguigno.AB_Neg, true);
            D2 = new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 05), "NDUYTG69C71H501J", "Via Andrea Costa", "Bologna", "Italia", "40135"), GruppoSanguigno.O_Pos, true);
            D3 = new Donatore(new Contatto("Gino", "Paoli", Sesso.Maschio, new DateTime(1994, 07, 24), "ZVRVSZ41C41H679X", "Via Albiroli", "Bologna", "Italia", "40135"), GruppoSanguigno.O_Neg, true);
            D4 = new Donatore(new Contatto("Christopher", "Jones", Sesso.Maschio, new DateTime(1990, 08, 04), "BMRNRJ71B06L229S", "Quilly Lane", "Westerville", "Ohio", "43081"), GruppoSanguigno.AB_Neg, true);
            D5 = new Donatore(new Contatto("Alfonso", "Verdi", Sesso.Maschio, new DateTime(1984, 09, 08), "JLDHDW45C14E951E", "Pinewood Avenue", "Marquette", "Michigan", "49855"), GruppoSanguigno.AB_Pos, false);
            D6 = new Donatore(new Contatto("Nicola", "Neri", Sesso.Maschio, new DateTime(1946, 10, 23), "NMGJLC61T67I168S", "Via dei Tignosi", "Viterbo", "Italia", "12341"), GruppoSanguigno.A_Neg, false);
            D7 = new Donatore(new Contatto("Alice", "Paciulli", Sesso.Femmina, new DateTime(1992, 11, 15), "BLEZNP50E45D006I", "Via La Nebbia", "Roma", "Italia", "12341"), GruppoSanguigno.A_Pos, false);
            D8 = new Donatore(new Contatto("Martina", "Rossi", Sesso.Femmina, new DateTime(1965, 12, 07), "DVHBZP42R20B292W", "Via Capracotta", "Roma", "Italia", "12341"), GruppoSanguigno.B_Neg, false);
            D9 = new Donatore(new Contatto("Sara", "Secchi", Sesso.Femmina, new DateTime(1975, 01, 12), "DGVFFH91C56H432P", "Via Gallarana", "Monza", "Italia", "12341"), GruppoSanguigno.B_Pos, false);
            D10 = new Donatore(new Contatto("Paola", "Longo", Sesso.Femmina, new DateTime(1995, 02, 22), "ZDDPTY33T71Z731G", "Via Quattro Passi", "Formigine", "Italia", "12341"), GruppoSanguigno.O_Pos, false);
            D11 = new Donatore(new Contatto("Marco", "Tommasini", Sesso.Maschio, new DateTime(1999, 03, 30), "SCFGTX73E44G348S", "Stradello Romano", "Modena", "Italia", "12341"), GruppoSanguigno.O_Neg, false);
            D12 = new Donatore(new Contatto("Tommaso", "DeLivorno", Sesso.Maschio, new DateTime(1950, 04, 28), "CXGHWD32R47G788H", "Via Fatti Bello", "Comacchio", "Italia", "12341"), GruppoSanguigno.A_Pos, false);
            // Questi donatori non sono idonei
            D13 = new Donatore(new Contatto("Marta", "Martinelli", Sesso.Femmina, new DateTime(1926, 05, 03), "MOEXFV77A48L614A", "Via Battibecco", "Bologna", "Italia", "12341"), GruppoSanguigno.AB_Pos, false);
            D14 = new Donatore(new Contatto("Xing", "Li", Sesso.Femmina, new DateTime(2004, 06, 01), "VXGFFM39D17F716B", "Wood Duck Drive", "Sand River", "Indiana", "46563"), GruppoSanguigno.AB_Pos, false);

            _models = new ObservableCollection<Donatore> {D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11, D12, D13, D14};
        }
    }
}