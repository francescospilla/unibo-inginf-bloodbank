using System.Reflection;
using BloodBank.ViewModel.Services;
using Stylet;
using Stylet.FluentValidation;
using StyletIoC;

namespace BloodBank.ViewModel {
    public class Bootstrapper : Bootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(IStyletIoCBuilder builder) {
            base.ConfigureIoC(builder);
            builder.Assemblies.AddRange(new[] { Assembly.Load("BloodBank.View") });
            builder.ConfigureForFluentValidation("BloodBank.Validation");
            builder.Bind(typeof(IDataService<>)).ToAllImplementations().InSingletonScope();
        }

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = Container.Get<ViewManager>();
            viewManager.ViewAssemblies.Add(Assembly.Load("BloodBank.View"));
        }


    }
}