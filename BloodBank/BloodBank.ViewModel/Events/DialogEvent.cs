using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
