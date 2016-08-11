using System.Reflection;
using BloodBank.Model.Service;
using Stylet;
using Stylet.FluentValidation;
using StyletIoC;

namespace BloodBank.ViewModel {
    public class Bootstrapper : Bootstrapper<ShellViewModel> {
        private readonly Assembly _mainAssembly = Assembly.Load("BloodBank");

        protected override void ConfigureIoC(IStyletIoCBuilder builder) {
            base.ConfigureIoC(builder);
            
            builder.Assemblies.AddRange(new[] { _mainAssembly, Assembly.Load("BloodBank.Model.Service"),  });
            builder.ConfigureForFluentValidation("BloodBank.Validation");
            builder.Bind(typeof(IDataService<>)).ToAllImplementations().InSingletonScope();
        }

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = Container.Get<ViewManager>();
            viewManager.ViewAssemblies.Add(_mainAssembly);
        }


    }
}