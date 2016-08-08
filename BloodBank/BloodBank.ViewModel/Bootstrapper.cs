using System.Reflection;
using AutoMapper;
using BloodBank.Model.Donatori;
using BloodBank.ViewModel.Services;
using BloodBank.ViewModel.ViewModels;
using FluentValidation;
using Stylet;
using StyletIoC;

namespace BloodBank.ViewModel {
    public class Bootstrapper : Bootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(IStyletIoCBuilder builder) {
            base.ConfigureIoC(builder);
            builder.Assemblies.AddRange(new[] {Assembly.Load("BloodBank.View"), Assembly.Load("BloodBank.Validation") });
            builder.Bind(typeof(IModelValidator<>)).To(typeof(FluentModelValidator<>));
            builder.Bind(typeof(IValidator<>)).ToAllImplementations().InSingletonScope();
            builder.Bind(typeof(DataService<,>)).ToAllImplementations().InSingletonScope();
        }

        protected override void Configure() {
            base.Configure();

            IoC.GetInstance = Container.Get;
            IoC.BuildUp = Container.BuildUp;

            ViewManager viewManager = Container.Get<ViewManager>();
            viewManager.ViewAssemblies.Add(Assembly.Load("BloodBank.View"));

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Donatore, DonatoreViewModel>();
                cfg.CreateMap<DonatoreViewModel, Donatore>().ConstructUsingServiceLocator();
            });
        }
    }
}