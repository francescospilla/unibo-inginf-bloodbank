using Ninject;
using Stylet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using BloodBank.Mock;
using BloodBank.Model.Models.Donazioni;
using BloodBank.Model.Models.Persone;
using BloodBank.Model.Models.Sangue;
using BloodBank.Model.Service;
using Ninject.Activation.Strategies;

namespace BloodBank {
    public class NinjectBootstrapper<TRootViewModel> : BootstrapperBase where TRootViewModel : class {
        private IKernel kernel;

        private object _rootViewModel;
        protected virtual object RootViewModel {
            get { return this._rootViewModel ?? (this._rootViewModel = this.GetInstance(typeof(TRootViewModel))); }
        }

        protected override void ConfigureBootstrapper() {
            this.kernel = new StandardKernel();
            //this.kernel.Components.Add<IActivationStrategy, MyMonitorActivationStrategy>();
            this.DefaultConfigureIoC(this.kernel);
            this.ConfigureIoC(this.kernel);
        }

        /// <summary>
        /// Override to add your own ViewManager to the IoC container.
        /// </summary>
        /// <param name="viewManagerConfig"></param>
        /// <returns></returns>
        protected virtual ViewManager CreateViewManager(ViewManagerConfig viewManagerConfig) {
            return new ViewManager(viewManagerConfig);
        }


        /// <summary>
        /// Carries out default configuration of the IoC container. Override if you don't want to do this
        /// </summary>
        protected virtual void DefaultConfigureIoC(IKernel kernel) {
            var viewManagerConfig = new ViewManagerConfig() {
                ViewFactory = this.GetInstance,
                ViewAssemblies = new List<Assembly>() { this.GetType().Assembly }
            };

            ViewManager viewManager = CreateViewManager(viewManagerConfig);

            kernel.Bind<IViewManager>().ToConstant(viewManager);

            kernel.Bind<IWindowManagerConfig>().ToConstant(this);
            kernel.Bind<IWindowManager>().ToMethod(c => new WindowManager(c.Kernel.Get<IViewManager>(), () => c.Kernel.Get<IMessageBoxViewModel>(), c.Kernel.Get<IWindowManagerConfig>())).InSingletonScope();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            kernel.Bind<IMessageBoxViewModel>().To<MessageBoxViewModel>(); // Not singleton!
        }

        /// <summary>
        /// Override to add your own types to the IoC container.
        /// </summary>
        protected virtual void ConfigureIoC(IKernel kernel) { }

        public override object GetInstance(Type type) {
            return this.kernel.Get(type);
        }

        protected override void Launch() {
            base.DisplayRootView(this.RootViewModel);
        }

        public override void Dispose() {
            base.Dispose();
            ScreenExtensions.TryDispose(this._rootViewModel);
            if (this.kernel != null)
                this.kernel.Dispose();
        }
    }

    public class MyMonitorActivationStrategy : ActivationStrategy {

        public override void Activate(Ninject.Activation.IContext context, Ninject.Activation.InstanceReference reference) {

            Debug.WriteLine("Ninject Activate: " + reference.Instance.GetType());
            base.Activate(context, reference);
        }

        public override void Deactivate(Ninject.Activation.IContext context, Ninject.Activation.InstanceReference reference) {
            Debug.WriteLine("Ninject DeActivate: " + reference.Instance.GetType());
            base.Deactivate(context, reference);
        }
    }
}