using System.Collections.Generic;
using BloodBank.Model.Service;
using BloodBank.ViewModel.Service;
using StructureMap;
using Stylet;
using Stylet.FluentValidation;
using System.Reflection;
using BloodBank.Mock;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Indagini;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Tests;
using BloodBank.View;
using BloodBank.ViewModel;
using BloodBank.ViewModel.ViewModels.Indagini;
using StructureMap.Pipeline;
using Stylet.DictionaryViewManager;
using ValidatorExtensions = BloodBank.ViewModel.Validation.ValidatorExtensions;

namespace BloodBank {

    public class Bootstrapper : StructureMapBootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(ConfigurationExpression config) {
            base.ConfigureIoC(config);

            config.Scan(x => {
                x.AssemblyContainingType(typeof(DonatoreService));
                x.ConnectImplementationsToTypesClosing(typeof(IDataService<>)).OnAddedPluginTypes(c => c.Singleton());
                x.WithDefaultConventions();
            });

            config.Policies.SetAllProperties(policy => policy.Matching(info => info.Name.EndsWith("FactoryFunc") && info.CanWrite));
            config.Policies.SetAllProperties(policy => policy.TypeMatches(type => type == typeof(IFactory<>)));
            config.For(typeof(IDataService<,>)).Use(typeof(DataService<,>)).LifecycleIs<SingletonLifecycle>();

            config.ConfigureForFluentValidation(typeof(ValidatorExtensions));
        }

        protected override ViewManager CreateViewManager(ViewManagerConfig config) {
            return config.ConfigureForDictionaryViewManager(typeof(ShellView), typeof(ShellViewModel));
        }
    }
}