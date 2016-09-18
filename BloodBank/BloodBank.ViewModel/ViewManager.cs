using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Stylet;
using Stylet.Logging;

namespace BloodBank.ViewModel {

    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    internal sealed class AssociatedViewAttribute : Attribute {

        public string View { get; }

        public AssociatedViewAttribute(string view) {            
            View = view;
        }
    }

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

        public DictionaryViewManager(ViewManagerConfig config)
            : base(config)
        {
            var attributes =
                Assembly.GetExecutingAssembly().GetExportedTypes()
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
