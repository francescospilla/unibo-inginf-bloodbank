using System;
using System.Collections.Generic;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Service;
using PropertyChanged;

namespace BloodBank.Model.Models.Tests
{
    [ImplementPropertyChanged]
	public class Questionario : ListaVoci {

        private Questionario(Donatore donatore, string descrizioneBreve, DateTime data, IEnumerable<Voce<Questionario>> listaVoci)
            : base(donatore, descrizioneBreve, data, listaVoci)
        {
        }

        public class QuestionarioFactory : ListaVociFactory<Questionario>, IQuestionarioFactory {
            public QuestionarioFactory(IDataService<Questionario> dataService) : base(dataService) {
            }

            protected override Questionario CreateActualModel(Donatore donatore, string descrizioneBreve,
                DateTime data, IEnumerable<Voce<Questionario>> listaVoci) {
                return new Questionario(donatore, descrizioneBreve, data, listaVoci);
            }
        }
    }
}