using System.Reflection;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using StructureMap;
using Stylet;
using Stylet.FluentValidation;

namespace BloodBank.ViewModel {
    public class Bootstrapper : StructureMapBootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(ConfigurationExpression config) {
            base.ConfigureIoC(config);

            config.Scan(x =>
            {
                x.AssemblyContainingType(typeof(IDataService<>));
                x.ConnectImplementationsToTypesClosing(typeof(IDataService<>)).OnAddedPluginTypes(c => c.Singleton());
                x.AssemblyContainingType(typeof(IDataService<,>));
                x.ConnectImplementationsToTypesClosing(typeof(IDataService<,>)).OnAddedPluginTypes(c => c.Singleton());
                x.WithDefaultConventions();
            });

            config.ConfigureForFluentValidation();
        }

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = (ViewManager) GetInstance(typeof(IViewManager));
            viewManager.ViewAssemblies.Add(Assembly.GetEntryAssembly());
        }


    }
}