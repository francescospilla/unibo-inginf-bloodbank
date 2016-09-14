using System.Collections.Generic;
using BloodBank.Model.Models;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Indagini.Tipi;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;

namespace BloodBank.Mock
{

    public abstract class IndagineService<U> : DataService<Indagine<U>> where U : ListaVoci
    {
        protected IndagineService(IList<Indagine<U>> items) : base(items)
        {
        }
    }

    public class IndagineQuestionarioService : IndagineService<Questionario>
    {

        internal static IndagineBoolean<Questionario> Q1 = new IndagineBoolean<Questionario>("È attualmente in buona salute?", Idoneità.Idoneo, true);
        internal static IndagineBoolean<Questionario> Q2 = new IndagineBoolean<Questionario>("Ha attualmente manifestazioni allergiche?", Idoneità.Sospeso, false);
        internal static IndagineBoolean<Questionario> Q3 = new IndagineBoolean<Questionario>("Nell'ultima settimana si è sottoposto a cure odontoiatriche o ad interventi di piccola chirurgia ambulatoriale?", Idoneità.NonIdoneo, false);
        internal static IndagineRange<Questionario, int> Q4 = new IndagineRange<Questionario, int>("Peso (kg)", Idoneità.NonIdoneo, 50, int.MaxValue);
        internal static IndagineBoolean<Questionario> Q5 = new IndagineBoolean<Questionario>("Ha fatto tatuaggi negli ultimi 6 mesi?", Idoneità.Sospeso, false);
        internal static IndagineRange<Questionario, double> Q6 = new IndagineRange<Questionario, double>("Valore emoglobina (g/dL)", Idoneità.NonIdoneo, 12.5, double.MaxValue);
        internal static IndagineBoolean<Questionario> Q7 = new IndagineBoolean<Questionario>("È attualmente in gravidanza?", Idoneità.NonIdoneo, false);
        internal static IndagineBoolean<Questionario> Q8 = new IndagineBoolean<Questionario>("Ha mai assunto o assume sostanze stupefacenti?", Idoneità.NonIdoneo, false);
        internal static IndagineBoolean<Questionario> Q9 = new IndagineBoolean<Questionario>("Si è recentemente sottoposto ad agopuntura?", Idoneità.Sospeso, false);
        internal static IndagineRange<Questionario, int> Q10 = new IndagineRange<Questionario, int>("Pressione arteriosa massima (mmHg)", Idoneità.NonIdoneo, 180, int.MaxValue);
        internal static IndagineRange<Questionario, int> Q11 = new IndagineRange<Questionario, int>("Pressione arteriosa minima (mmHg)", Idoneità.NonIdoneo, 100, int.MaxValue);
        internal static IndagineRange<Questionario, int> Q12 = new IndagineRange<Questionario, int>("Pulsazioni (battiti/minuto)", Idoneità.Sospeso, 50, 100);
        internal static IndagineBoolean<Questionario> Q13 = new IndagineBoolean<Questionario>("È mai stato affetto da brucellosi?", Idoneità.NonIdoneo, false);

        private static readonly IList<Indagine<Questionario>> Items = new List<Indagine<Questionario>>()
        {
            Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, Q12
        };

        public IndagineQuestionarioService() : base(Items)
        {
        }
    }

    public class IndagineAnalisiService : IndagineService<Analisi>
    {

        internal static IndagineRange<Analisi, double> A1 = new IndagineRange<Analisi, double>("Esame emocromocitometrico completo (milioni per ml di sangue)", Idoneità.Sospeso, 3.8, 5.9);
        internal static IndagineRange<Analisi, int> A2 = new IndagineRange<Analisi, int>("Transaminasi ALT con metodo ottimizzato (U/I)", Idoneità.NonIdoneo, 40, int.MaxValue);
        internal static IndagineBoolean<Analisi> A3 = new IndagineBoolean<Analisi>("Sierodiagnosi per la Lue (per sifilide)", Idoneità.NonIdoneo, false);
        internal static IndagineBoolean<Analisi> A4 = new IndagineBoolean<Analisi>("HBsAg (per l'epatite B)", Idoneità.NonIdoneo, false);
        internal static IndagineBoolean<Analisi> A5 = new IndagineBoolean<Analisi>("HIVAb 1-2 (per l'AIDS)", Idoneità.NonIdoneo, false);
        internal static IndagineBoolean<Analisi> A6 = new IndagineBoolean<Analisi>("HCVAb e costituenti virali (per l'epatite C)", Idoneità.NonIdoneo, false);

        private static readonly IList<Indagine<Analisi>> Items = new List<Indagine<Analisi>>()
        {
            A1, A2, A3, A4, A5, A6
        };

        public IndagineAnalisiService() : base(Items)
        {
        }
    }

}