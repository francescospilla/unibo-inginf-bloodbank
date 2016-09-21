using System;
using System.Reflection;

namespace Stylet.DictionaryViewManager {
    public static class CreateViewManager {

        public static ViewManager ConfigureForDictionaryViewManager(this ViewManagerConfig viewManagerConfig, Type viewAssemblyType, Type viewModelAssemblyType) {
            viewManagerConfig.ViewAssemblies.Add(Assembly.GetAssembly(viewAssemblyType));
            return new DictionaryViewManager(viewManagerConfig, Assembly.GetAssembly(viewModelAssemblyType));
        }
    }
}
