using System.Collections.ObjectModel;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Mock.Indagini {

    public sealed class IndagineQuestionarioMockDataService : MockDataService<Indagine<Questionario>> {

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

        public IndagineQuestionarioMockDataService() {
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

            _models = new ObservableCollection<Indagine<Questionario>> { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12 };
        }


    }
}