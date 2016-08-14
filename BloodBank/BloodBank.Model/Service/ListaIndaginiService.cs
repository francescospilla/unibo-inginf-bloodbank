﻿using BloodBank.Core.Extensions;
using BloodBank.Model.Indagini;
using BloodBank.Model.Tests;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank.Model.Service {

    public abstract class ListaIndaginiService<T> : DataService<ListaIndagini<T>> where T : ListaVoci {

        protected ListaIndaginiService(IList<ListaIndagini<T>> items) : base(items) {
        }
    }

    public class AnalisiService : ListaIndaginiService<Analisi> {

        public AnalisiService(IDataService<Indagine> indagineService) : base(new List<ListaIndagini<Analisi>>()) {
            Indagine[] indagini = indagineService.GetModels().ToArray();

            for (int i = 0; i < 5; i++) {
                ListaIndagini<Analisi> li = new ListaIndagini<Analisi>("Analisi #" + (i + 1));
                li.AddRange(indagini.PickRandom(4));
                _models.Add(li);
            }
        }
    }

    public class QuestionarioService : ListaIndaginiService<Questionario> {

        public QuestionarioService(IDataService<Indagine> indagineService) : base(new List<ListaIndagini<Questionario>>()) {
            Indagine[] indagini = indagineService.GetModels().ToArray();

            for (int i = 0; i < 5; i++) {
                ListaIndagini<Questionario> li = new ListaIndagini<Questionario>("Questionario #" + (i + 1));
                li.AddRange(indagini.PickRandom(4));
                _models.Add(li);
            }
        }
    }
}