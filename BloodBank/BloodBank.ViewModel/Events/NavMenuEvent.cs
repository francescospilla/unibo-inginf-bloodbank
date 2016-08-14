namespace BloodBank.ViewModel.Events {

    public class NavMenuEvent {

        public enum NavMenuStates {
            Toggle,
            Open,
            Close
        }

        public NavMenuStates ChangeTo { get; }

        public NavMenuEvent(NavMenuStates changeTo = NavMenuStates.Toggle) {
            ChangeTo = changeTo;
        }
    }
}