using System;
using FluentValidation;
using StructureMap;

namespace Stylet.FluentValidation {
    public static class ConfigureIoC {
        public static void ConfigureForFluentValidation(this ConfigurationExpression config, Type typeToScanFor) {

            config.Scan(x => {
                x.AssemblyContainingType(typeToScanFor);
                x.ConnectImplementationsToTypesClosing(typeof(IValidator<>)).OnAddedPluginTypes(c => c.Singleton());
                x.WithDefaultConventions();
            });

            config.For(typeof(IModelValidator<>)).Use(typeof(FluentModelValidator<>));
        }
    }
}
