using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stylet;

namespace BloodBank.ViewModel.Events
{
    public class OpenDialogEvent
    {
        public OpenDialogEvent(IScreen dialogContent)
        {
            DialogContent = dialogContent;
        }

        public IScreen DialogContent { get; }
    }
}
