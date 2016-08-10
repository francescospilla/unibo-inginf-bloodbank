using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using StyletIoC;

namespace Stylet.FluentValidation {
    public static class ConfigureIoC {
        public static void ConfigureForFluentValidation(this IStyletIoCBuilder builder, params string[] validationAssemblies) {
            if (validationAssemblies != null)
                foreach (string validationAssembly in validationAssemblies)
                    builder.Assemblies.Add(Assembly.Load(validationAssembly));
            
            builder.Bind(typeof(IModelValidator<>)).To(typeof(FluentModelValidator<>));
            builder.Bind(typeof(IValidator<>)).ToAllImplementations().InSingletonScope();
        }
    }
}
