﻿using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using Stylet;
using Stylet.FluentValidation;
using BloodBank.Mock;
using BloodBank.Mock.Donazioni;
using BloodBank.Mock.Indagini;
using BloodBank.Mock.Persone;
using BloodBank.Mock.Sangue;
using BloodBank.Mock.Test;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.View;
using BloodBank.ViewModel;
using Ninject;
using Stylet.DictionaryViewManager;
using ValidatorExtensions = BloodBank.ViewModel.Validation.ValidatorExtensions;

namespace BloodBank {

    public class Bootstrapper : NinjectBootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(IKernel kernel) {
            base.ConfigureIoC(kernel);
          
            kernel.Bind<IDataService<Donatore>, DonatoreMockDataService>().To<DonatoreMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Donazione>, DonazioneMockDataService>().To<DonazioneMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Indagine>, IDataService<Indagine<Analisi>>, IndagineAnalisiMockDataService>().To<IndagineAnalisiMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Indagine>, IDataService<Indagine<Questionario>>, IndagineQuestionarioMockDataService>().To<IndagineQuestionarioMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<ListaIndagini<Analisi>>, ListaIndaginiAnalisiMockDataService>().To<ListaIndaginiAnalisiMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<ListaIndagini<Questionario>>, ListaIndaginiQuestionarioMockDataService>().To<ListaIndaginiQuestionarioMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Analisi>, AnalisiMockDataService>().To<AnalisiMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Questionario>, QuestionarioMockDataService>().To<QuestionarioMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Medico>, MedicoMockDataService>().To<MedicoMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<SaccaSangue>, SaccaSangueMockDataService>().To<SaccaSangueMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<VisitaMedica>, VisitaMedicaMockDataService > ().To<VisitaMedicaMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Voce<Analisi>>, VoceAnalisiMockDataService>().To<VoceAnalisiMockDataService>().InSingletonScope();
            kernel.Bind<IDataService<Voce<Questionario>>, VoceQuestionarioMockDataService>().To<VoceQuestionarioMockDataService>().InSingletonScope();

            kernel.Bind<IDonazioneFactory, Donazione.DonazioneFactory>().To<Donazione.DonazioneFactory>().InSingletonScope();
            kernel.Bind<IAnalisiFactory, IListaVociFactory<Analisi>, ListaVoci.ListaVociFactory<Analisi>>().To<Analisi.AnalisiFactory>().InSingletonScope();
            kernel.Bind<IQuestionarioFactory, IListaVociFactory<Questionario>, ListaVoci.ListaVociFactory<Questionario>>().To<Questionario.QuestionarioFactory>().InSingletonScope();
            kernel.Bind<ISaccaSangueFactory, SaccaSangue.SaccaSangueFactory>().To<SaccaSangue.SaccaSangueFactory>().InSingletonScope();
            kernel.Bind<IVisitaMedicaFactory, VisitaMedica.VisitaMedicaFactory>().To<VisitaMedica.VisitaMedicaFactory>().InSingletonScope();

            kernel.ConfigureForFluentValidation(typeof(ValidatorExtensions));
        }

        protected override ViewManager CreateViewManager(ViewManagerConfig config) {
            return config.ConfigureForDictionaryViewManager(typeof(ShellView), typeof(ShellViewModel));
        }
    }
}