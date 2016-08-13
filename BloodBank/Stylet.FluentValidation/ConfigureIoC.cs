using System.Reflection;
using FluentValidation;
using StructureMap;
using StructureMap.Pipeline;

namespace Stylet.FluentValidation {
    public static class ConfigureIoC {
        public static void ConfigureForFluentValidation(this ConfigurationExpression config, string validationAssembly) {

            config.Scan(x => {
                x.AddAllTypesOf(typeof(IValidator<>));
                x.Assembly(validationAssembly);
                x.WithDefaultConventions();
            });

            config.For(typeof(IModelValidator<>)).Use(typeof(FluentModelValidator<>));
        }
    }
}
