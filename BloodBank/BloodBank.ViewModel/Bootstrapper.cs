﻿using BloodBank.Model.Service;
using BloodBank.Validation;
using BloodBank.ViewModel.Service;
using StructureMap;
using Stylet;
using Stylet.FluentValidation;
using System.Reflection;

namespace BloodBank.ViewModel {

    public class Bootstrapper : StructureMapBootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(ConfigurationExpression config) {
            base.ConfigureIoC(config);

            config.Scan(x => {
                x.AssemblyContainingType(typeof(IDataService<>));
                x.ConnectImplementationsToTypesClosing(typeof(IDataService<>)).OnAddedPluginTypes(c => c.Singleton());
                x.AssemblyContainingType(typeof(IDataService<,>));
                x.ConnectImplementationsToTypesClosing(typeof(IDataService<,>)).OnAddedPluginTypes(c => c.Singleton());
                x.WithDefaultConventions();
            });

            config.Policies.SetAllProperties(policy => policy.Matching(info => info.Name.EndsWith("FactoryFunc") && info.CanWrite));

            config.ConfigureForFluentValidation(typeof(ValidatorExtensions));
        }

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = (ViewManager)GetInstance(typeof(IViewManager));
            viewManager.ViewAssemblies.Add(Assembly.GetEntryAssembly());
        }
    }
}