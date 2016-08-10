using System.Reflection;
using AutoMapper;
using BloodBank.Model.Donatori;
using BloodBank.ViewModel.Services;
using BloodBank.ViewModel.ViewModels;
using Stylet;
using Stylet.FluentValidation;
using StyletIoC;

namespace BloodBank.ViewModel {
    public class Bootstrapper : Bootstrapper<ShellViewModel> {

        protected override void ConfigureIoC(IStyletIoCBuilder builder) {
            base.ConfigureIoC(builder);
            builder.Assemblies.AddRange(new[] {Assembly.Load("BloodBank.View") });
            builder.ConfigureForFluentValidation("BloodBank.Validation");
            builder.Bind(typeof(IDataService<>)).ToAllImplementations().InSingletonScope();
        }

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = Container.Get<ViewManager>();
            viewManager.ViewAssemblies.Add(Assembly.Load("BloodBank.View"));

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Donatore, DonatoreViewModel>();
                cfg.CreateMap<DonatoreViewModel, Donatore>().ConstructUsingServiceLocator();
            });
        }
    }
}