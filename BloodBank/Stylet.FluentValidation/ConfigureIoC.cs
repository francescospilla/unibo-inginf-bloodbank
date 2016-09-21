using FluentValidation;
using System;
using Ninject;
using Ninject.Extensions.Conventions;

namespace Stylet.FluentValidation {

    public static class ConfigureIoC {

        public static void ConfigureForFluentValidation(this IKernel kernel, Type typeToScanFor) {
            kernel.Bind(x => x
                .FromAssemblyContaining(typeToScanFor)
                .SelectAllClasses().InheritedFrom(typeof(IValidator<>))
                .BindAllInterfaces()
            );

            kernel.Bind(typeof (IModelValidator<>)).To(typeof (FluentModelValidator<>));
        }
    }
}