using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using Stylet;
using Stylet.FluentValidation;
using BloodBank.Mock;
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

            kernel.Bind(x => x
                .FromAssemblyContaining(typeof(DonatoreService))
                .SelectAllIncludingAbstractClasses().InheritedFrom(typeof(IDataService<>))
                .BindAllInterfaces().Configure(b => b.InSingletonScope())
            );

            kernel.Bind(typeof(IDataService<,>)).To(typeof(DataService<,>)).InSingletonScope();
            kernel.ConfigureForFluentValidation(typeof(ValidatorExtensions));
        }

        protected override ViewManager CreateViewManager(ViewManagerConfig config) {
            return config.ConfigureForDictionaryViewManager(typeof(ShellView), typeof(ShellViewModel));
        }
    }
}