using Stylet;

namespace BloodBank.ViewModel.Events
{
    public class DialogEvent
    {
        public DialogEvent(bool isOpen, IScreen dialogContent)
        {
            DialogContent = dialogContent;
            IsOpen = isOpen;
        }

        public bool IsOpen { get; }
        public IScreen DialogContent { get; }
    }
}
