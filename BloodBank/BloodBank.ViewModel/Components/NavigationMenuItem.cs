using Stylet;

namespace BloodBank.ViewModel {

    public class NavigationMenuItem {
        public string Name { get; }
        public string Icon { get; }
        public IScreen Content { get; }

        public NavigationMenuItem(string name, string icon, IScreen content) {
            Name = name;
            Icon = icon;
            Content = content;
        }
    }
}