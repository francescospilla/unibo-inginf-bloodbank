using System;
using System.Collections.ObjectModel;
using BloodBank.Model.Models.Persone;

namespace BloodBank.Mock.Persone {
    public sealed class MedicoMockDataService : MockDataService<Medico> {
        internal Medico M1;
        internal Medico M2;
        internal Medico M3;
        internal Medico M4;
        internal Medico M5;

        public MedicoMockDataService() {
            M1 = new Medico(new Contatto("Rita", "Colombo", Sesso.Femmina, new DateTime(1971, 12, 24), "DLCSRN36T14A704A", "Via Capo di Monte, 33", "Bologna", "Italia", "12345"));
            M2 = new Medico(new Contatto("Marco", "Rossi", Sesso.Maschio, new DateTime(1981, 09, 04), "NIUYTG69C71H501J", "Sotto a un ponte", "Bologna", "Italia", "12341"));
            M3 = new Medico(new Contatto("Sara", "Rizzo", Sesso.Femmina, new DateTime(1976, 11, 23), "ZVRVSZ41L41H679X", "Sotto a un ponte", "Bologna", "Italia", "12341"));
            M4 = new Medico(new Contatto("Nicola", "Bianchi", Sesso.Maschio, new DateTime(1966, 04, 01), "BMONRJ71B06L229S", "Sotto a un ponte", "Bologna", "Italia", "12341"));
            M5 = new Medico(new Contatto("Renzo", "Verdi", Sesso.Maschio, new DateTime(1960, 08, 12), "JLDHDW45C14S951E", "Sotto a un ponte", "Bologna", "Italia", "12341"));

            _models = new ObservableCollection<object> { M1, M2, M3, M4, M5 };

        }
        
    }
}
