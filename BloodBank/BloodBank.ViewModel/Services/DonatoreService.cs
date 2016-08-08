using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodBank.Model.Donatori;
using BloodBank.Model.Sangue;
using BloodBank.ViewModel.ViewModels;

namespace BloodBank.ViewModel.Services {
    public class DonatoreService : DataService<IDonatore, DonatoreViewModel> {

        public override IEnumerable<IDonatore> GetModels() {
            List<Donatore> items = new List<Donatore>() {
                new Donatore(new Contatto("Pasquale", "Cafiero", Sesso.Maschio, new DateTime(1971, 12, 24), "DQCSRN36T14A704A", "Via Capo di Monte, 33", "Bologna", "Italia", "12345" ), GruppoSanguigno.AB_Neg, true),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "NDUYTG69C71H501J", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "ZVRVSZ41C41H679X", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "BMRNRJ71B06L229S", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "JLDHDW45C14E951E", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "NMGJLC61T67I168S", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "BLEZNP50E45D006I", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "DVHBZP42R20B292W", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "ZDDPTY33T71Z731G", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "SCFGTX73E44G348S", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "CXGHWD32R47G788H", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "MOEXFV77A48L614A", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
                new Donatore(new Contatto("Ginevra", "Rossi", Sesso.Femmina, new DateTime(1994, 06, 12), "VXGFFM39D17F716B", "Sotto a un ponte", "Bologna", "Italia", "12341" ), GruppoSanguigno.O_Pos, false),
            };
            return items;
        }
    }
}
