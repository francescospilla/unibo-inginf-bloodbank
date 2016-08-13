using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Pipeline;
using Stylet;

namespace BloodBank.ViewModel {
    public class StructureMapBootstrapper<TRootViewModel> : BootstrapperBase where TRootViewModel : class {
        private IContainer container;

        private object _rootViewModel;
        protected virtual object RootViewModel {
            get { return this._rootViewModel ?? (this._rootViewModel = this.GetInstance(typeof(TRootViewModel))); }
        }

        protected override void ConfigureBootstrapper() {
            this.container = new Container(config => {
                this.DefaultConfigureIoC(config);
                this.ConfigureIoC(config);
            });
        }

        /// <summary>
        /// Carries out default configuration of the IoC container. Override if you don't want to do this
        /// </summary>
        protected virtual void DefaultConfigureIoC(ConfigurationExpression config) {
            var viewManagerConfig = new ViewManagerConfig();
            viewManagerConfig.ViewAssemblies = new List<Assembly>() { this.GetType().Assembly };
            viewManagerConfig.ViewFactory = this.GetInstance;

            var viewManager = new ViewManager(viewManagerConfig);
            config.For<IViewManager>().Add(viewManager);

            config.For<IWindowManagerConfig>().Add(this);
            config.For<IWindowManager>().Add<WindowManager>().LifecycleIs<SingletonLifecycle>();
            config.For<IEventAggregator>().Add<EventAggregator>().LifecycleIs<SingletonLifecycle>();
            config.For<IMessageBoxViewModel>().Add<MessageBoxViewModel>().LifecycleIs<UniquePerRequestLifecycle>();
        }

        /// <summary>
        /// Override to add your own types to the IoC container.
        /// </summary>
        protected virtual void ConfigureIoC(ConfigurationExpression config) { }

        public override object GetInstance(Type type) {
            return this.container.GetInstance(type);
        }

        protected override void Launch() {
            base.DisplayRootView(this.RootViewModel);
        }

        public override void Dispose() {
            base.Dispose();
            ScreenExtensions.TryDispose(this._rootViewModel);
            if (this.container != null)
                this.container.Dispose();
        }
    }
}
