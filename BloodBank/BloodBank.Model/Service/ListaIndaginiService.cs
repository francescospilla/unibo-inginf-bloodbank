using BloodBank.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;

namespace BloodBank.Model.Service {

    public abstract class ListaIndaginiService<U> : DataService<ListaIndagini<U>> where U : ListaVoci {

        protected ListaIndaginiService(IList<ListaIndagini<U>> items) : base(items) {
        }
    }

    public class AnalisiService : ListaIndaginiService<Analisi> {

        public AnalisiService(IDataService<Indagine<Analisi>> indagineService) : base(new List<ListaIndagini<Analisi>>()) {
            Indagine[] indagini = indagineService.GetModels().ToArray();

            for (int i = 0; i < 5; i++) {
                ListaIndagini<Analisi> li = new ListaIndagini<Analisi>("Analisi #" + (i + 1));
                li.AddRange(indagini.PickRandom(4));
                _models.Add(li);
            }
        }
    }

    public class QuestionarioService : ListaIndaginiService<Questionario> {

        public QuestionarioService(IDataService<Indagine<Questionario>> indagineService) : base(new List<ListaIndagini<Questionario>>()) {
            Indagine[] indagini = indagineService.GetModels().ToArray();

            for (int i = 0; i < 5; i++) {
                ListaIndagini<Questionario> li = new ListaIndagini<Questionario>("Questionario #" + (i + 1));
                li.AddRange(indagini.PickRandom(4));
                _models.Add(li);
            }
        }
    }
}