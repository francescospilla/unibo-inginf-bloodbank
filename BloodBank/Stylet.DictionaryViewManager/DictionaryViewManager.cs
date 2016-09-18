using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Stylet.DictionaryViewManager {
    internal class TypeIgnoreGenericsEqualityCompararer : IEqualityComparer<Type> {

        public bool Equals(Type x, Type y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Type obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    public class DictionaryViewManager : ViewManager {
        // Dictionary of ViewModel type -> View type
        private readonly Dictionary<Type, Type> _viewModelToViewMapping;

        public DictionaryViewManager(ViewManagerConfig config, Assembly viewModeAssembly)
            : base(config)
        {
            var attributes =
                viewModeAssembly.GetExportedTypes()
                    .Select(type => new {type, attribute = type.GetCustomAttribute<AssociatedViewAttribute>()})
                    .Where(t => t.attribute != null && typeof (IScreen).IsAssignableFrom(t.type));

            var viewTypes = ViewAssemblies.SelectMany(x => x.GetExportedTypes());

            var mappings = attributes.Select(t =>
            {
                var view = viewTypes.SingleOrDefault(viewType => viewType.Name.Equals(t.attribute.View));
                if (view != null) return new {viewModel = t.type, view};

                Debug.WriteLine("Unable to find corresponding Type for View named " + t.attribute.View);
                return null;
            }).Where(x => x != null);

            _viewModelToViewMapping = mappings.ToDictionary(x => x.viewModel, x => x.view, new TypeIgnoreGenericsEqualityCompararer());
        }

        protected override Type LocateViewForModel(Type modelType) {
            Type viewType;
            return _viewModelToViewMapping.TryGetValue(modelType, out viewType) ? viewType : base.LocateViewForModel(modelType);
        }
    }

}
