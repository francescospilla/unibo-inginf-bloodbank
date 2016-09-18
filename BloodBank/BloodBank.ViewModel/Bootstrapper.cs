using System.Collections.Generic;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using StructureMap;
using Stylet;
using Stylet.FluentValidation;
using System.Reflection;
using BloodBank.Mock;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Tests;
using StructureMap.Pipeline;
using ValidatorExtensions = BloodBank.ViewModel.Validation.ValidatorExtensions;

namespace BloodBank.ViewModel {

    public class Bootstrapper : StructureMapBootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(ConfigurationExpression config) {
            base.ConfigureIoC(config);

            config.Scan(x => {
                x.AssemblyContainingType(typeof(DonatoreService));
                x.ConnectImplementationsToTypesClosing(typeof(IDataService<>)).OnAddedPluginTypes(c => c.Singleton());
                x.WithDefaultConventions();
            });

            config.Policies.SetAllProperties(policy => policy.Matching(info => info.Name.EndsWith("FactoryFunc") && info.CanWrite));
            config.For(typeof (IDataService<,>)).Use(typeof (DataService<,>)).LifecycleIs<SingletonLifecycle>();
            config.ConfigureForFluentValidation(typeof(ValidatorExtensions));
        }
        

        protected override ViewManager CreateViewManager(ViewManagerConfig viewManagerConfig)
        {
            viewManagerConfig.ViewAssemblies.Add(Assembly.GetEntryAssembly());
            return new DictionaryViewManager(viewManagerConfig);
        }
        

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = (ViewManager)GetInstance(typeof(IViewManager));
        }
    }
}