using System.Collections.Generic;
using System.Collections.ObjectModel;
using BloodBank.Model.Models.Tests;
using BloodBank.Model.Service;
using BloodBank.Model.Models.Indagini;

namespace BloodBank.Mock {

    public abstract class VoceService<U> : DataService<Voce<U>> where U : ListaVoci {
    }

    public class VoceQuestionarioService : VoceService<Questionario> {
        internal Voce<Questionario> Vq1;
        internal Voce<Questionario> Vq2;
        internal Voce<Questionario> Vq3;
        internal Voce<Questionario> Vq4;
        internal Voce<Questionario> Vq5;
        internal Voce<Questionario> Vq6;
        internal Voce<Questionario> Vq7;
        internal Voce<Questionario> Vq8;
        internal Voce<Questionario> Vq9;
        internal Voce<Questionario> Vq10;
        internal Voce<Questionario> Vq11;
        internal Voce<Questionario> Vq12;
        
        public VoceQuestionarioService(IndagineQuestionarioService iq) : base() {

            Vq1 = new Voce<Questionario, bool>(iq.Q1, true);
            Vq2 = new Voce<Questionario, bool>(iq.Q1, false);
            Vq3 = new Voce<Questionario, bool>(iq.Q2, true);
            Vq4 = new Voce<Questionario, bool>(iq.Q2, false);
            Vq5 = new Voce<Questionario, bool>(iq.Q3, true);
            Vq6 = new Voce<Questionario, bool>(iq.Q3, false);
            Vq7 = new Voce<Questionario, int>(iq.Q4, 47);
            Vq8 = new Voce<Questionario, int>(iq.Q4, 80);
            Vq9 = new Voce<Questionario, bool>(iq.Q5, true);
            Vq10 = new Voce<Questionario, bool>(iq.Q5, false);
            Vq11 = new Voce<Questionario, double>(iq.Q6, 5.6);
            Vq12 = new Voce<Questionario, double>(iq.Q6, 15.0);

            _models = new ObservableCollection<Voce<Questionario>>(){Vq1, Vq1, Vq2, Vq3, Vq4, Vq5, Vq6, Vq7, Vq8, Vq9, Vq10, Vq11, Vq12};
        }

    }

    public class VoceAnalisiService : VoceService<Analisi> {

        internal Voce<Analisi> Va1;
        internal Voce<Analisi> Va2;
        internal Voce<Analisi> Va3;
        internal Voce<Analisi> Va4;
        internal Voce<Analisi> Va5;
        internal Voce<Analisi> Va6;
        internal Voce<Analisi> Va7;
        internal Voce<Analisi> Va8;
        internal Voce<Analisi> Va9;
        internal Voce<Analisi> Va10;
        internal Voce<Analisi> Va11;
        internal Voce<Analisi> Va12;

        public VoceAnalisiService(IndagineAnalisiService ia) : base() {
            Va1 = new Voce<Analisi, double>(ia.A1, 4.2);
            Va2 = new Voce<Analisi, double>(ia.A1, 8.6);
            Va3 = new Voce<Analisi, int>(ia.A2, 25);
            Va4 = new Voce<Analisi, int>(ia.A2, 46);
            Va5 = new Voce<Analisi, bool>(ia.A3, true);
            Va6 = new Voce<Analisi, bool>(ia.A3, false);
            Va7 = new Voce<Analisi, bool>(ia.A4, true);
            Va8 = new Voce<Analisi, bool>(ia.A4, false);
            Va9 = new Voce<Analisi, bool>(ia.A5, true);
            Va10 = new Voce<Analisi, bool>(ia.A5, false);
            Va11 = new Voce<Analisi, bool>(ia.A6, true);
            Va12 = new Voce<Analisi, bool>(ia.A6, false);

            _models = new ObservableCollection<Voce<Analisi>>(){Va1, Va2, Va3, Va4, Va5, Va6, Va7, Va8, Va9, Va10, Va11, Va12};
        }

    }
}
