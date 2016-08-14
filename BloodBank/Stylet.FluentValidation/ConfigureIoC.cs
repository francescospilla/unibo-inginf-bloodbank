using System.Reflection;
using FluentValidation;
using StructureMap;
using StructureMap.Pipeline;
using BloodBank.Validation;

namespace Stylet.FluentValidation {
    public static class ConfigureIoC {
        public static void ConfigureForFluentValidation(this ConfigurationExpression config) {

            config.Scan(x => {
                x.AssemblyContainingType(typeof(ValidatorExtensions));
                x.ConnectImplementationsToTypesClosing(typeof(IValidator<>)).OnAddedPluginTypes(c => c.Singleton());
                x.WithDefaultConventions();
            });

            config.For(typeof(IModelValidator<>)).Use(typeof(FluentModelValidator<>));
        }
    }
}
