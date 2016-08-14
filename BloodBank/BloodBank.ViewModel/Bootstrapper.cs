using System.Reflection;
using BloodBank.Model.Donatori;
using BloodBank.Model.Service;
using StructureMap;
using Stylet;
using Stylet.FluentValidation;
using StyletIoC;

namespace BloodBank.ViewModel {
    public class Bootstrapper : StructureMapBootstrapper<ShellViewModel> {
        private readonly Assembly _viewAssembly = Assembly.Load("BloodBank");

        protected override void ConfigureIoC(ConfigurationExpression config) {
            base.ConfigureIoC(config);

            config.Scan(x =>
            {
                x.AddAllTypesOf(typeof (IDataService<>));
                x.Assembly("BloodBank.Model");
                x.WithDefaultConventions();
            });
            
            config.ConfigureForFluentValidation("BloodBank.Validation");
        }

        protected override void Configure() {
            base.Configure();

            ViewManager viewManager = (ViewManager) GetInstance(typeof(IViewManager));
            viewManager.ViewAssemblies.Add(_viewAssembly);
        }


    }
}