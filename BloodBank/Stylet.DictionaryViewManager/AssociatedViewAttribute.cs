using System;

namespace Stylet.DictionaryViewManager {
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class AssociatedViewAttribute : Attribute {

        public string View { get; }

        public AssociatedViewAttribute(string view) {            
            View = view;
        }
    }
}