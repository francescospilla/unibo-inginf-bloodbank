using System.Collections.ObjectModel;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;

namespace BloodBank.Mock {

    public sealed class IndagineQuestionarioDataService : DataService<Indagine<Questionario>> {

        internal IndagineBoolean<Questionario> Q1;
        internal IndagineBoolean<Questionario> Q2;
        internal IndagineBoolean<Questionario> Q3;
        internal IndagineRange<Questionario, int> Q4;
        internal IndagineBoolean<Questionario> Q5;
        internal IndagineRange<Questionario, double> Q6;
        internal IndagineBoolean<Questionario> Q7;
        internal IndagineBoolean<Questionario> Q8;
        internal IndagineBoolean<Questionario> Q9;
        internal IndagineRange<Questionario, int> Q10;
        internal IndagineRange<Questionario, int> Q11;
        internal IndagineRange<Questionario, int> Q12;
        internal IndagineBoolean<Questionario> Q13;

        public IndagineQuestionarioDataService() {
            Q1 = new IndagineBoolean<Questionario>("È attualmente in buona salute?", Idoneità.Idoneo, true);
            Q2 = new IndagineBoolean<Questionario>("Ha attualmente manifestazioni allergiche?", Idoneità.Sospeso, false);
            Q3 = new IndagineBoolean<Questionario>("Nell'ultima settimana si è sottoposto a cure odontoiatriche o ad interventi di piccola chirurgia ambulatoriale?", Idoneità.NonIdoneo, false);
            Q4 = new IndagineRange<Questionario, int>("Peso (kg)", Idoneità.NonIdoneo, 50, int.MaxValue);
            Q5 = new IndagineBoolean<Questionario>("Ha fatto tatuaggi negli ultimi 6 mesi?", Idoneità.Sospeso, false);
            Q6 = new IndagineRange<Questionario, double>("Valore emoglobina (g/dL)", Idoneità.NonIdoneo, 12.5, double.PositiveInfinity);
            Q7 = new IndagineBoolean<Questionario>("È attualmente in gravidanza?", Idoneità.NonIdoneo, false);
            Q8 = new IndagineBoolean<Questionario>("Ha mai assunto o assume sostanze stupefacenti?", Idoneità.NonIdoneo, false);
            Q9 = new IndagineBoolean<Questionario>("Si è recentemente sottoposto ad agopuntura?", Idoneità.Sospeso, false);
            Q10 = new IndagineRange<Questionario, int>("Pressione arteriosa massima (mmHg)", Idoneità.NonIdoneo, 180, int.MaxValue);
            Q11 = new IndagineRange<Questionario, int>("Pressione arteriosa minima (mmHg)", Idoneità.NonIdoneo, 100, int.MaxValue);
            Q12 = new IndagineRange<Questionario, int>("Pulsazioni (battiti/minuto)", Idoneità.Sospeso, 50, 100);
            Q13 = new IndagineBoolean<Questionario>("È mai stato affetto da brucellosi?", Idoneità.NonIdoneo, false);

            _models = new ObservableCollection<object> { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12 };
        }


    }

    public sealed class IndagineAnalisiDataService : DataService<Indagine<Analisi>> {

        internal IndagineRange<Analisi, double> A1;
        internal IndagineRange<Analisi, int> A2;
        internal IndagineBoolean<Analisi> A3;
        internal IndagineBoolean<Analisi> A4;
        internal IndagineBoolean<Analisi> A5;
        internal IndagineBoolean<Analisi> A6;

        public IndagineAnalisiDataService() {
            A1 = new IndagineRange<Analisi, double>("Esame emocromocitometrico completo (milioni per ml di sangue)", Idoneità.Sospeso, 3.8, 5.9);
            A2 = new IndagineRange<Analisi, int>("Transaminasi ALT con metodo ottimizzato (U/I)", Idoneità.NonIdoneo, 40, int.MaxValue);
            A3 = new IndagineBoolean<Analisi>("Sierodiagnosi per la Lue (per sifilide)", Idoneità.NonIdoneo, false);
            A4 = new IndagineBoolean<Analisi>("HBsAg (per l'epatite B)", Idoneità.NonIdoneo, false);
            A5 = new IndagineBoolean<Analisi>("HIVAb 1-2 (per l'AIDS)", Idoneità.NonIdoneo, false);
            A6 = new IndagineBoolean<Analisi>("HCVAb e costituenti virali (per l'epatite C)", Idoneità.NonIdoneo, false);

            _models = new ObservableCollection<object> { A1, A2, A3, A4, A5, A6 };
        }

    }

}