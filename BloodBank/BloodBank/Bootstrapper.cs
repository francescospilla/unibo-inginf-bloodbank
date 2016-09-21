using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using Stylet;
using Stylet.FluentValidation;
using BloodBank.Mock;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Models.Tests;
using BloodBank.View;
using BloodBank.ViewModel;
using Ninject;
using Ninject.Extensions.Conventions;
using Stylet.DictionaryViewManager;
using ValidatorExtensions = BloodBank.ViewModel.Validation.ValidatorExtensions;

namespace BloodBank {

    public class Bootstrapper : NinjectBootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(IKernel kernel) {
            base.ConfigureIoC(kernel);

            kernel.Bind(typeof(IDataService<,>)).To(typeof(DataService<,>)).InSingletonScope();
            
            kernel.Bind<IDataService<Donatore>, DonatoreDataService>().To<DonatoreDataService>().InSingletonScope();
            kernel.Bind<IDataService<Donazione>, DonazioneDataService>().To<DonazioneDataService>().InSingletonScope();
            kernel.Bind<IDataService<Indagine<Analisi>>, IndagineAnalisiDataService>().To<IndagineAnalisiDataService>().InSingletonScope();
            kernel.Bind<IDataService<Indagine<Questionario>>, IndagineQuestionarioDataService>().To<IndagineQuestionarioDataService>().InSingletonScope();
            kernel.Bind<IDataService<ListaIndagini<Analisi>>, ListaIndaginiAnalisiDataService>().To<ListaIndaginiAnalisiDataService>().InSingletonScope();
            kernel.Bind<IDataService<ListaIndagini<Questionario>>, ListaIndaginiQuestionarioDataService>().To<ListaIndaginiQuestionarioDataService>().InSingletonScope();
            kernel.Bind<IDataService<Analisi>, ListaVociAnalisiDataService>().To<ListaVociAnalisiDataService>().InSingletonScope();
            kernel.Bind<IDataService<Questionario>, ListaVociQuestionarioDataService>().To<ListaVociQuestionarioDataService>().InSingletonScope();
            kernel.Bind<IDataService<Medico>, MedicoDataService>().To<MedicoDataService>().InSingletonScope();
            kernel.Bind<IDataService<SaccaSangue>, SaccaSangueDataService>().To<SaccaSangueDataService>().InSingletonScope();
            kernel.Bind<IDataService<VisitaMedica>, VisitaMedicaDataService > ().To<VisitaMedicaDataService>().InSingletonScope();
            kernel.Bind<IDataService<Voce<Analisi>>, VoceAnalisiDataService>().To<VoceAnalisiDataService>().InSingletonScope();
            kernel.Bind<IDataService<Voce<Questionario>>, VoceQuestionarioDataService>().To<VoceQuestionarioDataService>().InSingletonScope();


            kernel.ConfigureForFluentValidation(typeof(ValidatorExtensions));
        }

        protected override ViewManager CreateViewManager(ViewManagerConfig config) {
            return config.ConfigureForDictionaryViewManager(typeof(ShellView), typeof(ShellViewModel));
        }
    }
}